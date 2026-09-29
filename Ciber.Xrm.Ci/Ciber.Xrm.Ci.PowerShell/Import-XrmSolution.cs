namespace Ciber.Xrm.Ci.PowerShell
{
    using System.Management.Automation;
    using Common;

    [Cmdlet("Import", "XrmSolution")]
    public class ImportXrmSolutionCommand : Cmdlet
    {
        private int _asyncWaitTimeout = 900;

        [Parameter(Mandatory = true)]
        public string ConnectionString { get; set; }

        [Parameter(Mandatory = true)]
        public string SolutionFilePath { get; set; }

        [Parameter(Mandatory = false)]
        public bool PublishWorkflows { get; set; }

        [Parameter(Mandatory = false)]
        public bool ConvertToManaged { get; set; }

        [Parameter(Mandatory = false)]
        public bool OverwriteUnmanagedCustomizations { get; set; }

        [Parameter(Mandatory = false)]
        public bool ImportAsync { get; set; }

        [Parameter(Mandatory = false)]
        public bool WaitForCompletion { get; set; }

        [Parameter(Mandatory = false)]
        public int AsyncWaitTimeout
        {
            get
            {
                return _asyncWaitTimeout;
            }
            set
            {
                _asyncWaitTimeout = value;
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteVerbose(string.Format("Importing Solution: {0}", SolutionFilePath));
            using (var organizationService = new CrmOrganisationService(ConnectionString))
            {
                var asyncJobManager = new CrmAsyncJobManager(organizationService);
                new ImportSolution(organizationService, asyncJobManager).Import(SolutionFilePath, PublishWorkflows, ConvertToManaged, OverwriteUnmanagedCustomizations, ImportAsync, WaitForCompletion, AsyncWaitTimeout);
                WriteVerbose(string.Format("{0} Imported Successfully", SolutionFilePath));
            }
        }
    }
}
