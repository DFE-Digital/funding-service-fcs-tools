namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.IO;
    using System.Text;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class ExportSolution
    {
        public ICrmOrganisationService OrgService { get; set; }
        public bool ExportAutoNumberingSettings { get; set; }
        public bool ExportCalendarSettings { get; set; }
        public bool ExportCustomizationSettings { get; set; }
        public bool ExportEmailTrackingSettings { get; set; }
        public bool ExportGeneralSettings { get; set; }
        public bool ExportIsvConfig { get; set; }
        public bool ExportMarketingSettings { get; set; }
        public bool ExportOutlookSynchronizationSettings { get; set; }
        public bool ExportRelationshipRoles { get; set; }
        public bool AppendVersionToFileName { get; set; }


        public ExportSolution(ICrmOrganisationService orgService)
        {
            OrgService = orgService;
        }

        public string Export(string outputFolder, string solutionName, bool managed = false )
        {
            var solution = OrgService.RetrieveSolution(solutionName);
            var fileName = BuildSolutionFilename(solutionName, managed, solution);

            var exportSolutionRequest = new ExportSolutionRequest
            {
                Managed = managed,
                SolutionName = solutionName,
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

            var solutionResponse = OrgService.Execute(exportSolutionRequest) as ExportSolutionResponse;

            if (solutionResponse != null)
            {
                File.WriteAllBytes(outputFolder + "\\" + fileName, solutionResponse.ExportSolutionFile);
            }
            else
            {
                throw new InvalidOperationException("Unable to access Solution Response from CRM");
            }

            return fileName;
        }

        private string BuildSolutionFilename(string solutionName, bool managed, Entity solution)
        {
            var solutionVersion = (solution.Contains("version") ? (string)solution.Attributes["version"] : string.Empty);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(solutionName);
            if (AppendVersionToFileName)
            {
                stringBuilder.Append("_");
                stringBuilder.Append(solutionVersion.Replace(".", "_"));
            }
            if (managed)
            {
                stringBuilder.Append("_managed");
            }
            stringBuilder.Append(".zip");
            return stringBuilder.ToString();
        }
    }
}
