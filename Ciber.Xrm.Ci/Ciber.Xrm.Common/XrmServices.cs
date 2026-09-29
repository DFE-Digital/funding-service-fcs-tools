namespace Ciber.Xrm.Common
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.ServiceModel;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;

    public sealed class XrmServices : IDisposable, IXrmServices
    {
        private readonly IOrganizationService _organizationService;

        //private OrganizationServiceProxy _crmServiceProxy = null;
        private OrganizationServiceContext _xrmContext;
        private static readonly string ClassName;

        static XrmServices()
        {
            ClassName = typeof (XrmServices).FullName;
        }

        /// <summary>
        /// The XRM service instance for making XRM API requests.
        /// </summary>
        public IOrganizationService XrmService
        {
            get { return _organizationService; }
        }

        /// <summary>
        /// The XRM service context.
        /// </summary>
        public OrganizationServiceContext XrmContext
        {
            get
            {
                if (_xrmContext == null)
                {
                    _xrmContext = new OrganizationServiceContext(XrmService);
                    _xrmContext.MergeOption = MergeOption.NoTracking; // Default to no tracking of entities within the context.
                }
                return _xrmContext;
            }
        }

        /// <summary>
        /// </summary>
        public XrmServices(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// Creates an entity, with tracing and error handling.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        public Guid Create(Entity entity)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Entity=" + entity.LogicalName);
            var request = new CreateRequest
            {
                Target = entity
            };

            var response = (CreateResponse)Execute(request);
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Created entity " + entity.LogicalName + " id=" + response.id);
            return response.id;
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entityName">Logical name of the entity to delete.</param>
        /// <param name="entityId">ID of the entity to delete.</param>
        /// <returns>The ID of the created entity.</returns>
        public void Delete(string entityName, Guid entityId)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Entity=" + entityName + " Id=" + entityId);
            var request = new DeleteRequest
            {
                Target = new EntityReference(entityName, entityId)
            };

            Execute(request);
        }

        /// <summary>
        /// Executes an XRM request, returning the XRM fault if one occurs.
        /// </summary>
        /// <param name="request">The XRM request to execute.</param>
        /// <param name="fault">The XRM fault that occured.</param>
        /// <returns>The XRM message response.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Shared Code")]
        public OrganizationResponse Execute(OrganizationRequest request, out FaultException<OrganizationServiceFault> fault)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Request=" + request.RequestName);
            OrganizationResponse response = null;
            fault = null;
            try
            {
                response = XrmService.Execute(request);
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                Trace.TraceError(ClassName + MethodBase.GetCurrentMethod().Name + ": XRM error executing request " + request.RequestName + ", error: " + GetXrmError(ex) + "\r\n" + ex.StackTrace);
                fault = ex;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ClassName + MethodBase.GetCurrentMethod().Name + ": System error executing request " + request.RequestName + ", error: " + GetXrmError(ex) + "\r\n" + ex.StackTrace);
                throw;
            }

            return response;
        }

        /// <summary>
        /// Executes an XRM request.
        /// </summary>
        /// <param name="request">The XRM request to execute.</param>
        /// <returns>The XRM message response.</returns>
        public OrganizationResponse Execute(OrganizationRequest request)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Request=" + request.RequestName);
            OrganizationResponse response = null;
            try
            {
                response = XrmService.Execute(request);
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                Trace.TraceError(ClassName + MethodBase.GetCurrentMethod().Name + ": XRM error executing request " + request.RequestName + ", error: " + GetXrmError(ex) + "\r\n" + ex.StackTrace);
                throw;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ClassName + MethodBase.GetCurrentMethod().Name + ": System error executing request " + request.RequestName + ", error: " + GetXrmError(ex) + "\r\n" + ex.StackTrace);
                throw;
            }

            return response;
        }

        /// <summary>
        /// Performs an XRM Retrieve, with retry & logging.
        /// </summary>
        /// <param name="entityName">The name of the entity to retrieve.</param>
        /// <param name="id">The GUID of the entity to retrieve.</param>
        /// <param name="columnSet">The entity columns to retrieve.</param>
        /// <returns>The requested CRM entity.</returns>
        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            return Retrieve(entityName, id, columnSet, false);
        }

        /// <summary>
        /// Performs an XRM Retrieve, optionally allowing for a not found condition.
        /// </summary>
        /// <param name="entityName">The name of the entity to retrieve.</param>
        /// <param name="id">The GUID of the entity to retrieve.</param>
        /// <param name="columnSet">The entity columns to retrieve.</param>
        /// <param name="allowNotFound">If the specified entity does not exist, then a null entity will be returned rather than generating a fault.</param>
        /// <returns>The requested CRM entity.</returns>
        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet, bool allowNotFound)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Entity=" + entityName + ", id=" + id);
            Entity entity = null;
            var request = new RetrieveRequest
            {
                ColumnSet = columnSet,
                Target = new EntityReference(entityName, id)
            };

            FaultException<OrganizationServiceFault> fault;
            var response = (RetrieveResponse)Execute(request, out fault);
            if (fault != null)
            {
                if (fault.Detail.ErrorCode != XrmErrorCodes.ObjectDoesNotExist)
                {
                    throw fault;
                }
            }
            else
            {
                entity = response.Entity;
            }

            return entity;
        }

        /// <summary>
        /// Performs an XRM RetrieveMultiple, with retry & logging.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>Returns the collection of entities.</returns>
        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name);
            var request = new RetrieveMultipleRequest
            {
                Query = query
            };

            var response = (RetrieveMultipleResponse)Execute(request);
            return response.EntityCollection;
        }

        /// <summary>
        /// Sets the state and status of an entity.
        /// </summary>
        /// <param name="entityName">The logical name of the entity to set.</param>
        /// <param name="id">The GUID of the entity to set.</param>
        /// <param name="state">The entity state value.</param>
        /// <param name="status">The entity status value - must be valid for the specified state.</param>
        public void SetState(string entityName, Guid id, int state, int status)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Entity=" + entityName + ", id=" + id + ", state=" + state + ", status=" + status);
            var request = new SetStateRequest
            {
                EntityMoniker = new EntityReference(entityName, id),
                State = new OptionSetValue(state),
                Status = new OptionSetValue(status)
            };

            Execute(request);
        }

        /// <summary>
        /// Performs an XRM Update of the specified entity with tracing, logging and retries.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        public void Update(Entity entity)
        {
            Trace.TraceInformation(ClassName + MethodBase.GetCurrentMethod().Name + ": Entity=" + entity.LogicalName + ", id=" + entity.Id);
            var request = new UpdateRequest();
            request.Target = entity;
            Execute(request);
        }

        /// <summary>
        /// Get the XRM error details from an XRM exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The text of the error.</returns>
        public static string GetXrmError(FaultException<OrganizationServiceFault> exception)
        {
            var message = "";
            var fault = exception.Detail;
            while (fault != null)
            {
                message += fault.Message + "\r\n";
                fault = fault.InnerFault;
            }

            return message;
        }

        /// <summary>
        /// Get the error details from an exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The text of the error.</returns>
        public static string GetXrmError(Exception exception)
        {
            var message = "System error: " + exception.Message;
            if (exception.InnerException != null)
            {
                var innerXrm = exception.InnerException as FaultException<OrganizationServiceFault>;
                if (innerXrm != null)
                {
                    message += ", XRM error: " + innerXrm.Detail.Message;
                }
                else
                {
                    message += ", Inner fault: " + exception.InnerException.Message;
                }
            }

            return message;
        }

        public void Dispose()
        {
            if (_xrmContext != null)
            {
                _xrmContext.Dispose();
            }
        }
    }
}