// Type: Microsoft.Crm.Tools.SolutionPackager.OptionSetProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class OptionSetProcessor : ComponentProcessorBase
  {
    public OptionSetProcessor()
      : base("optionsets", ComponentType.OptionSet)
    {
      IsCollectionComponent = true;
      LocableElementXPaths.Add(new LocalizableElementXPath("//optionset/displaynames/displayname", "description", "languagecode", "optionset@Name", "'{optionset@Name}' : {.} for OptionSet"));
      LocableElementXPaths.Add(new LocalizableElementXPath("//optionset/Descriptions/Description", "description", "languagecode", "optionset@Name", "'{optionset@Name}' : {.} for OptionSet"));
      LocableElementXPaths.Add(new LocalizableElementXPath("//optionset/options/option/labels/label", "description", "languagecode", "optionset@Name+../..@value", "'{optionset@Name}' : {.} for OptionSet Value '{../..@value}'"));
      LocableElementXPaths.Add(new LocalizableElementXPath("//optionset/options/option/Descriptions/Description", "description", "languagecode", "optionset@Name+../..@value", "'{optionset@Name}' : {.} for OptionSet Value '{../..@value}'"));
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.OptionSet,
        PrimaryName = Helper.GetAttributeValue(element, "Name", true, null),
        Element = element
      };
    }

    public override Collection<LocalizableElement> GetLocalizableElements(ComponentCollection components)
    {
      if (context.Action == CommandAction.Extract)
      {
        foreach (var localizableElementXpath in LocableElementXPaths)
          localizableElementXpath.XPath = localizableElementXpath.XPath.Insert(2, "optionsets/");
      }
      return base.GetLocalizableElements(components);
    }
  }
}
