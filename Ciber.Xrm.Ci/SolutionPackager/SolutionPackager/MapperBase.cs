// Type: Microsoft.Crm.Tools.SolutionPackager.MapperBase
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal abstract class MapperBase
  {
    protected string RootFolder;
    protected string MapFolder;
    protected string MapFilename;
    protected string ToFolder;
    protected string ToFilename;

    public MapperBase(PackagerArguments args)
    {
      RootFolder = Path.GetFullPath(args.Folder);
    }

    protected void WarnIfFolderMissing(string folder)
    {
      if (Directory.Exists(folder))
        return;
      Logger.Message(TraceLevel.Warning, "Map folder '{0}' does not exist.", folder);
    }

    protected void ValidateFolderName(string folder)
    {
      if (-1 == folder.IndexOfAny(Path.GetInvalidPathChars()))
        return;
      Logger.Message(TraceLevel.Warning, "Invalid characters in folder path: '{0}'", folder);
    }

    protected void ValidateFilename(string filename)
    {
      if (filename == "*.*" || filename.StartsWith("*.", StringComparison.OrdinalIgnoreCase) || (filename.EndsWith(".*", StringComparison.OrdinalIgnoreCase) || -1 == filename.IndexOfAny(Path.GetInvalidFileNameChars())))
        return;
      Logger.Message(TraceLevel.Warning, "Invalid characters in filename: " + filename);
    }

    protected string RemoveTrailingFolderSeperator(string folder)
    {
      while (folder[folder.Length - 1] == Path.DirectorySeparatorChar || folder[folder.Length - 1] == Path.AltDirectorySeparatorChar)
        folder = folder.Substring(0, folder.Length - 1);
      return folder;
    }

    public abstract bool TryMapFile(string inputFile, out string mappedFile);
  }
}
