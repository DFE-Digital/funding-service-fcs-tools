namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using Microsoft.Crm.Sdk.Messages;

    public class ImportSolution
    {
        public ICrmOrganisationService OrgService { get; set; }
        public ICrmAsyncJobManager CrmAsyncJobManager { get; set; }

        public ImportSolution(ICrmOrganisationService orgService, ICrmAsyncJobManager crmAsyncJobManager)
        {
            OrgService = orgService;
            CrmAsyncJobManager = crmAsyncJobManager;
        }

        public Guid? Import(string solutionFilePath, bool publishWorkflows, bool convertToManaged, bool overwriteUnmanagedCustomizations, 
            bool importAsync, bool waitForCompletion, int asyncWaitTimeout)
        {
            Contract.Requires(!string.IsNullOrEmpty(solutionFilePath));

            var jobId = new Guid?();
            var numArray = File.ReadAllBytes(solutionFilePath);

            var importSolutionRequest = new ImportSolutionRequest
            {
                CustomizationFile = numArray,
                PublishWorkflows = publishWorkflows,
                ConvertToManaged = convertToManaged,
                OverwriteUnmanagedCustomizations = overwriteUnmanagedCustomizations
            };

            if (importAsync)
            {
                jobId = CrmAsyncJobManager.StartAsyncJob(importSolutionRequest);

                if (!waitForCompletion)
                    return jobId;

                CrmAsyncJobManager.WaitForJob(jobId.Value, asyncWaitTimeout);
                return jobId;
            }
            OrgService.Execute(importSolutionRequest);
            return jobId;
        }
    }
}
