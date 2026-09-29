namespace Ciber.Xrm.Common
{
    using System.Xml.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Metadata;

    public interface IXrmEntityMapper
    {
        /// <summary>
        /// Get a lookup reference.
        /// </summary>
        /// <param name="attributeValue">The attribute value to lookup.</param>
        /// <param name="attributeMetadata">The attribute metadata</param>
        /// <param name="entityConfig">The configuration data for the source entity.</param>
        /// <param name="recordNumber">The current record number.</param>
        /// <param name="targetEntityName">The name of the target entity or null to use the 1st value in the metadata.</param>
        /// <returns>The Entity reference of the lookup.</returns>
        EntityReference GetLookupReference(string attributeValue, AttributeMetadata attributeMetadata, XElement entityConfig, int recordNumber, string targetEntityName);

        /// <summary>
        /// Gets the value of an entity attribute as a string.
        /// </summary>
        /// <param name="entity">The XRM entity.</param>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <param name="field">Optional Element to receive the additional attributes of the attribute</param>
        /// <returns>The string value of the attribute.</returns>
        string GetEntityAttributeValue(Entity entity, string attributeName, XElement field);

        /// <summary>
        /// Get the metadata for an entity, including attributes.
        /// </summary>
        /// <param name="entityName">Name of the entity to retrieve metadata for.</param>
        /// <returns>The entity metadata.</returns>
        EntityMetadata GetEntityMetadata(string entityName);
    }
}