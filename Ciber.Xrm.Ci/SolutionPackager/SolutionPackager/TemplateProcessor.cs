// Type: Microsoft.Crm.Tools.SolutionPackager.TemplateProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.IO;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class TemplateProcessor : ComponentProcessorBase
  {
    private static readonly string[] SubTemplates = new string[4]
    {
      "KBArticleTemplates",
      "EmailTemplates",
      "ContractTemplates",
      "MailMergeTemplates"
    };
    private readonly Dictionary<string, ISubComponentProcessor> _subTemplateProcessors = new Dictionary<string, ISubComponentProcessor>();

    internal Context Context
    {
      get
      {
        return context;
      }
    }

    static TemplateProcessor()
    {
    }

    public TemplateProcessor()
      : base("Templates", ComponentType.Template)
    {
      IsWriteIndividualComponent = true;
      _subTemplateProcessors.Add("KBArticleTemplates", new KbArticleTemplateProcessor(this));
      _subTemplateProcessors.Add("EmailTemplates", new EmailTemplateProcessor(this));
      _subTemplateProcessors.Add("MailMergeTemplates", new MailMergeTemplateProcessor(this));
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.Template,
        PrimaryName = element.Name.LocalName,
        Element = element
      };
    }

    public override void WriteToFiles(ComponentCollection components)
    {
      foreach (var component in components)
      {
        ShowProcessing(component);
        var componentPath = GetComponentPath(component);
        ISubComponentProcessor componentProcessor;
        if (_subTemplateProcessors.TryGetValue(component.Element.Name.LocalName, out componentProcessor) && componentProcessor != null)
          componentProcessor.WriteToFiles(component.Element, componentPath);
        else
          Helper.WriteToFile(componentPath, component.Element);
      }
    }

    public override ComponentCollection ReadFromFiles()
    {
      var mainDirectory = GetMainDirectory(SupportedComponentType);
      var element = new XElement(SupportedElementName);
      if (Directory.Exists(mainDirectory))
      {
        foreach (var str1 in SubTemplates)
        {
          var str2 = Path.Combine(mainDirectory, Path.ChangeExtension(str1, ".xml"));
          if (File.Exists(str2))
          {
            Logger.Message(TraceLevel.Verbose, "Reading: {0}", str2);
            var componentElement = XElement.Load(str2);
            ISubComponentProcessor componentProcessor;
            if (_subTemplateProcessors.TryGetValue(str1, out componentProcessor) && componentProcessor != null)
              componentProcessor.ReadFromFiles(componentElement, str2);
            element.Add(componentElement);
          }
        }
      }
      return CreateComponents(element);
    }
  }
}
