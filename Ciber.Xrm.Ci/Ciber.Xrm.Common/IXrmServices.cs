namespace Ciber.Xrm.Common
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Xrm.Sdk.Query;

    public interface IXrmServices
    {
        /// <summary>
        /// The XRM service instance for making XRM API requests.
        /// </summary>
        IOrganizationService XrmService { get; }

        /// <summary>
        /// The XRM service context.
        /// </summary>
        OrganizationServiceContext XrmContext { get; }

        /// <summary>
        /// Creates an entity, with tracing and error handling.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        Guid Create(Entity entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entityName">Logical name of the entity to delete.</param>
        /// <param name="entityId">ID of the entity to delete.</param>
        /// <returns>The ID of the created entity.</returns>
        void Delete(string entityName, Guid entityId);

        /// <summary>
        /// Executes an XRM request, returning the XRM fault if one occurs.
        /// </summary>
        /// <param name="request">The XRM request to execute.</param>
        /// <param name="fault">The XRM fault that occured.</param>
        /// <returns>The XRM message response.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Shared Code")]
        OrganizationResponse Execute(OrganizationRequest request, out FaultException<OrganizationServiceFault> fault);

        /// <summary>
        /// Executes an XRM request.
        /// </summary>
        /// <param name="request">The XRM request to execute.</param>
        /// <returns>The XRM message response.</returns>
        OrganizationResponse Execute(OrganizationRequest request);

        /// <summary>
        /// Performs an XRM Retrieve, with retry & logging.
        /// </summary>
        /// <param name="entityName">The name of the entity to retrieve.</param>
        /// <param name="id">The GUID of the entity to retrieve.</param>
        /// <param name="columnSet">The entity columns to retrieve.</param>
        /// <returns>The requested CRM entity.</returns>
        Entity Retrieve(string entityName, Guid id, ColumnSet columnSet);

        /// <summary>
        /// Performs an XRM Retrieve, optionally allowing for a not found condition.
        /// </summary>
        /// <param name="entityName">The name of the entity to retrieve.</param>
        /// <param name="id">The GUID of the entity to retrieve.</param>
        /// <param name="columnSet">The entity columns to retrieve.</param>
        /// <param name="allowNotFound">If the specified entity does not exist, then a null entity will be returned rather than generating a fault.</param>
        /// <returns>The requested CRM entity.</returns>
        Entity Retrieve(string entityName, Guid id, ColumnSet columnSet, bool allowNotFound);

        /// <summary>
        /// Performs an XRM RetrieveMultiple, with retry & logging.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>Returns the collection of entities.</returns>
        EntityCollection RetrieveMultiple(QueryBase query);

        /// <summary>
        /// Sets the state and status of an entity.
        /// </summary>
        /// <param name="entityName">The logical name of the entity to set.</param>
        /// <param name="id">The GUID of the entity to set.</param>
        /// <param name="state">The entity state value.</param>
        /// <param name="status">The entity status value - must be valid for the specified state.</param>
        void SetState(string entityName, Guid id, int state, int status);

        /// <summary>
        /// Performs an XRM Update of the specified entity with tracing, logging and retries.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void Update(Entity entity);
    }
}