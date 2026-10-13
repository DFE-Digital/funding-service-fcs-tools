namespace Ciber.Xrm.Ci.Common
{
    using System;
    using Microsoft.Xrm.Sdk;

    public interface ICrmAsyncJobManager
    {
        void WaitForJob(Guid jobId, int asyncWaitTimeout);

        Guid StartAsyncJob(OrganizationRequest orgRequest);
    }
}