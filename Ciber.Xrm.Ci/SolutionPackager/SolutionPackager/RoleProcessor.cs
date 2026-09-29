// Type: Microsoft.Crm.Tools.SolutionPackager.RoleProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class RoleProcessor : ComponentProcessorBase
  {
    public RoleProcessor()
      : base("Roles", ComponentType.Role)
    {
      IsCollectionComponent = true;
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.Role,
        Id = Helper.GetAttributeValue(element, "id", false, Helper.GuidConverter, new Guid()),
        PrimaryName = Helper.GetAttributeValue(element, "name", false, null),
        Element = element
      };
    }
  }
}
