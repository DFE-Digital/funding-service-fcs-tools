// Type: Microsoft.Crm.Tools.SolutionPackager.ConnectionRoleProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class ConnectionRoleProcessor : ComponentProcessorBase
  {
    public ConnectionRoleProcessor()
      : base("ConnectionRoles", ComponentType.ConnectionRole)
    {
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.ConnectionRole,
        Id = Helper.GetElementValue(element, "connectionroleid", true, Helper.GuidConverter, new Guid()),
        Element = element
      };
    }

    protected override IEnumerable<XElement> GetComponentElements(XElement componentCollectionElement)
    {
      return componentCollectionElement.Element("ConnectionRoles").Elements();
    }
  }
}
