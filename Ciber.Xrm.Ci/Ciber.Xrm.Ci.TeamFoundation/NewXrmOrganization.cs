namespace Ciber.Xrm.Ci.TeamFoundation
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.ServiceModel;
    using Common;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Build.Workflow.Activities;
    using Microsoft.Xrm.Sdk.Deployment;
    using Microsoft.Xrm.Sdk.Deployment.Proxy;

    /// <summary>
    /// This TFS Build <see cref="CodeActivity"/> takes care of a CRM deployment.
    /// It can teardown the entire Organization and re-created if required before deploying the package.
    /// </summary>
    [BuildActivity(HostEnvironmentOption.All)]
    public class NewXrmOrganization : CodeActivity
    {
        /// <summary>
        /// Gets or sets the url location of the CRM deployment service.
        /// </summary>
        public string DeploymentServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the SQL server on which the organization database is installed.
        /// </summary>
        public string SqlServerName { get; set; }

        /// <summary>
        /// Gets or sets the URL of the pn_MS_SQL_Server on which the pn_Connector_for_SRS_short is installed.
        /// </summary>
        public string SrsUrl { get; set; }

        /// <summary>
        /// Gets or sets the SQL collation property that the organization will use to sort and compare data characters.
        /// </summary>
        public string SqlCollation { get; set; }

        /// <summary>
        /// Gets or sets whether information is being collected for the customer experience improvement program.
        /// </summary>
        public bool SqmIsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the unique name for the organization.
        /// </summary>
        public string OrganizationUniqueName { get; set; }

        /// <summary>
        /// Gets or sets the display name, or long name, of the organization database.
        /// </summary>
        public string OrganizationFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the base currency code for the organization.
        /// </summary>
        public string OrganizationBaseCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the base currency name for the organization.
        /// </summary>
        public string OrganizationBaseCurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places that can be used for the base currency.
        /// </summary>
        public int OrganizationBaseCurrencyPrecision { get; set; }

        /// <summary>
        /// Gets or sets the base currency symbol for the organization.
        /// </summary>
        public string OrganizationBaseCurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the base language code for the organization.
        /// </summary>
        public int OrganizationBaseLanguageCode { get; set; }

        /// <summary>
        /// Performs the execution of the activity.
        /// </summary>
        /// <param name="context">The execution context under which the activity executes.</param>
        protected override void Execute(CodeActivityContext context)
        {
            using (var eventStream = new Subject<BuildEvent>())
            using (var client = ProxyClientHelper.CreateClient(new Uri(DeploymentServiceUrl)))
            using (var crmDb = new CrmDatabase(SqlServerName))
            {
                var crmDatabaseName = OrganizationUniqueName + "_MSCRM";

                eventStream.Where(e => e.Type == BuildEventType.Information)
                           .Subscribe(e => context.TrackBuildMessage(e.Message, e.Importance.ToBuildMessageImportance()));

                try
                {
                    if (client.OrganizationExists(OrganizationUniqueName).Result)
                    {
                        client.DisableOrganizationAsync(OrganizationUniqueName, eventStream).Wait();
                        client.DeleteOrganizationAsync(OrganizationUniqueName, eventStream).Wait();
                    }
                    else
                    {
                        context.TrackBuildWarning(string.Format("The Organization {0} doesn't exist in the CRM server. Is this intentional?", OrganizationUniqueName));
                    }

                    if (crmDb.DatabaseExists(crmDatabaseName).Result)
                    {
                        crmDb.DropDatabaseAsync(crmDatabaseName, eventStream).Wait();
                    }
                    else
                    {
                        context.TrackBuildWarning(string.Format("The Organization Database {0} doesn't exist in the SQL Server. Is this intentional?", crmDatabaseName));
                    }

                    client.CreateOrganizationAsync(
                        new Organization
                        {
                            BaseCurrencyCode = OrganizationBaseCurrencyCode,
                            BaseCurrencyName = OrganizationBaseCurrencyName,
                            BaseCurrencyPrecision = OrganizationBaseCurrencyPrecision,
                            BaseCurrencySymbol = OrganizationBaseCurrencySymbol,
                            BaseLanguageCode = OrganizationBaseLanguageCode,
                            UniqueName = OrganizationUniqueName,
                            FriendlyName = OrganizationFriendlyName,
                            SqlCollation = SqlCollation,
                            SqlServerName = SqlServerName,
                            SrsUrl = SrsUrl,
                            SqmIsEnabled = SqmIsEnabled
                        },
                        eventStream).Wait();
                }
                catch (AggregateException ex)
                {
                    var fault = ex.InnerExceptions.First() as FaultException<DeploymentServiceFault>;
                    if (fault == null) throw ex.InnerExceptions.First();

                    dynamic clunkyCast = fault.Detail.ErrorDetails;
                    foreach (KeyValuePair<string, object> p in clunkyCast)
                    {
                        context.TrackBuildError(p.Key + "  " + p.Value);
                    }
                }
            }
        }
    }
}
