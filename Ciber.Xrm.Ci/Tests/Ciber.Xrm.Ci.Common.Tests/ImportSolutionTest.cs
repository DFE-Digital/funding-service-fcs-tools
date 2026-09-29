namespace Ciber.Xrm.Ci.Common.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;
    using Moq;

    [TestClass]
    public class ImportSolutionTest
    {
        [TestMethod, TestCategory("UnitTest")]
        public void EnsureOrganizationRequestIsMadeForNonAsyncRequest()
        {
            var crmService = new Mock<ICrmOrganisationService>();
            var crmAsyncJobManager = new Mock<ICrmAsyncJobManager>();

            var importSolution = new ImportSolution(crmService.Object, crmAsyncJobManager.Object);

            crmService.Setup(e => e.Execute(It.IsAny<OrganizationRequest>()));

            var filename = Path.GetTempFileName();
            importSolution.Import(filename, false, false, false, false, false, 0);

            crmService.VerifyAll();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void EnsureExecuteAsyncRequestIsMadeForAsyncRequestAndWait()
        {
            var orgService = new Mock<ICrmOrganisationService>();
            var crmService = new Mock<IOrganizationService>();
            var crmAsyncJobManager = new Mock<ICrmAsyncJobManager>();
            var jobId = Guid.NewGuid();
            crmAsyncJobManager.Setup(e => e.StartAsyncJob(It.IsAny<OrganizationRequest>()))
                .Returns(jobId);
            crmAsyncJobManager.Setup(e => e.WaitForJob(jobId, It.IsAny<int>()));

            orgService.SetupGet(e => e.OrganizationService).Returns(crmService.Object);
            var importSolution = new ImportSolution(orgService.Object, crmAsyncJobManager.Object);

            var filename = Path.GetTempFileName();
            importSolution.Import(filename, false, false, false, true, true, 0);

            crmService.VerifyAll();
            crmAsyncJobManager.VerifyAll();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void EnsureExecuteAsyncRequestIsMadeForAsyncRequestNoWait()
        {
            var orgService = new Mock<ICrmOrganisationService>();
            var crmService = new Mock<IOrganizationService>();
            var crmAsyncJobManager = new Mock<ICrmAsyncJobManager>();
            var jobId = Guid.NewGuid();
            crmAsyncJobManager.Setup(e => e.StartAsyncJob(It.IsAny<OrganizationRequest>()))
                .Returns(jobId);
            
            orgService.SetupGet(e => e.OrganizationService).Returns(crmService.Object);
            var importSolution = new ImportSolution(orgService.Object, crmAsyncJobManager.Object);

            var filename = Path.GetTempFileName();
            importSolution.Import(filename, false, false, false, true, false, 0);

            crmService.VerifyAll();
            crmAsyncJobManager.VerifyAll();
        }
    }
}
