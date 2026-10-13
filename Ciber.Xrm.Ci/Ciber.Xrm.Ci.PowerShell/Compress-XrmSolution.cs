namespace Ciber.Xrm.Ci.PowerShell
{
    using System.Diagnostics;
    using System.Management.Automation;
    using Microsoft.Crm.Tools.SolutionPackager;

    [Cmdlet("Compress", "XrmSolution")]
    public class CompressXrmSolution : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string OutputSolutionFile { get; set; }

        [Parameter(Mandatory = true)]
        public string SolutionFolder { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteVerbose(string.Format("Packing Solution: {0} from folder {1}", OutputSolutionFile, SolutionFolder));

            var args =
                new PackagerArguments
                {
                    Action = CommandAction.Pack,
                    Folder = SolutionFolder,
                    PathToZipFile = OutputSolutionFile,
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
