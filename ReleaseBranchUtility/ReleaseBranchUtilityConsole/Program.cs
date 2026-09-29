using System;
using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ReleaseBranchUtilityLib;

namespace ReleaseBranchUtilityConsole
{
    [Command(ExtendedHelpText = @"
Release Branch Creation Utility, this utility:

  1:  Looks for an existing branch of the same name and fails if it exists unless -f|--force is specified

  2:  Creates a branch if it doesn't exist using the commit as its branch point - only uses release number, not release letter

  3:  Discovers all of the build pipeline definitions whose name conforms to ""^RB[0-9]+[a-z]?[\s]+(.*)$"" and
      a) updates source branch to the new branch, and 
      b) renames the defintion to use the new branch number/letter

  4:  Finds all Backlog Items tagged with the release number and (optional) release letter and 
      updates the Release Notes wiki page prepending existing contents with release header and list of Backlog Items in @nnnnn format

  5:  Exits reporting success (return code 0) or failure (return code > 0)

Any issues will be reported however all actions prior to the failing step will have been completed and not reverted.
This utility is designed to be idempotent and so rerunning after a failure will not cause issues but should 
pick up where it failed.
")]
    class Program
    {

        [Option(Description = "[Mandatory] The new release number, forms the base of the release branch name", ShortName = "n", LongName = "releasenumber", ShowInHelpText = true)]
        [Required]
        public int ReleaseNumber { get; }

        [Option("-l|--releaseLetter <RELEASE_LETTER>", "[Optional] Release letter", CommandOptionType.SingleValue)]
        [Range(typeof(string), "a", "z")]
        [MaxLength(1)]
        public string ReleaseLetter { get; }

        [Option(Description = "[Optional] Full commit id (40 character) from which to take the branch", ShortName = "c", LongName = "commit", ShowInHelpText = true)]
        public string CommitId { get; }

        [Option(Description = "[Optional] Force the update of builds and release notes even if the branch already exists", ShortName = "f", LongName = "force", ShowInHelpText = true)]
        public bool Force { get; }

        [Option(Description = "[Optional] The Uri for the Azure Devops organsiation, defaults to \"https://dev.azure.com/sfa-fcs\"", ShortName ="u", LongName = "uri", ShowInHelpText = true )]
        public string CollectionUri { get; } = "https://dev.azure.com/sfa-fcs";

        [Option(Description = "[Optional] The project within the Azure Devops organisation, defaults to \"FCT\"", ShortName = "p", LongName ="project", ShowInHelpText = true)]
        public string ProjectName { get; } = "FCT";
          
        [Option(Description = "[Optional] The name of the repo to act on, defaults to \"FCS\"", ShortName = "r", LongName = "repo", ShowInHelpText = true)]
        public string RepoName { get; } = "FCS";


        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);


        /// <summary>
        /// This method is called by the CommandLineApplication package after setting the properties from the command line arguments
        /// </summary>
        private int OnExecute()
        {
            var infoVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Log($"Release Candidate App Version: {infoVersion.InformationalVersion}");

            int returnCode = ReleaseBranchAdder.Execute(CollectionUri, ProjectName, RepoName, CommitId, ReleaseNumber, ReleaseLetter?[0], Force, Log);
            
            if (returnCode == 0) Log("All done successfully");

            return returnCode;

        }

        private static void Log(string logLine)
        {
            Console.WriteLine($"{DateTime.Now.TimeOfDay} : {logLine}");
        }

    }
}
