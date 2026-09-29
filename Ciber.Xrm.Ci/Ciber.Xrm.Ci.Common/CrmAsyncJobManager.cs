namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Query;

    public class CrmAsyncJobManager : ICrmAsyncJobManager
    {
        public IOrganizationService OrganizationService { get; set; }

        public CrmAsyncJobManager(ICrmOrganisationService organizationService)
        {
            Contract.Requires(organizationService != null);

            OrganizationService = organizationService.OrganizationService;
        }

        public Guid StartAsyncJob(OrganizationRequest orgRequest)
        {
            var eaRequest = new ExecuteAsyncRequest
            {
                Request = orgRequest
            };

            var response = OrganizationService.Execute<ExecuteAsyncResponse>(eaRequest);
            return response.AsyncJobId;
        }

        public void WaitForJob(Guid jobId, int asyncWaitTimeout)
        {
            var dateTime = DateTime.Now.AddSeconds(asyncWaitTimeout);
            while (dateTime >= DateTime.Now)
            {
                var asyncOperation = OrganizationService.Retrieve("asyncoperation", jobId,
                    new ColumnSet("asyncoperationid", "statuscode", "message"));

                var statusCode = (asyncOperation.Attributes["statuscode"] as OptionSetValue).Value;
                var message = asyncOperation.Attributes["message"];

                switch (statusCode)
                {
                    case 21:
                    case 22:
                    case 31:
                    case 32:
                        throw new Exception(string.Format("Solution Import Failed: {0} {1}", statusCode, message));
                    case 30:
                        return;
                    default:
                        continue;
                }
            }
            throw new Exception(string.Format("Import Timeout: {0}", asyncWaitTimeout));
        }
    }
}
