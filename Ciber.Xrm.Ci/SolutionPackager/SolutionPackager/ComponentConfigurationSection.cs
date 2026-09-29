// Type: Microsoft.Crm.Tools.SolutionPackager.ComponentConfigurationSection
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Configuration;

    public sealed class ComponentConfigurationSection : ConfigurationSection
  {
    [ConfigurationProperty("customizations", DefaultValue = "Other\\Customizations.xml")]
    public string CustomizationsFile
    {
      get
      {
        return (string) this["customizations"];
      }
      set
      {
        this["customizations"] = value;
      }
    }

    [ConfigurationProperty("solution", DefaultValue = "Other\\Solution.xml")]
    public string SolutionFile
    {
      get
      {
        return (string) this["solution"];
      }
      set
      {
        this["solution"] = value;
      }
    }

    [ConfigurationProperty("components")]
    public ComponentConfigurationCollection Configurations
    {
      get
      {
        return (ComponentConfigurationCollection) this["components"];
      }
    }

    [ConfigurationProperty("plugins")]
    public PluginConfigurationCollection Plugins
    {
      get
      {
        return (PluginConfigurationCollection) this["plugins"];
      }
    }
  }
}
