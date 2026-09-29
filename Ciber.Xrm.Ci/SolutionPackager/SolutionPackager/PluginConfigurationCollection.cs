// Type: Microsoft.Crm.Tools.SolutionPackager.PluginConfigurationCollection
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Configuration;
    using Plugins;

    public sealed class PluginConfigurationCollection : ConfigurationElementCollection
  {
    public PluginConfigurationCollection()
    {
      BaseAdd(new PluginConfigurationElement("RootComponentValidation", typeof (RootComponentsValidation).AssemblyQualifiedName));
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new PluginConfigurationElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((PluginConfigurationElement) element).Name;
    }
  }
}
