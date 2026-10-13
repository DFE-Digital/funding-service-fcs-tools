// Type: Microsoft.Crm.Tools.SolutionPackager.FileToPathMapper
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Diagnostics;
    using System.Xml.Linq;

    internal sealed class FileToPathMapper : FileMapperBase
  {
    public const string ElementName = "FileToPath";

    public FileToPathMapper(PackagerArguments args, XElement element)
      : base(args, element)
    {
      ToFolder = element.Attribute("to").Value;
      InitToFolder();
      ValidateFolderName(ToFolder);
      WarnIfFolderMissing(ToFolder);
      if (string.IsNullOrWhiteSpace(ToFilename))
        return;
      Logger.Message(TraceLevel.Warning, "Filenames are not supported in the 'to' attribute.");
    }
  }
}
