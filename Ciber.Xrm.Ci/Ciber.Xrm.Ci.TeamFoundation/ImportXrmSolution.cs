namespace Ciber.Xrm.Ci.TeamFoundation
{
    using System.Activities;
    using Common;
    using Microsoft.TeamFoundation.Build.Client;

    [BuildActivity(HostEnvironmentOption.Agent)]
    public sealed class ImportXrmSolution : CodeActivity
    {
        private const int AsyncWaitTimeout = 900;

        [RequiredArgument]
        public InArgument<string> ConnectionString { get; set; }

        [RequiredArgument]
        public InArgument<string> SolutionFilePath { get; set; }

        public InArgument<bool> PublishWorkflows { get; set; }

        public InArgument<bool> ConvertToManaged { get; set; }

        public InArgument<bool> OverwriteUnmanagedCustomizations { get; set; } 

        protected override void Execute(CodeActivityContext context)
        {
            var connectionString = ConnectionString.Get(context);

            using (var organizationService = new CrmOrganisationService(connectionString))
            {
                var asyncJobManager = new CrmAsyncJobManager(organizationService);

                new ImportSolution(organizationService, asyncJobManager)
                    .Import(SolutionFilePath.Get(context),
                        PublishWorkflows.Get(context),
                        ConvertToManaged.Get(context),
                        OverwriteUnmanagedCustomizations.Get(context),
                        false,
                        true,
                        AsyncWaitTimeout);
            }
        }
    }
}
