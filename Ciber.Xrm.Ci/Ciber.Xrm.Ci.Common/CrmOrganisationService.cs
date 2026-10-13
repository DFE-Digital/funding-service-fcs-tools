namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.ServiceModel;
    using Microsoft.Xrm.Client;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public class CrmOrganisationService : IDisposable, ICrmOrganisationService
    {
        public CrmOrganisationService(string connectionString)
        {
            CrmConnection connection = null;

            try
            {
                connection = CrmConnection.Parse(connectionString);

            }
            catch (Exception ex)
            {
                throw new Exception("Could not parse Crm Connection String: " + ex.Message);
            }

            OrganizationService = new OrganizationService(connection);
        }

        public IOrganizationService OrganizationService { get; set; }

        public Entity RetrieveSolution(string solutionName)
        {
            var query = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet(true)
            };
            query.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionName);

            var solution = OrganizationService.RetrieveMultiple(query).Entities.FirstOrDefault();
            if (solution == null)
                throw new Exception(string.Format("Solution {0} could not be found", solutionName));
            return solution;
        }

        public OrganizationResponse Execute(OrganizationRequest organizationRequest)
        {
            return OrganizationService.Execute(organizationRequest);
        }

        public void Update(Entity entityToUpdate)
        {
            OrganizationService.Update(entityToUpdate);
        }

        /// <summary>
        /// Defines a method to release allocated resources.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Defines a method to release allocated resources.
        /// </summary>
        /// <param name="disposing">If we are already disposing or not.</param>
        [ExcludeFromCodeCoverage]
        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (OrganizationService is OrganizationService)
            {
                (OrganizationService as OrganizationService).Dispose();
            }
        }
    }
}
