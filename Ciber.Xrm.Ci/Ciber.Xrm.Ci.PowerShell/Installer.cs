namespace Ciber.Xrm.Ci.PowerShell
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;

    [RunInstaller(true)]
    public class CiberXrmCiSnapInInstaller : CustomPSSnapIn
    {
        private readonly Collection<CmdletConfigurationEntry> _cmdlets = new Collection<CmdletConfigurationEntry>();
        private readonly Collection<ProviderConfigurationEntry> _providers = new Collection<ProviderConfigurationEntry>();
        private readonly Collection<TypeConfigurationEntry> _types = new Collection<TypeConfigurationEntry>();
        private readonly Collection<FormatConfigurationEntry> _formats = new Collection<FormatConfigurationEntry>();

        public CiberXrmCiSnapInInstaller()
        {
            _cmdlets.Add(new CmdletConfigurationEntry("Compress-XrmSolution", typeof(CompressXrmSolution), null));
            _cmdlets.Add(new CmdletConfigurationEntry("Expand-XrmSolution", typeof(ExpandXrmSolution), null));
            _cmdlets.Add(new CmdletConfigurationEntry("Import-XrmSolution", typeof(ImportXrmSolutionCommand), null));
            _cmdlets.Add(new CmdletConfigurationEntry("Extract-XrmSolution", typeof(ExportXrmSolutionCommand), null));
        }

        public override string Name
        {
            get { return "CiberXrmCi"; }
        }

        public override string Vendor
        {
            get { return "Ciber"; }
        }

        public override string Description
        {
            get { return "This snap-in contains the cmdlets relating to CRM Continuous Integration."; }
        }

        public override Collection<CmdletConfigurationEntry> Cmdlets
        {
            get { return _cmdlets; }
        }

        public override Collection<ProviderConfigurationEntry> Providers
        {
            get { return _providers; }
        }

        public override Collection<TypeConfigurationEntry> Types
        {
            get { return _types; }
        }

        public override Collection<FormatConfigurationEntry> Formats
        {
            get { return _formats; }
        }
    }
}
