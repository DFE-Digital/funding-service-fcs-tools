namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.Xml.Linq;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Metadata;
    using Microsoft.Xrm.Sdk.Query;
    using Xrm.Common;

    public class ImportData
    {
        private readonly string _configFilename;
        private readonly string _dataFilename;

        private readonly IOrganizationService _organizationService;
        private readonly IXrmEntityMapper _xrmEntityMapper;

        private enum ImportMode
        {
            Create,
            Replace,
            Update,
            UpdateCreate
        }
        public ImportData(string configFilename, string dataFilename, IOrganizationService organizationService, IXrmEntityMapper xrmEntityMapper)
        {
            _configFilename = configFilename;
            _dataFilename = dataFilename;
            _organizationService = organizationService;
            _xrmEntityMapper = xrmEntityMapper;
        }

        public void Execute()
        {
            
            var task = string.Empty;
            var recordsProcessed = 0;
            try
            {
                task = "loading configuration " + _configFilename;
                var config = XDocument.Load(_configFilename);
                task = "loading data file " + _dataFilename;
                var datafile = XDocument.Load(_dataFilename);

                var recordsAdded = 0;
                var recordsUpdated = 0;

                var failedEntities = XDocument.Parse("<Data/>");

                // Process each entity record
                foreach (var entityData in datafile.Element("Data").Elements())
                {
                    recordsProcessed++;

                    try
                    {
                        string entityName;
                        ImportMode mode;
                        XElement entityConfig;
                        bool update;
                        XElement matchFetchXml;
                        GetEntityDefinition(config, entityData, out entityName, out mode, out entityConfig, out update, out matchFetchXml);

                        var metadata = _xrmEntityMapper.GetEntityMetadata(entityName);

                        Entity entity;
                        EntityReference newowner;
                        BuildEntity(recordsProcessed, entityData, entityName, entityConfig, metadata, out entity, out newowner);
                        MatchExistingData(ref task, recordsProcessed, entityData, entityName, mode, ref update, matchFetchXml, entity);

                        // Process the record
                        if (update)
                        {
                            task = "updating record " + recordsProcessed.ToString(CultureInfo.CurrentCulture);
                            _organizationService.Update(entity);
                            if (newowner != null)
                            {
                                var assign = new AssignRequest { Assignee = newowner, Target = new EntityReference(entity.LogicalName, entity.Id) };
                                _organizationService.Execute(assign);
                            }

                            recordsUpdated++;
                        }
                        else
                        {
                            if (newowner != null)
                            {
                                entity["ownerid"] = newowner;
                            }

                            task = "creating record " + recordsProcessed.ToString(CultureInfo.CurrentCulture);
                            _organizationService.Create(entity);
                            recordsAdded++;
                        }
                    }
                    catch (FaultException<OrganizationServiceFault> ex)
                    {
                        var errorMessage = "XRM Error " + task + ": " + XrmErrorParser.Parse(ex);
                        ProcessImportError(recordsProcessed, entityData, errorMessage, failedEntities);
                    }
                    catch (Exception ex)
                    {
                        var errorMessage = "Error " + task + ": " + ex.Message + "\r\n" + ex.StackTrace;
                        ProcessImportError(recordsProcessed, entityData, errorMessage, failedEntities);
                    }
                }
                failedEntities.Save("FailedEntities.xml");

                Console.WriteLine(recordsProcessed + " records processed, Created=" + recordsAdded + ",  Updated=" + recordsUpdated);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + task + ": " + ex.Message + "\r\n" + ex.StackTrace);
                Environment.Exit(1);
            }
        }

        private void ProcessImportError(int recordsProcessed, XElement entityData, string errorMessage, XDocument failedEntities)
        {
            failedEntities.Root.Add(entityData);

            Console.Write("\r\n\r\n{0}", errorMessage);

            using (var file = new StreamWriter("FailedEntities with Errors.txt", true))
            {
                file.Write("\r\n\r\n-----\r\n{2}  {0}\r\n\r\n{1}", errorMessage, entityData, DateTime.Now.ToString("dd-M-yy  HH:mm:ss"));
            }
        }

        private void MatchExistingData(ref string task, int recordsProcessed, XElement entityData, string entityName, ImportMode mode, ref bool update, XElement matchFetchXml, Entity entity)
        {
            if (mode == ImportMode.Replace || mode == ImportMode.Update || mode == ImportMode.UpdateCreate)
            {
                var fetchXml = matchFetchXml.ToString();

                foreach (var kvp in entity.Attributes)
                {
                    var attName = kvp.Key;
                    var value = _xrmEntityMapper.GetEntityAttributeValue(entity, attName, null);
                    fetchXml = fetchXml.Replace("%" + attName + "%", value);
                }

                var fetch = new FetchExpression(fetchXml);
                var ec = _organizationService.RetrieveMultiple(fetch);
                if (ec.Entities.Count == 1)
                {
                    entity.Id = ec.Entities[0].Id;
                    if (mode == ImportMode.Update || mode == ImportMode.UpdateCreate)
                    {
                        update = true;
                    }
                    else if (mode == ImportMode.Replace)
                    {
                        task = "Deleting existing record";
                        _organizationService.Delete(entityName, entity.Id);
                    }
                }
                else if (ec.Entities.Count > 1)
                {
                    Console.WriteLine("Multiple matching records found for record " + recordsProcessed.ToString(CultureInfo.CurrentCulture) + "\r\n" + entityData);
                    Environment.Exit(1);
                }
                else if (!ec.Entities.Any() && mode == ImportMode.Update)
                {
                    Console.WriteLine("No matching record found for record " + recordsProcessed.ToString(CultureInfo.CurrentCulture) + "\r\n" + entityData);
                    Environment.Exit(1);
                }
            }
        }

        private void GetEntityDefinition(XDocument config, XElement entityData, out string entityName, out ImportMode mode, out XElement entityConfig, out bool update, out XElement matchFetchXml)
        {
            entityName = entityData.Name.LocalName;
            mode = ImportMode.Create;

            entityConfig = config.Element("ImportConfiguration").Element(entityName);
            update = false;
            matchFetchXml = null;
            if (entityConfig != null)
            {
                var entityMode = entityConfig.Element("Mode");
                if (entityMode != null)
                {
                    switch (entityMode.Value.ToLower(CultureInfo.CurrentCulture))
                    {
                        case "create":
                            mode = ImportMode.Create;
                            break;
                        case "replace":
                            mode = ImportMode.Replace;
                            break;
                        case "update":
                            mode = ImportMode.Update;
                            break;
                        case "updatecreate":
                            mode = ImportMode.UpdateCreate;
                            break;
                        default:
                            Console.WriteLine("Unknown import mode: " + entityMode.Value);
                            Environment.Exit(1);
                            break;
                    }
                }

                matchFetchXml = entityConfig.Element("Match").Element("fetch");
                if ((mode == ImportMode.Replace || mode == ImportMode.Update || mode == ImportMode.UpdateCreate) && matchFetchXml == null)
                {
                    Console.WriteLine("Missing Match fetch xml for entity " + entityName);
                    Environment.Exit(1);
                }
            }
        }

        private void BuildEntity(int recordsProcessed, XElement entityData, string entityName, XElement entityConfig, EntityMetadata metadata, out Entity entity, out EntityReference newowner)
        {
            entity = new Entity(entityName);
            newowner = null;
            foreach (var attributeData in entityData.Elements())
            {
                var attributeName = attributeData.Name.LocalName;
                var attributeValue = attributeData.Value;
                var logicalNameAttribute = attributeData.Attribute("LogicalName");
                var lookupLogicalName = logicalNameAttribute != null ? logicalNameAttribute.Value : null;
                
                var attributeMetadata = metadata.Attributes.SingleOrDefault(a => a.LogicalName == attributeName);
                if (attributeMetadata == null)
                {
                    Console.WriteLine(entityName + " does not contain an attribute called " + attributeName);
                    Environment.Exit(1);
                }

                try
                {
                    switch (attributeMetadata.AttributeType)
                    {
                        case AttributeTypeCode.Boolean:
                            entity[attributeName] = Boolean.Parse(attributeValue);
                            break;

                        case AttributeTypeCode.DateTime:
                            entity[attributeName] = DateTime.Parse(attributeValue, CultureInfo.CurrentCulture);
                            break;

                        case AttributeTypeCode.Decimal:
                            entity[attributeName] = Decimal.Parse(attributeValue, CultureInfo.CurrentCulture);
                            break;

                        case AttributeTypeCode.Money:
                            entity[attributeName] = new Money(Decimal.Parse(attributeValue, CultureInfo.CurrentCulture));
                            break;

                        case AttributeTypeCode.Double:
                            entity[attributeName] = Double.Parse(attributeValue, CultureInfo.CurrentCulture);
                            break;

                        case AttributeTypeCode.Integer:
                            entity[attributeName] = Int32.Parse(attributeValue, CultureInfo.CurrentCulture);
                            break;

                        case AttributeTypeCode.Lookup:
                            entity[attributeName] = _xrmEntityMapper.GetLookupReference(attributeValue, attributeMetadata, entityConfig, recordsProcessed, lookupLogicalName);
                            break;

                        case AttributeTypeCode.Owner:
                            newowner = _xrmEntityMapper.GetLookupReference(attributeValue, attributeMetadata, entityConfig, recordsProcessed, lookupLogicalName);
                            break;

                        case AttributeTypeCode.Memo:
                        case AttributeTypeCode.String:
                            entity[attributeName] = attributeValue;
                            break;

                        case AttributeTypeCode.Picklist:
                        case AttributeTypeCode.State:
                        case AttributeTypeCode.Status:
                            entity[attributeName] = new OptionSetValue(Int32.Parse(attributeValue, CultureInfo.CurrentCulture));
                            break;

                        case AttributeTypeCode.Uniqueidentifier:
                            entity[attributeName] = new Guid(attributeValue);
                            break;

                        case AttributeTypeCode.Customer:
                            entity[attributeName] = _xrmEntityMapper.GetLookupReference(attributeValue, attributeMetadata, entityConfig, recordsProcessed, lookupLogicalName);
                            break;

                        case AttributeTypeCode.EntityName:
                            entity[attributeName] = attributeValue;
                            break;

                        default:
                            Console.WriteLine("Unsupported attribute type: " + entityName + "." + attributeName);
                            Environment.Exit(1);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to parse data value for entity " + entityName + " attribute: " + attributeName + ", value=" + attributeValue + "\r\n" + ex.Message);
                    Environment.Exit(1);
                }
            }
        }
    }
}
