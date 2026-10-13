// Type: Microsoft.Crm.Tools.SolutionPackager.FileToFileMapper
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Diagnostics;
    using System.IO;
    using System.Xml.Linq;

    internal sealed class FileToFileMapper : FileMapperBase
  {
    public const string ElementName = "FileToFile";

    public FileToFileMapper(PackagerArguments args, XElement element)
      : base(args, element)
    {
      var path = element.Attribute("to").Value;
      ToFolder = Path.GetDirectoryName(path);
      ToFilename = Path.GetFileName(path);
      InitToFolder();
      ValidateFolderName(ToFolder);
      WarnIfFolderMissing(ToFolder);
      ValidateFilename(ToFilename);
      if (ToFilename.Contains("*") || ToFilename.Contains("?"))
        Logger.Message(TraceLevel.Warning, "Wildcards are not supported for filenames in the 'to' attribute.");
      if (!MapFilenameUseWildcard)
        return;
      MapFilenameUseWildcard = false;
      Logger.Message(TraceLevel.Warning, "Wildcards are not supported for filenames in the 'map' attribute.");
    }
  }
}
