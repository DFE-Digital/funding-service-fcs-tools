// Type: Microsoft.Crm.Tools.SolutionPackager.ComponentConfigurationCollection
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Configuration;

    public sealed class ComponentConfigurationCollection : ConfigurationElementCollection
  {
    public ComponentConfigurationCollection()
    {
      BaseAdd(new ComponentConfigurationElement(ComponentType.Entity, "Entities", "$(PrimaryName)\\Entity.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.OptionSet, "OptionSets", "$(PrimaryName)"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.EntityRelationship, "Other", "Relationships.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.SiteMap, "Other", "$(type)$(managed).xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.RibbonCustomization, "Other", "$(type).xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.Role, "Roles", "$(PrimaryName)"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.ConnectionRole, "Other", "$(type)s.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.Dashboard, "Dashboards", "$(PrimaryName)"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.FieldSecurityProfile, "Other", "$(type)s.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.WebResource, "WebResources", "$(PrimaryName)"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.Workflow, "Workflows", "Workflows.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.PluginAssembly, "PluginAssemblies", "PluginAssemblies.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.SdkMessageProcessingStep, "SdkMessageProcessingSteps", "$(PrimaryName)"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.ServiceEndpoint, "PluginAssemblies", "$(type)s.xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.Report, "Reports", "$(type)"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.Template, "Templates", "$(PrimaryName).xml"));
      BaseAdd(new ComponentConfigurationElement(ComponentType.EntityMap, "Other", "$(type)s.xml"));
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new ComponentConfigurationElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((ComponentConfigurationElement) element).ComponentType;
    }
  }
}
