namespace Ciber.Xrm.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    using Microsoft.Xrm.Sdk.Query;

    public class XrmEntityMapper : IXrmEntityMapper
    {
        private readonly IXrmServices _xrmServices;
        private readonly List<EntityMetadata> _entityMetadata = new List<EntityMetadata>();
        private readonly IOrganizationService _organizationService;


        public XrmEntityMapper(IXrmServices xrmServices)
        {
            _xrmServices = xrmServices;
            _organizationService = _xrmServices.XrmService;
        }

        /// <summary>
        /// Get a lookup reference.
        /// </summary>
        /// <param name="attributeValue">The attribute value to lookup.</param>
        /// <param name="attributeMetadata">The attribute metadata</param>
        /// <param name="entityConfig">The configuration data for the source entity.</param>
        /// <param name="recordNumber">The current record number.</param>
        /// <param name="targetEntityName">The name of the target entity or null to use the 1st value in the metadata.</param>
        /// <returns>The Entity reference of the lookup.</returns>
        public EntityReference GetLookupReference(string attributeValue, AttributeMetadata attributeMetadata, XElement entityConfig, int recordNumber, string targetEntityName)
        {
            Guid lookupId;

            var lookupMetadata = (LookupAttributeMetadata)attributeMetadata;
            if (targetEntityName == null)
            {
                targetEntityName = lookupMetadata.Targets[0];
            }

            if (attributeValue.Length == 36 && attributeValue[8] == '-' && attributeValue[13] == '-')
            {
                lookupId = new Guid(attributeValue);
            }
            else
            {
                // See if a custom fetch has been defined for this attribute
                XElement lookupFetchDef = null;
                if (entityConfig != null && entityConfig.Element(attributeMetadata.LogicalName) != null)
                {
                    var attributeDef = entityConfig.Element(attributeMetadata.LogicalName);
                    if (attributeDef != null)
                    {
                        lookupFetchDef = attributeDef.Element("fetch");
                    }
                }

                if (lookupFetchDef != null)
                {
                    // Substitute the source value into the query string
                    var fetchXml = lookupFetchDef.ToString().Replace("%" + attributeMetadata.LogicalName + "%", attributeValue);
                    var fetchQuery = new FetchExpression(fetchXml);
                    var ec = _organizationService.RetrieveMultiple(fetchQuery);
                    if (ec.Entities.Count != 1)
                    {
                        var msg = ec.Entities.Count == 0 ? "Unable to find" : "Multiple records found for";
                        Console.WriteLine("{0} {1}='{2}' for entity {3} attribute {4}, import record {5}", msg, targetEntityName, attributeValue, lookupMetadata.EntityLogicalName, attributeMetadata.LogicalName, recordNumber);
                        Environment.Exit(1);
                    }

                    lookupId = ec.Entities[0].Id;
                }
                else
                {
                    // Try and find the record on its primary attribute
                    var targetEntityMetadata = GetEntityMetadata(targetEntityName);

                    var lookupQuery = from le in _xrmServices.XrmContext.CreateQuery(targetEntityName)
                                      where le.GetAttributeValue<string>(targetEntityMetadata.PrimaryNameAttribute) == attributeValue
                                      select le;
                    var lookupEntities = lookupQuery.ToList();
                    if (lookupEntities.Count != 1)
                    {
                        var msg = lookupEntities.Count == 0 ? "Unable to find" : "Multiple records found for";
                        Console.WriteLine("{0} {1}='{2}' for entity {3} attribute {4}, import record {5}", msg, targetEntityName, attributeValue, lookupMetadata.EntityLogicalName, attributeMetadata.LogicalName, recordNumber);
                        Environment.Exit(1);
                    }

                    lookupId = lookupEntities[0].Id;
                }
            }

            var er = new EntityReference(targetEntityName, lookupId);
            return er;
        }

        /// <summary>
        /// Gets the value of an entity attribute as a string.
        /// </summary>
        /// <param name="entity">The XRM entity.</param>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <param name="field">Optional Element to receive the additional attributes of the attribute</param>
        /// <returns>The string value of the attribute.</returns>
        public string GetEntityAttributeValue(Entity entity, string attributeName, XElement field)
        {
            var attributeValue = entity[attributeName];
            string value = null;
            var type = attributeValue.GetType();
            switch (type.Name.ToLower(CultureInfo.CurrentCulture))
            {
                case "boolean":
                case "decimal":
                case "double":
                case "guid":
                case "int32":
                case "string":
                    value = attributeValue.ToString();
                    break;
                case "datetime":
                    var dt = (DateTime)attributeValue;
                    value = dt.ToString("yyyy-MM-ddTHH:mm:ss");
                    break;
                case "entityreference":
                    var er = (EntityReference)attributeValue;
                    value = er.Id.ToString();

                    if (field != null)
                    {
                        field.Add(new XAttribute("LogicalName", er.LogicalName));
                        if (er.Name != null)
                        {
                            field.Add(new XAttribute("Name", er.Name));
                        }
                    }

                    break;
                case "money":
                    var money = (Money)attributeValue;
                    value = money.Value.ToString(CultureInfo.CurrentCulture);
                    break;
                case "optionsetvalue":
                    var picklist = (OptionSetValue)attributeValue;
                    value = picklist.Value.ToString(CultureInfo.CurrentCulture);
                    break;
                default:
                    throw new NotSupportedException("Unsupported attribute type: " + type.Name);
            }

            return value;
        }

        /// <summary>
        /// Get the metadata for an entity, including attributes.
        /// </summary>
        /// <param name="entityName">Name of the entity to retrieve metadata for.</param>
        /// <returns>The entity metadata.</returns>
        public EntityMetadata GetEntityMetadata(string entityName)
        {
            // See if the metadata is in the cache
            var metadata = _entityMetadata.SingleOrDefault(e => e.LogicalName == entityName);
            if (metadata == null)
            {
                var retrieveRequest = new RetrieveEntityRequest
                {
                    EntityFilters = EntityFilters.Attributes,
                    LogicalName = entityName,
                    RetrieveAsIfPublished = true
                };
                var retrieveResponse = (RetrieveEntityResponse)_organizationService.Execute(retrieveRequest);
                metadata = retrieveResponse.EntityMetadata;
                _entityMetadata.Add(metadata);
            }

            return metadata;
        }
    }
}
