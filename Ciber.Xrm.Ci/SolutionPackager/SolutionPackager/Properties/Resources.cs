// Type: Microsoft.Crm.Tools.SolutionPackager.Properties.Resources
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager.Properties
{
  internal static class Resources
  {
    internal static string CustomizationsNotInRootComponents
    {
      get
      {
        return "Following objects, required by the solution, are not present. /n/r{0}/n/r Please do a dependency check on your solution prior to exporting, add the missing objects to your solution and re-export/n/r";
      }
    }

    internal static string DuplicatedRelationshipName
    {
      get
      {
        return "Entity relationship name '{0}' already exists.";
      }
    }

    internal static string DuplicatedTemplates
    {
      get
      {
        return "There're more than 1 {0} in directory '{1}'.";
      }
    }

    internal static string FailedToCreatePluginInstance
    {
      get
      {
        return "Failed to create plugin instance. '{0}' doesn't implement '{1}'.";
      }
    }

    internal static string InvalidComponentType
    {
      get
      {
        return "Invalid component type '{0}'. Component type should be an integer.";
      }
    }

    internal static string MissingRequiredFile
    {
      get
      {
        return "Cannot find required file '{0}'.";
      }
    }

    internal static string RootComponentsNotInCustomizations
    {
      get
      {
        return "Following root components are not defined in customizations:\r\n{0}";
      }
    }

    internal static string RootComponentValidationFailed
    {
      get
      {
        return "RootComponent validation failed.";
      }
    }

    internal static string UnknownRelationType
    {
      get
      {
        return "Unknown entity relationship type: '{0}'.";
      }
    }

    internal static string UnknownTemplate
    {
      get
      {
        return "Unknown template '{0}' found in '{1}', ignored.";
      }
    }
  }
}
