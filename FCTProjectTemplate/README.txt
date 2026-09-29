---------------------------------------------------------------
FCT Project Template v0.2
---------------------------------------------------------------
Simple class library template for FCT. Includes basic setup, solution configs/transforms, StyleCop and Windsor IoC.

---------------------------------------------------------------
Instructions
---------------------------------------------------------------
1. Place FCTProjectTemplate.zip in: Documents\Visual Studio 2013\Templates\ProjectTemplates\Visual C#
2. Right click on the solution and select Add -> New Project...
3. Under Visual C# choose FCT Project Template
4. Enter a name for your project and click OK
-------------------------
Install NuGet packages
-------------------------
5. Open Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console)
6. Enter the following command: Update-Package -Reinstall -ProjectName [your project name]
-------------------------------------
Add a reference to Framework.Logging
-------------------------------------
7. Right click on References and go to Add Reference...
8. Under Solution -> Projects check Framework.Logging and click OK

9. Right click on the solution and select Rebuild

---------------------------------------------------------------
Changelog
---------------------------------------------------------------

v0.2 - Fixed issue with environment configs, settings were not copied from debug/release
       Added missing StyleCop settings file
       Fixed StyleCop warning for TODO comment
v0.1 - Created initial template