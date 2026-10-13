namespace Ciber.Xrm.Ci.PowerShell
{
    using System.Diagnostics;
    using System.Management.Automation;
    using Microsoft.Crm.Tools.SolutionPackager;

    [Cmdlet("Expand", "XrmSolution")]
    public class ExpandXrmSolution : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string SolutionFile { get; set; }

        [Parameter(Mandatory = true)]
        public string OutputFolder { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteVerbose(string.Format("Extracting Solution: {0} to folder {1}", SolutionFile, OutputFolder));

            var args =
                new PackagerArguments
                {
                    Action = CommandAction.Extract,
                    Folder = OutputFolder,
                    PathToZipFile = SolutionFile,
                    AllowDeletes = AllowDelete.No,
                    AllowWrites = AllowWrite.Yes,
                    Clobber = false,
                    LocaleTemplate = "Auto",
                    SingleComponent = "None",
                    ErrorLevel = TraceLevel.Info,
                    LogFile = string.Empty
                };
            
            WriteVerbose("Built PackagerArguments");

            var packager = new SolutionPackager(args);
            WriteVerbose("Built SolutionPackager");
            
            packager.Run();
        }
    }
}
