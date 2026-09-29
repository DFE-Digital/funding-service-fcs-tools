// Type: Microsoft.Crm.Tools.SolutionPackager.SiteMapProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class SiteMapProcessor : ComponentProcessorBase
  {
    public SiteMapProcessor()
      : base("SiteMap", ComponentType.SiteMap)
    {
      IsDifferentInManaged = true;
      var commentFormula = "{.} for Area '{Area@Id}' {../../.} '{../..@Id}'";
      LocableElementXPaths.Add(new LocalizableElementXPath("//SiteMap//Title", "Title", "LCID", "Area@Id+../..@Id", commentFormula));
      LocableElementXPaths.Add(new LocalizableElementXPath("//SiteMap//Description", "Description", "LCID", "Area@Id+../..@Id", commentFormula));
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.SiteMap,
        PrimaryName = "SiteMap",
        Element = element
      };
    }

    protected override bool NeedManagedFilename(XElement item)
    {
      return true;
    }
  }
}
