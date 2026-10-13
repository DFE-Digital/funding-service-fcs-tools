// Type: Microsoft.Crm.Tools.SolutionPackager.FileBackedComponent
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.IO;

    public sealed class FileBackedComponent : Component
  {
    private string _diskFileName;

    public string FileName { get; set; }

    public string DiskFileName
    {
      get
      {
          if (_diskFileName == null && FileName != null)
          return Helper.RemoveLeadingSlash(FileName);
          return _diskFileName;
      }
        set
      {
        _diskFileName = value;
        _diskFileName = _diskFileName.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
      }
    }
  }
}
