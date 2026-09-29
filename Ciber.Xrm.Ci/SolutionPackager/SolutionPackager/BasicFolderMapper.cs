// Type: Microsoft.Crm.Tools.SolutionPackager.BasicFolderMapper
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    internal sealed class BasicFolderMapper : MapperBase
  {
    public const string ElementName = "Folder";
    private const string MapAttrName = "map";
    private const string ToAttrName = "to";

    public BasicFolderMapper(PackagerArguments arguments, XElement element)
      : base(arguments)
    {
      MapFolder = RemoveTrailingFolderSeperator(element.Attribute("map").Value);
      MapFolder = Path.GetFullPath(Path.Combine(RootFolder, MapFolder));
      ToFolder = RemoveTrailingFolderSeperator(element.Attribute("to").Value);
      ToFolder = Path.GetFullPath(Path.Combine(RootFolder, ToFolder));
      ValidateFolderName(MapFolder);
      ValidateFolderName(ToFolder);
      if (arguments.Action == CommandAction.Pack)
        WarnIfFolderMissing(MapFolder);
      WarnIfFolderMissing(ToFolder);
    }

    public override bool TryMapFile(string inputFile, out string mappedFile)
    {
      mappedFile = null;
      if (!Path.GetFullPath(Path.GetDirectoryName(inputFile)).StartsWith(MapFolder, StringComparison.OrdinalIgnoreCase))
        return false;
      var path = Path.GetFullPath(inputFile).Replace(MapFolder, ToFolder);
      if (File.Exists(path))
        mappedFile = path;
      return true;
    }
  }
}
