// Type: Microsoft.Crm.Tools.SolutionPackager.Plugins.RootComponentsValidation
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager.Plugins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;
    using Properties;

    internal sealed class RootComponentsValidation : IPackagePlugin
  {
    private static readonly ComponentType[] RootComponentTypes = new ComponentType[18]
    {
      ComponentType.Entity,
      ComponentType.OptionSet,
      ComponentType.Role,
      ComponentType.SiteMap,
      ComponentType.RibbonCustomization,
      ComponentType.WebResource,
      ComponentType.Workflow,
      ComponentType.PluginAssembly,
      ComponentType.SdkMessageProcessingStep,
      ComponentType.ServiceEndpoint,
      ComponentType.Dashboard,
      ComponentType.Report,
      ComponentType.ConnectionRole,
      ComponentType.Template,
      ComponentType.KbArticleTemplate,
      ComponentType.ContractTemplate,
      ComponentType.MailMergeTemplate,
      ComponentType.FieldSecurityProfile
    };
    private const string SiteMapId = "{d5684797-805b-4188-b8fa-1028cfbef003}";

    static RootComponentsValidation()
    {
    }

    public void BeforeRead(PluginContext pluginContext)
    {
    }

    public void AfterRead(PluginContext pluginContext)
    {
    }

    public void BeforeWrite(PluginContext pluginContext)
    {
      if (pluginContext.Context.Action != CommandAction.Pack)
        return;
      var redundantComponents = new List<ComponentInfo>();
      var rootComponents = GetRootComponents(pluginContext.Context.SolutionInformation);
      foreach (var componentCollection in pluginContext.Context.Customizations.Components)
      {
        if (componentCollection != null && Array.IndexOf(RootComponentTypes, componentCollection.ComponentType) >= 0)
        {
          foreach (var component in componentCollection)
          {
            if (component.ComponentType == ComponentType.Template)
            {
              var componentType = ComponentType.Template;
              var idElementName = "templateid";
              switch (component.Element.Name.LocalName)
              {
                case "ContractTemplates":
                  componentType = ComponentType.ContractTemplate;
                  idElementName = "contracttemplateid";
                  break;
                case "KBArticleTemplates":
                  componentType = ComponentType.KbArticleTemplate;
                  idElementName = "kbarticletemplateid";
                  break;
                case "MailMergeTemplates":
                  componentType = ComponentType.MailMergeTemplate;
                  idElementName = "mailmergetemplateid";
                  break;
              }
              CheckAndRemoveTemplateFromRootComponents(rootComponents, component.Element, idElementName, componentType, redundantComponents);
            }
            else
            {
              var componentInfo = new ComponentInfo(component.Id, component.PrimaryName, component.ComponentType);
              if (!CheckAndRemoveFromRootComponents(rootComponents, componentInfo))
                redundantComponents.Add(componentInfo);
            }
          }
        }
      }
      if (rootComponents.Count <= 0 && redundantComponents.Count <= 0)
        return;
      if (rootComponents.Count > 0)
        Logger.Message(TraceLevel.Warning, Resources.RootComponentsNotInCustomizations, PrintComponentInfos(rootComponents.Values, 2));
      if (redundantComponents.Count <= 0)
        return;
      Logger.Message(TraceLevel.Error, Resources.CustomizationsNotInRootComponents, PrintComponentInfos(redundantComponents, 2));
      throw new PluginExecutionException(Resources.RootComponentValidationFailed);
    }

    public void AfterWrite(PluginContext pluginContext)
    {
    }

    private static bool CheckAndRemoveFromRootComponents(IDictionary<string, ComponentInfo> rootComponents, ComponentInfo componentInfo)
    {
      ComponentInfo componentInfo1;
      if (string.IsNullOrEmpty(componentInfo.Key) || !rootComponents.TryGetValue(componentInfo.Key, out componentInfo1) || componentInfo1.ComponentType != componentInfo.ComponentType)
        return false;
      rootComponents.Remove(componentInfo.Key);
      return true;
    }

    private static void CheckAndRemoveTemplateFromRootComponents(IDictionary<string, ComponentInfo> rootComponents, XElement element, string idElementName, ComponentType componentType, List<ComponentInfo> redundantComponents)
    {
      foreach (var xelement in element.Elements())
      {
        var componentInfo = Helper.IsUnmodifiedComponent(xelement) ? new ComponentInfo(Helper.GetAttributeValue(xelement, "id", true, Helper.GuidConverter, new Guid()), null, componentType) : new ComponentInfo(Helper.GetElementValue(xelement, idElementName, true, Helper.GuidConverter, new Guid()), null, componentType);
        if (!CheckAndRemoveFromRootComponents(rootComponents, componentInfo))
          redundantComponents.Add(componentInfo);
      }
    }

    private static IDictionary<string, ComponentInfo> GetRootComponents(SolutionInformation solution)
    {
      var dictionary = new Dictionary<string, ComponentInfo>();
      foreach (var element in solution.SolutionXDocument.Root.Elements("SolutionManifest").Elements("RootComponents").Elements("RootComponent"))
      {
        var attributeValue1 = Helper.GetAttributeValue(element, "type", true, null);
        int result;
        if (!int.TryParse(attributeValue1, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
        {
          throw new PluginExecutionException(string.Format(CultureInfo.InvariantCulture, Resources.InvalidComponentType, attributeValue1));
        }
          var attributeValue2 = Helper.GetAttributeValue(element, "id", false, Helper.GuidConverter, new Guid());
          var attributeValue3 = Helper.GetAttributeValue(element, "schemaName", false, null);
          if (attributeValue2 == Guid.Empty && string.IsNullOrWhiteSpace(attributeValue3))
              attributeValue2 = Helper.GetAttributeValue(element, "parentId", false, Helper.GuidConverter, new Guid());
          var componentInfo = new ComponentInfo(attributeValue2, attributeValue3, (ComponentType) result);
          dictionary.Add(componentInfo.Key, componentInfo);
      }
      return dictionary;
    }

    private static string PrintComponentInfos(IEnumerable<ComponentInfo> componentInfos, int indention)
    {
      var stringBuilder = new StringBuilder();
      foreach (var componentInfo in componentInfos)
      {
        stringBuilder.Append(' ', indention);
        stringBuilder.AppendFormat("Type='{0}', Id (or schema name)='{1}'.", componentInfo.ComponentType, componentInfo.Key);
        stringBuilder.AppendLine();
      }
      return stringBuilder.ToString();
    }

    private class ComponentInfo
    {
      public ComponentType ComponentType { get; private set; }

      public string Key { get; private set; }

      public ComponentInfo(Guid id, string primaryName, ComponentType componentType)
      {
        var str = primaryName;
        if (componentType == ComponentType.Entity && !string.IsNullOrEmpty(primaryName))
          str = primaryName.ToLowerInvariant();
        else if (componentType == ComponentType.SiteMap)
          str = "{d5684797-805b-4188-b8fa-1028cfbef003}";
        Key = !(id != Guid.Empty) || componentType == ComponentType.WebResource ? ((object) componentType) + "-" + str : id.ToString("b");
        ComponentType = componentType;
      }
    }
  }
}
