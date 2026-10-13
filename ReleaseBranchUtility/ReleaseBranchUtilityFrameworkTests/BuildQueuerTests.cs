namespace ReleaseBranchUtilityFrameworkTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReleaseBranchUtilityLib;

    [TestClass]
    public class BuildQueuerTests
    {
        [TestMethod, TestCategory("TechnicalExploration")]
        public void ShouldQueueBuilds()
        {
            // arrange
            (var connection, var project) = ReleaseBranchAdder.GetConnectionAndProject("https://dev.azure.com/sfa-fcs", "FCT");

            // act
            BuildQueuer.QueueCIBuilds(project.Id, connection, s => {});
        }
    }
}
