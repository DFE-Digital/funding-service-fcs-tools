namespace Ciber.Xrm.Ci.PowerShell
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using System.Xml.Linq;
    using Common;
    using Microsoft.Xrm.Tooling.Connector;
    using Packages;

    [Cmdlet("Import", "XrmSystemData")]

    class ImportXrmSystemData : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string DataFilePath { get; set; }

        [Parameter(Mandatory = true)]
        public string CrmUsername { get; set; }

        [Parameter(Mandatory = true)]
        public string CrmPassword { get; set; }

        [Parameter(Mandatory = true)]
        public string CrmDomain { get; set; }

        [Parameter(Mandatory = true)]
        public string CrmServer { get; set; }

        [Parameter(Mandatory = true)]
        public string CrmPort { get; set; }

        [Parameter(Mandatory = true)]
        public string CrmOrganisationName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteVerbose(string.Format("Importing System Data: {0}", DataFilePath));

            var credential = new NetworkCredential(CrmUsername, CrmPassword, CrmDomain);

            var crmSvc = new CrmServiceClient(
                credential,
                CrmServer,
                CrmPort,
                CrmOrganisationName);

            var xrmImportSystemData = new XrmImportSystemData(crmSvc);

            XDocument datafile = XDocument.Load(DataFilePath);

            try
            {

                WriteVerbose("Load Complete");

                WriteVerbose("Importing Dynamics System Settings");

                if (datafile.Root.Elements("Settings").Count() > 0)
                {
                    xrmImportSystemData.UpdateSystemSettings(datafile.Root.Element("Settings"));
                    xrmImportSystemData.UpdateUserDataFormat(datafile.Root.Element("Settings"));
                }

                WriteVerbose("Importing " + datafile.Root.Element("BusinessUnits").Elements("BusinessUnit").Count().ToString() + " Business Units");
                XElement businessUnitData = datafile.Root.Element("BusinessUnits");
                xrmImportSystemData.ImportBusinessUnits(businessUnitData);

                WriteVerbose("Business Units Complete");

                XElement userData = datafile.Root.Element("SystemUsers");
                WriteVerbose("Importing " + userData.Elements("SystemUser").Count().ToString() + " System Users");
                xrmImportSystemData.ImportUsers(userData);
                WriteVerbose("System Users Complete");

                XElement teamData = datafile.Root.Element("Teams");
                WriteVerbose("Importing " + teamData.Elements("Team").Count().ToString() + " Teams");
                xrmImportSystemData.ImportTeams(teamData);
                WriteVerbose("Teams Complete");

                WriteVerbose("Update " + userData.Elements("SystemUser").Count().ToString() + " System Users");
                xrmImportSystemData.UpdateUsers(userData);
                WriteVerbose("System Users Complete");

                WriteVerbose("Importing " + datafile.Root.Element("Queues").Elements("Queue").Count().ToString() + " Queues");
                XElement queueData = datafile.Root.Element("Queues");

                xrmImportSystemData.ImportQueues(queueData);

                WriteVerbose("Queues Complete");

                WriteVerbose("Deactivating " + datafile.Root.Element("ViewsForDeactivation").Elements("View").Count().ToString() + " System Views");

                XElement systemViewsForDeactivation = datafile.Root.Element("ViewsForDeactivation");

                xrmImportSystemData.DeactivateViews(systemViewsForDeactivation);

                WriteVerbose("Views Complete");

                WriteVerbose("Import Complete");
            }
            catch (Exception ex)
            {
                WriteVerbose("Error While Importing Data File :  " + DataFilePath + ": Error Message: " + ex.Message);
                WriteError(new ErrorRecord(ex,
                    "Import of Dynamics CRM Configuration data failed: " + ex.Message + "\n" + ex.StackTrace,
                    ErrorCategory.InvalidData, xrmImportSystemData));
            }
            WriteVerbose(string.Format("{0} Imported Successfully", DataFilePath));
        }

    }
}
