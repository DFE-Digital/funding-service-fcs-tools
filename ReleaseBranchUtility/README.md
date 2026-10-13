# Introduction 
The ReleaseCandidateApp is intended to automate the process of creating a new release 
branch once a release candidate commit has been decided upon.

# Usage
The binary for this application should be downloaded from artefacts on the latest good build.  It
is packaged as a single exe file with all required libraries included.  

To use the application run it with -? which will display the function and command
line options.  The help text details what the application does.

# Getting Started
Updating the application is easy as there really is only one file.  The .NET libraries for 
Azure DevOps are just a thin wrapper on top of the [Azure DevOps REST API](https://docs.microsoft.com/en-us/rest/api/azure/devops).


# Build and Test
The application is built using the [YAML Build File](azure-pipelines.yml) which
is run as [this project build](https://dev.azure.com/sfa-fcs/FCT/_build?definitionId=446)

Feel free to add some tests which will be run as part of the build.

# Contribute
Just Do It!