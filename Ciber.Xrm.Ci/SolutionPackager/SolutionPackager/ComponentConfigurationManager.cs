// Type: Microsoft.Crm.Tools.SolutionPackager.ComponentConfigurationManager
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Collections.Generic;
    using System.Configuration;

    public sealed class ComponentConfigurationManager
  {
    private readonly Dictionary<ComponentType, ComponentConfigurationElement> _configurationDictionary;
    private readonly ComponentConfigurationSection _configurationSection;

    public ComponentConfigurationSection ConfigurationSection
    {
      get
      {
        return _configurationSection;
      }
    }

    public ComponentConfigurationManager()
    {
      _configurationDictionary = new Dictionary<ComponentType, ComponentConfigurationElement>();
      var configurationSection = ConfigurationManager.GetSection("ComponentConfigurations") as ComponentConfigurationSection ?? new ComponentConfigurationSection();
      foreach (ComponentConfigurationElement configurationElement in configurationSection.Configurations)
        _configurationDictionary.Add(configurationElement.ComponentType, configurationElement);
      _configurationSection = configurationSection;
    }

    public ComponentConfigurationElement GetConfiguration(ComponentType type)
    {
      ComponentConfigurationElement configurationElement;
      _configurationDictionary.TryGetValue(type, out configurationElement);
      return configurationElement;
    }
  }
}
