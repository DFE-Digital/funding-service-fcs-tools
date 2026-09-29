// Type: Microsoft.Crm.Tools.SolutionPackager.DashboardProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class DashboardProcessor : ComponentProcessorBase
  {
    public DashboardProcessor()
      : base("Dashboards", ComponentType.Dashboard)
    {
      IsCollectionComponent = true;
      LocableElementXPaths.Add(new LocalizableElementXPath("//Dashboard/LocalizedNames/LocalizedName", "description", "languagecode", "Dashboard/FormId", "'DashBoard'"));
      LocableElementXPaths.Add(new LocalizableElementXPath("//Dashboard/Descriptions/Description", "description", "languagecode", "Dashboard/FormId", "'DashBoard'"));
      LocableElementXPaths.Add(new LocalizableElementXPath("//Dashboard/labels/label", "description", "languagecode", "Dashboard/FormId+../..@id", "'DashBoard'"));
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.Dashboard,
        PrimaryName = Helper.GetElementValue(element, "FormId", true, null),
        Id = Helper.GetElementValue(element, "FormId", false, Helper.GuidConverter, new Guid()),
        Element = element
      };
    }
  }
}
