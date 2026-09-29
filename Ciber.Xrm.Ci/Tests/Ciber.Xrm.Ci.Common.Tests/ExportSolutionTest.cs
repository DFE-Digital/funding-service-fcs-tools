namespace Ciber.Xrm.Ci.Common.Tests
{
    using System;
    using System.IO;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;
    using Moq;

    [TestClass]
    public class ExportSolutionTest
    { 
        [TestMethod, TestCategory("UnitTest")]
        public void EnsureExportSolutionExecutes()
        {
            var orgService = new Mock<ICrmOrganisationService>();
            var crmService = new Mock<IOrganizationService>();
            orgService.SetupGet(e => e.OrganizationService).Returns(crmService.Object);
            
            var exportSolution = new ExportSolution(orgService.Object);
            var tempFolder = Path.GetTempPath();
            var solutionName = Path.GetRandomFileName();

            orgService.Setup(e => e.RetrieveSolution(solutionName))
                .Returns(new Entity("solution"));
            var esr = new ExportSolutionResponse();
            esr.Results.Add("ExportSolutionFile", new byte[100]);
            
            orgService.Setup(e => e.Execute(It.IsAny<ExportSolutionRequest>()))
                .Returns(esr);

            exportSolution.Export(tempFolder, solutionName, false);

            crmService.VerifyAll();
        }

        [TestMethod, TestCategory("UnitTest")]
        public void EnsureExportSolutionExecutesWithVersionAppend()
        {
            var orgService = new Mock<ICrmOrganisationService>();
            var crmService = new Mock<IOrganizationService>();
            orgService.SetupGet(e => e.OrganizationService).Returns(crmService.Object);

            var exportSolution = new ExportSolution(orgService.Object);
            exportSolution.AppendVersionToFileName = true;

            var tempFolder = Path.GetTempPath();
            var solutionName = Path.GetRandomFileName();
            const string version = "1.0.1.2";
            var solutionEntity = new Entity("solution");
            solutionEntity.Attributes.Add("version", version);

            orgService.Setup(e => e.RetrieveSolution(solutionName))
                .Returns(solutionEntity);
            var esr = new ExportSolutionResponse();
            esr.Results.Add("ExportSolutionFile", new byte[100]);

            orgService.Setup(e => e.Execute(It.IsAny<ExportSolutionRequest>()))
                .Returns(esr);

            var filename = exportSolution.Export(tempFolder, solutionName, false);

            crmService.VerifyAll();
            Assert.AreEqual(string.Format("{0}_{1}.zip", solutionName, version.Replace(".","_")), filename);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void EnsureExportSolutionExecutesWithVersionAppendForManaged()
        {
            var orgService = new Mock<ICrmOrganisationService>();
            var crmService = new Mock<IOrganizationService>();
            orgService.SetupGet(e => e.OrganizationService).Returns(crmService.Object);

            var exportSolution = new ExportSolution(orgService.Object);
            exportSolution.AppendVersionToFileName = true;

            var tempFolder = Path.GetTempPath();
            var solutionName = Path.GetRandomFileName();
            const string version = "1.0.1.2";
            var solutionEntity = new Entity("solution");
            solutionEntity.Attributes.Add("version", version);

            orgService.Setup(e => e.RetrieveSolution(solutionName))
                .Returns(solutionEntity);
            var esr = new ExportSolutionResponse();
            esr.Results.Add("ExportSolutionFile", new byte[100]);

            orgService.Setup(e => e.Execute(It.IsAny<ExportSolutionRequest>()))
                .Returns(esr);

            var filename = exportSolution.Export(tempFolder, solutionName, true);

            crmService.VerifyAll();
            Assert.AreEqual(string.Format("{0}_{1}_managed.zip", solutionName, version.Replace(".", "_")), filename);
        }

        [TestMethod, TestCategory("UnitTest")]
        public void EnsureExceptionIfExportSolutionFailsOnCallToCrm()
        {
            var orgService = new Mock<ICrmOrganisationService>();
            var crmService = new Mock<IOrganizationService>();
            orgService.SetupGet(e => e.OrganizationService).Returns(crmService.Object);

            var exportSolution = new ExportSolution(orgService.Object);
            var tempFolder = Path.GetTempPath();
            var solutionName = Path.GetRandomFileName();

            orgService.Setup(e => e.RetrieveSolution(solutionName))
                .Returns(new Entity("solution"));
            
            orgService.Setup(e => e.Execute(It.IsAny<ExportSolutionRequest>()));

            try
            {
                exportSolution.Export(tempFolder, solutionName, false);
                Assert.Fail("Should throw exception");
            }
            catch (Exception)
            {
                // Happy Path :)
            }
            

            crmService.VerifyAll();
        }
    }
}
