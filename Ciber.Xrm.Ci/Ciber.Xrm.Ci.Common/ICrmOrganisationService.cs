namespace Ciber.Xrm.Ci.Common
{
    using Microsoft.Xrm.Sdk;

    public interface ICrmOrganisationService
    {
        IOrganizationService OrganizationService { get; set; }

        Entity RetrieveSolution(string solutionName);
        
        OrganizationResponse Execute(OrganizationRequest organizationRequest);

        void Update(Entity solutionChanges);
    }
}