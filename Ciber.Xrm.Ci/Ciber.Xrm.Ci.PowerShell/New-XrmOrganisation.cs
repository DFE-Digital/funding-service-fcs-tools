namespace Ciber.Xrm.Ci.PowerShell
{
    using System;
    using System.Management.Automation;
    using System.Net;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using AutoMapper;
    using Common;

    /// <summary>
    /// Represents the PowerShell commandlet implementation for the New-XrmOrganization in the
    /// Ciber toolkit. This is the sibling of the TFS Build activity that achieves the same.
    /// Basically the sole responsability of this class is to expose parameters and handle the
    /// <see cref="IObserver{T}"/> stream and transform events in it into PowerShell writes.
    /// </summary>
    [Cmdlet("New", "XrmOrganisation")]
    public class NewXrmOrganisationCmdlet : Cmdlet
    {
        /// <summary>
        /// Gets or sets the url location of the CRM deployment service.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string DeploymentServiceUrl { get; set; }


        /// <summary>
        /// Gets or sets the name of the SQL server on which the organization database is installed.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string SqlServerName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the Reporting Services that CRM is connected to.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string SsrsUrl { get; set; }

        /// <summary>
        /// Gets or sets the SQL collation property that the organization will use to sort and compare data characters.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string SqlCollation { get; set; }

        /// <summary>
        /// Gets or sets whether information is being collected for the customer experience improvement program.
        /// </summary>
        [Parameter(Mandatory = true)]
        public bool SqmIsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the unique name for the organization.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string OrganizationUniqueName { get; set; }

        /// <summary>
        /// Gets or sets the display name, or long name, of the organization database.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string OrganizationFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the base currency code for the organization.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string OrganizationBaseCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the base currency name for the organization.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string OrganizationBaseCurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places that can be used for the base currency.
        /// </summary>
        [Parameter(Mandatory = false)]
        public int OrganizationBaseCurrencyPrecision { get; set; }

        /// <summary>
        /// Gets or sets the base currency symbol for the organization.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string OrganizationBaseCurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the base language code for the organization.
        /// </summary>
        [Parameter(Mandatory = false)]
        public int OrganizationBaseLanguageCode { get; set; }

        /// <summary>
        /// Gets or sets the username for the Sql user if integrated security is off.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string SqlUsername { get; set; }

        /// <summary>
        /// Gets or sets the password for the Sql user if integrated security is off.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string SqlPassword { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PSCredential"/> identity account to relay to the CRM Deployment service.
        /// </summary>
        [Parameter(Mandatory = false), Credential]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Processes the New-XrmOrganisation commandlet synchronously.
        /// </summary>
        protected override void ProcessRecord()
        {
            Mapper.CreateMap<NewXrmOrganisationCmdlet, XrmOrganisationDeployment>();
            var xrmOrg = Mapper.Map<XrmOrganisationDeployment>(this);

            using (var eventStream = new Subject<BuildEvent>())
            {
                var credential = Credential != null ?
                    Credential.GetNetworkCredential() :
                    CredentialCache.DefaultNetworkCredentials;

                var crmDb = SqlUsername != null && SqlPassword != null ?
                    new CrmDatabase(SqlServerName + ",443", SqlUsername, SqlPassword) :
                    new CrmDatabase(SqlServerName + ",443");
                
                eventStream.Where(e => e.Type == BuildEventType.Information)
                           .Subscribe(e => WriteVerbose(e.Message));

                eventStream.Where(e => e.Type == BuildEventType.Warning)
                           .Subscribe(e => WriteWarning(e.Message));

                eventStream.Where(e => e.Type == BuildEventType.Error)
                           .Subscribe(e => WriteError(new ErrorRecord(new Exception(e.Message), e.Message, ErrorCategory.InvalidOperation, this)));

                eventStream.OfType<ProgressBuildEvent>()
                           .Subscribe(
                               e =>
                               {
                                   WriteVerbose(e.Message);
                                   e.ProgressStream.Subscribe(p => WriteProgress(new ProgressRecord(e.GetHashCode(), e.Message, p.ToString())));
                               });

                try
                {
                    AsyncPump.Run(async delegate { await xrmOrg.Reprovision(eventStream, crmDb, credential); });
                }
                finally
                {
                    crmDb.Dispose();
                }
            }

            base.ProcessRecord();
        }
    }
}
