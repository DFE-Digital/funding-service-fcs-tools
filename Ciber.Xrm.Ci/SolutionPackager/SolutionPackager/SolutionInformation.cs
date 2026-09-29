// Type: Microsoft.Crm.Tools.SolutionPackager.SolutionInformation
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Xml.Linq;

    public sealed class SolutionInformation
  {
    public bool IsManaged { get; internal set; }

    public SolutionPackageType PackageType { get; internal set; }

    public string UniqueName { get; internal set; }

    public LabelDictionary DisplayName { get; internal set; }

    public LabelDictionary Description { get; internal set; }

    public PublisherInformation Publisher { get; internal set; }

    public XDocument SolutionXDocument { get; internal set; }

    public string BaseLocale { get; internal set; }
  }
}
