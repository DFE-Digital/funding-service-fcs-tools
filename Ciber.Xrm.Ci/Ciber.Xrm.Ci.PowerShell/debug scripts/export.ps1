Import-Module ..\Ciber.Xrm.Ci.PowerShell.dll
Export-XrmSolution -ConnectionString "Url=http://kelletts.dyndns.org/aibpocdev; Domain=dev1; Username=administrator; Password=" -SolutionName AibProofOfConcept -OutputFolder C:\Temp\
Expand-XrmSolution -SolutionFile c:\temp\AibProofOfConcept.zip -OutputFolder C:\Temp\AibProofOfConcept\