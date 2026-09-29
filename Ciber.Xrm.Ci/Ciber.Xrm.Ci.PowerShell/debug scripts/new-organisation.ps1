$Cred = new-object -typename System.Management.Automation.PSCredential -argumentlist "fctdev\fctmega", ("Pr0j4ct!#" | ConvertTo-SecureString -asPlainText -Force)

Import-Module .\Ciber.Xrm.Ci.PowerShell.dll
New-XrmOrganisation -DeploymentServiceUrl "http://fct-ci-crm-01.cloudapp.net/xrmdeployment/2011/deployment.svc" `
                    -SqlServerName "fct-ci-crm-01.cloudapp.net" `
                    -SsrsUrl "http://fct-ci-crm-01/reportserver" `
                    -SqlCollation "Latin1_General_CI_AI" `
                    -SqmIsEnabled $False `
                    -OrganizationUniqueName "TestIntegrationPS" `
                    -OrganizationFriendlyName "TestIntegrationPS" `
                    -OrganizationBaseCurrencyCode "GBP" `
                    -OrganizationBaseCurrencyName "Pound Sterling" `
                    -OrganizationBaseCurrencyPrecision 2 `
                    -OrganizationBaseCurrencySymbol "£" `
                    -OrganizationBaseLanguageCode 1033 `
                    -SqlUsername "integration_test" `
                    -SqlPassword "Password.1234" `
                    -Credential $Cred `
                    -Verbose `
