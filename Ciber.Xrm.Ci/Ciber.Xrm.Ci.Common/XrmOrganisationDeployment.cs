namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using Microsoft.Xrm.Sdk.Deployment;
    using Microsoft.Xrm.Sdk.Deployment.Proxy;

    public class XrmOrganisationDeployment
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
        /// Gets or sets the URL of the Reporting Services that CRM is connected to.
        /// </summary>
        public string SsrsUrl { get; set; }

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
        /// Reprovisions the Xrm Organisation by dropping the database and re-creating the organisation
        /// </summary>
        /// <param name="eventStream">The Build Event stream</param>
        /// <param name="crmDb">An object representing the CRM Database</param>
        /// <param name="credential">The Network Credential to use on the CRM deployment client.</param>
        /// <returns>The async <see cref="Task"/> unit of work.</returns>
        public async Task Reprovision(IObserver<BuildEvent> eventStream, CrmDatabase crmDb, NetworkCredential credential)
        {
            using (var client = ProxyClientHelper.CreateClient(new Uri(DeploymentServiceUrl)))
            {
                if (client.ClientCredentials != null)
                {
                    client.ClientCredentials.Windows.ClientCredential = credential;
                }

                var crmDatabaseName = OrganizationUniqueName + "_MSCRM";

                try
                {
                    if (await client.OrganizationExists(OrganizationUniqueName))
                    {
                        await client.DisableOrganizationAsync(OrganizationUniqueName, eventStream);
                        await client.DeleteOrganizationAsync(OrganizationUniqueName, eventStream);
                    }
                    else
                    {
                        eventStream.OnNext(new BuildEvent(
                            BuildEventType.Warning,
                            BuildEventImportance.Medium,
                            string.Format("The Organization {0} doesn't exist in the CRM server. Is this intentional?", OrganizationUniqueName)));
                    }

                    if (await crmDb.DatabaseExists(crmDatabaseName))
                    {
                        await crmDb.DropDatabaseAsync(crmDatabaseName, eventStream);
                    }
                    else
                    {
                        eventStream.OnNext(new BuildEvent(
                            BuildEventType.Warning,
                            BuildEventImportance.Medium,
                            string.Format("The Organization Database {0} doesn't exist in the SQL Server. Is this intentional?", crmDatabaseName)));
                    }

                    await client.CreateOrganizationAsync(
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
                            SrsUrl = SsrsUrl,
                            SqmIsEnabled = SqmIsEnabled
                        },
                        eventStream);
                }
                catch (AggregateException ex)
                {
                    var fault = ex.InnerExceptions.First() as FaultException<DeploymentServiceFault>;
                    if (fault == null) throw ex.InnerExceptions.First();

                    dynamic clunkyCast = fault.Detail.ErrorDetails;
                    foreach (KeyValuePair<string, object> p in clunkyCast)
                    {
                        eventStream.OnNext(new BuildEvent(
                            BuildEventType.Error,
                            BuildEventImportance.High,
                            string.Format("{0} : {1}", p.Key, p.Value)));
                    }
                }
            }
        }
    }
}
