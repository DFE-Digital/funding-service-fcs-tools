// Type: Microsoft.Crm.Tools.SolutionPackager.EntityMapProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class EntityMapProcessor : ComponentProcessorBase
  {
    public EntityMapProcessor()
      : base("EntityMaps", ComponentType.EntityMap)
    {
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.EntityMap,
        PrimaryName = string.Format(CultureInfo.InvariantCulture, "{0},{1}", Helper.GetElementValue(element, "EntitySource", true, null), Helper.GetElementValue(element, "EntityTarget", true, null)),
        Element = element
      };
    }
  }
}
