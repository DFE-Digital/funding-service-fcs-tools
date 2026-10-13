// Type: Microsoft.Crm.Tools.SolutionPackager.IComponentProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Collections.ObjectModel;
    using System.Xml.Linq;

    public interface IComponentProcessor
  {
    string SupportedElementName { get; }

    ComponentType SupportedComponentType { get; }

    bool IsDifferentInManaged { get; }

    void Initialize(Context context);

    ComponentCollection CreateComponents(XElement element);

    ComponentCollection ReadFromFiles();

    void WriteToFiles(ComponentCollection components);

    Collection<LocalizableElement> GetLocalizableElements(ComponentCollection components);
  }
}
