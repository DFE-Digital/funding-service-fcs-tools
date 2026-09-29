namespace AzureDiagnosticLogReader
{
    public class DeploymentInfo
    {
        public DeploymentInfo(string deploymentId, string deploymentName, string storage)
        {
            DeploymentId = deploymentId;
            DeploymentName = deploymentName;
            StorageKey = storage;
        }
        public string DeploymentId { get; }

        public string DeploymentName { get; }

        public string StorageKey { get; }
    }
}
