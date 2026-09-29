// Type: Microsoft.Crm.Tools.SolutionPackager.RibbonCustomizationProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class RibbonCustomizationProcessor : ComponentProcessorBase
  {
    public RibbonCustomizationProcessor()
      : base("RibbonDiffXml", ComponentType.RibbonCustomization)
    {
      IsSingleComponentElement = true;
      LocableElementXPaths.Add(new LocalizableElementXPath("/RibbonDiffXml/LocLabels/LocLabel/Titles/Title", "description", "languagecode", "LocLabel@Id", "{.} for Ribbon LocLabel '{LocLabel@Id}'"));
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.RibbonCustomization,
        PrimaryName = ":RibbonDiffXml",
        Element = element
      };
    }
  }
}
