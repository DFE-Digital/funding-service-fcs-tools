namespace Ciber.Xrm.Ci.Common
{
    using Microsoft.Xrm.Sdk;

    public class UpdateSolution
    {
        public ICrmOrganisationService OrgService { get; set; }

        public UpdateSolution(ICrmOrganisationService orgService)
        {
            OrgService = orgService;
        }

        public void Update(string solutionName, string version)
        {
            var solution = OrgService.RetrieveSolution(solutionName);

            var solutionChanges = new Entity("solution") {Id = solution.Id};
            solutionChanges.Attributes.Add("version", version);
            OrgService.Update(solutionChanges);
        }
    }
}
