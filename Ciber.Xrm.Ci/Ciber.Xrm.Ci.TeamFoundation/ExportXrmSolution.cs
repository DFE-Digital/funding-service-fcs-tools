namespace Ciber.Xrm.Ci.TeamFoundation
{
    using System.Activities;
    using System.ComponentModel;
    using Common;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.Xrm.Client;

    [BuildActivity(HostEnvironmentOption.Agent)]
    public sealed class ExportXrmSolution : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> CrmConnectionString { get; set; }

        [RequiredArgument]
        public InArgument<string> UniqueSolutionName { get; set; }

        [RequiredArgument]
        public InArgument<string> OutputFolder { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> Managed { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportAutoNumberingSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportCalendarSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportCustomizationSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportEmailTrackingSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportGeneralSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportIsvConfig { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportMarketingSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportOutlookSynchronizationSettings { get; set; }

        [DefaultValue(false)]
        public InArgument<bool> ExportRelationshipRoles { get; set; }

        public OutArgument<string> OutputFile { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (var organizationService = new CrmOrganisationService(CrmConnectionString.Get(context)))
            {
                var exportSolution =
                    new ExportSolution(organizationService)
                    {
                        ExportAutoNumberingSettings = ExportAutoNumberingSettings.Get(context),
                        ExportCalendarSettings = ExportCalendarSettings.Get(context),
                        ExportCustomizationSettings = ExportCustomizationSettings.Get(context),
                        ExportEmailTrackingSettings = ExportEmailTrackingSettings.Get(context),
                        ExportGeneralSettings = ExportGeneralSettings.Get(context),
                        ExportIsvConfig = ExportIsvConfig.Get(context),
                        ExportMarketingSettings = ExportMarketingSettings.Get(context),
                        ExportOutlookSynchronizationSettings = ExportOutlookSynchronizationSettings.Get(context),
                        ExportRelationshipRoles = ExportRelationshipRoles.Get(context)
                    };

                var result = exportSolution.Export(
                    OutputFolder.Get(context),
                    UniqueSolutionName.Get(context),
                    Managed.Get(context));
                
                OutputFile.Set(context, result);
            }
        }
    }
}