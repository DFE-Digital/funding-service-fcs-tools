using System;
using System.Net;
using FeatureFileParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureFileParserTest
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void Should_CaptureFeatureAndCategoryTagsAndPerformTFSLookup()
        {
            const string userName = "<username>";
            const string password = "<password>";
            const string domain = "CIDEV";
            const string path = @"D:\CodeRoot\FCT\Dev\Contracts.AcceptanceTests\Contracts.AcceptanceTests\Features\";

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var fd = new FeatureDiscovery(path, "FCT",
                new Uri("https://tfs.sfa.bis.gov.uk"),
                new NetworkCredential(userName, password, domain));

            //Assert.AreEqual(30, fd.FeatureCategories.Count);
            //Assert.AreEqual(14, fd.StoryCategories.Count);

            fd.UpdateFeatureFiles();

        }
    }
}
