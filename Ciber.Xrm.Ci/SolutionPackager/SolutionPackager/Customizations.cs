// Type: Microsoft.Crm.Tools.SolutionPackager.Customizations
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public sealed class Customizations
  {
    public List<ComponentCollection> Components { get; private set; }

    public Dictionary<string, ComponentFile> ComponentFiles { get; private set; }

    public XDocument CustomizationsXDocument { get; set; }

    public Customizations()
    {
      Components = new List<ComponentCollection>();
      ComponentFiles = new Dictionary<string, ComponentFile>();
    }

    public void AddComponentFile(Uri uri, byte[] bytes)
    {
      var componentFile = new ComponentFile
      {
        FileName = Uri.UnescapeDataString(uri.ToString()),
        Bytes = bytes,
        Uri = uri
      };
      ComponentFiles.Add(componentFile.FileName, componentFile);
    }
  }
}
