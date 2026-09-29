// Type: Microsoft.Crm.Tools.SolutionPackager.FileMapperBase
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    internal abstract class FileMapperBase : MapperBase
  {
    private const string MapAttrName = "map";
    protected const string ToAttrName = "to";
    protected const string FolderWildcardSymbol = "**";
    protected bool MapFilenameUseWildcard;
    protected bool MapFolderUsingWildcard;
    protected bool ToFolderUsingWildcard;

    public FileMapperBase(PackagerArguments arguments, XElement element)
      : base(arguments)
    {
      var path = element.Attribute("map").Value;
      MapFolder = RemoveTrailingFolderSeperator(Path.Combine(RootFolder, Path.GetDirectoryName(path)));
      MapFilename = Path.GetFileName(path);
      if (MapFolder.EndsWith("**", StringComparison.OrdinalIgnoreCase))
      {
        MapFolderUsingWildcard = true;
        MapFolder = MapFolder.Replace("**", null);
      }
      MapFolder = Path.GetFullPath(MapFolder);
      MapFilenameUseWildcard = MapFilename.Contains('*');
      ValidateFolderName(MapFolder);
      ValidateFilename(MapFilename);
      if (arguments.Action == CommandAction.Pack)
        WarnIfFolderMissing(MapFolder);
      if (MapFolder.StartsWith(RootFolder, StringComparison.OrdinalIgnoreCase))
        return;
      Logger.Message(TraceLevel.Warning, "Map folder '{0}' is not a child of the root folder: '{1}'", MapFolder, RootFolder);
    }

    protected void InitToFolder()
    {
      if (ToFolder.EndsWith("**", StringComparison.OrdinalIgnoreCase))
      {
        ToFolderUsingWildcard = true;
        ToFolder = ToFolder.Replace("**", null);
      }
      ToFolder = Path.GetFullPath(Path.Combine(RootFolder, ToFolder));
    }

    protected bool MatchFolder(string inputFolder)
    {
      if (MapFolder != RootFolder)
      {
        if (MapFolderUsingWildcard)
        {
          if (!inputFolder.StartsWith(MapFolder, StringComparison.OrdinalIgnoreCase))
            return false;
        }
        else if (string.Compare(inputFolder, MapFolder, StringComparison.OrdinalIgnoreCase) != 0)
          return false;
      }
      return true;
    }

    protected bool MatchFile(string inputFile)
    {
      if (MapFilenameUseWildcard)
      {
        if (MapFilename != "*.*" && Path.GetExtension(inputFile) != Path.GetExtension(MapFilename))
          return false;
      }
      else if (string.Compare(MapFilename, inputFile, StringComparison.OrdinalIgnoreCase) != 0)
        return false;
      return true;
    }

    public override bool TryMapFile(string inputFile, out string mappedFile)
    {
      mappedFile = null;
      var fileName = Path.GetFileName(inputFile);
      if (!MatchFolder(Path.GetFullPath(Path.GetDirectoryName(inputFile))) || !MatchFile(fileName))
        return false;
      if (Directory.Exists(ToFolder))
      {
        var files = Directory.GetFiles(ToFolder, ToFilename ?? fileName, ToFolderUsingWildcard ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        if (files.Length > 0)
        {
          if (files.Length > 1)
          {
            Logger.Message(TraceLevel.Warning, "Multiple possible matches found for '{0}', using '{1}'", inputFile, files[0]);
            Logger.Message(TraceLevel.Verbose, "Full list:");
            foreach (var str in files)
              Logger.Message(TraceLevel.Verbose, "  {0}", str);
          }
          mappedFile = files[0];
        }
      }
      return true;
    }
  }
}
