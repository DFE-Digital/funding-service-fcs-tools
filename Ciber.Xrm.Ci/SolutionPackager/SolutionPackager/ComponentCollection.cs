// Type: Microsoft.Crm.Tools.SolutionPackager.ComponentCollection
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Collections.ObjectModel;
    using System.Xml.Linq;

    public sealed class ComponentCollection : Collection<Component>
  {
    public ComponentType ComponentType { get; private set; }

    public XElement Element { get; private set; }

    public ComponentCollection(ComponentType componentType, XElement element)
    {
      ComponentType = componentType;
      Element = element;
    }
  }
}
