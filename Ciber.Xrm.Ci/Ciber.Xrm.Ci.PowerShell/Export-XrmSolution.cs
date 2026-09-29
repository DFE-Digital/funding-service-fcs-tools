namespace Ciber.Xrm.Ci.PowerShell
{
    using System.Management.Automation;
    using Common;

    [Cmdlet("Export", "XrmSolution")]
    public class ExportXrmSolutionCommand : Cmdlet
    {
        private bool _exportAutoNumberingSettings = true;
        private bool _exportCalendarSettings = true;
        private bool _exportCustomizationSettings = true;
        private bool _exportEmailTrackingSettings = true;
        private bool _exportGeneralSettings = true;
        private bool _exportIsvConfig = true;
        private bool _exportMarketingSettings = true;
        private bool _exportOutlookSynchronizationSettings = true;
        private bool _exportRelationshipRoles = true;

        [Parameter(Mandatory = true)]
        public string ConnectionString { get; set; }

        [Parameter(Mandatory = true)]
        public string SolutionName { get; set; }

        [Parameter(Mandatory = false)]
        public bool Managed { get; set; }

        [Parameter(Mandatory = true)]
        public string OutputFolder { get; set; }

        [Parameter(Mandatory = false)]
        public bool ExportAutoNumberingSettings
        {
            get
            {
                return _exportAutoNumberingSettings;
            }
            set
            {
                _exportAutoNumberingSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportCalendarSettings
        {
            get
            {
                return _exportCalendarSettings;
            }
            set
            {
                _exportCalendarSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportCustomizationSettings
        {
            get
            {
                return _exportCustomizationSettings;
            }
            set
            {
                _exportCustomizationSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportEmailTrackingSettings
        {
            get
            {
                return _exportEmailTrackingSettings;
            }
            set
            {
                _exportEmailTrackingSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportGeneralSettings
        {
            get
            {
                return _exportGeneralSettings;
            }
            set
            {
                _exportGeneralSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportIsvConfig
        {
            get
            {
                return _exportIsvConfig;
            }
            set
            {
                _exportIsvConfig = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportMarketingSettings
        {
            get
            {
                return _exportMarketingSettings;
            }
            set
            {
                _exportMarketingSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportOutlookSynchronizationSettings
        {
            get
            {
                return _exportOutlookSynchronizationSettings;
            }
            set
            {
                _exportOutlookSynchronizationSettings = value;
            }
        }

        [Parameter(Mandatory = false)]
        public bool ExportRelationshipRoles
        {
            get
            {
                return _exportRelationshipRoles;
            }
            set
            {
                _exportRelationshipRoles = value;
            }
        }

        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteVerbose(string.Format("Exporting Solution: {0}", SolutionName));

            using (var organizationService = new CrmOrganisationService(ConnectionString))
            {
                var exporter =
                    new ExportSolution(organizationService)
                    {
                        ExportAutoNumberingSettings = ExportAutoNumberingSettings,
                        ExportCalendarSettings = ExportCalendarSettings,
                        ExportCustomizationSettings = ExportCustomizationSettings,
                        ExportEmailTrackingSettings = ExportEmailTrackingSettings,
                        ExportGeneralSettings = ExportGeneralSettings,
                        ExportIsvConfig = ExportIsvConfig,
                        ExportMarketingSettings = ExportMarketingSettings,
                        ExportOutlookSynchronizationSettings = ExportOutlookSynchronizationSettings,
                        ExportRelationshipRoles = ExportRelationshipRoles
                    };

                var filename = exporter.Export(OutputFolder, SolutionName, Managed);

                WriteObject(filename, false);
            }
                
        }
    }
}
