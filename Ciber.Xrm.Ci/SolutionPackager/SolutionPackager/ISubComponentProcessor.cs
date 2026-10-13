// Type: Microsoft.Crm.Tools.SolutionPackager.ISubComponentProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Xml.Linq;

    internal interface ISubComponentProcessor
  {
    void ReadFromFiles(XElement componentElement, string componentPath);

    void WriteToFiles(XElement componentElement, string componentPath);
  }
}
