// Type: Microsoft.Crm.Tools.SolutionPackager.FieldSecurityProfileProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.ComponentModel.Composition;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class FieldSecurityProfileProcessor : ComponentProcessorBase
  {
    public FieldSecurityProfileProcessor()
      : base("FieldSecurityProfiles", ComponentType.FieldSecurityProfile)
    {
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.FieldSecurityProfile,
        PrimaryName = Helper.GetAttributeValue(element, "name", true, null),
        Id = Helper.GetAttributeValue(element, "fieldsecurityprofileid", false, Helper.GuidConverter, new Guid()),
        Element = element
      };
    }
  }
}
