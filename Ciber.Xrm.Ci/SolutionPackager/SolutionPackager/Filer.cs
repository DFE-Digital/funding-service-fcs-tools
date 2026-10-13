// Type: Microsoft.Crm.Tools.SolutionPackager.Filer
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Xml.Linq;

    internal sealed class Filer
  {
    private readonly Collection<MapperBase> _mappings = new Collection<MapperBase>();
    private const string CollectionElement = "Mapping";

    internal static Filer Track { get; private set; }

    public bool UseReadMapping { get; private set; }

    private Filer()
    {
    }

    public static void Initialize(PackagerArguments arguments)
    {
      Track = new Filer();
      if (string.IsNullOrWhiteSpace(arguments.MappingFile))
        return;
      var xelement = XElement.Load(new StringReader(Environment.ExpandEnvironmentVariables(File.ReadAllText(arguments.MappingFile))));
      if (xelement.Name.LocalName != "Mapping")
        throw new FileFormatException("Incorrect Xml format specified for mapping directives.");
      Logger.Message(TraceLevel.Info, "Reading mapping directives...");
      foreach (var element in xelement.Elements())
      {
        Logger.Message(TraceLevel.Verbose, element.ToString());
        MapperBase mapperBase;
        switch (element.Name.LocalName)
        {
          case "Folder":
            mapperBase = new BasicFolderMapper(arguments, element);
            break;
          case "FileToFile":
            mapperBase = new FileToFileMapper(arguments, element);
            break;
          case "FileToPath":
            mapperBase = new FileToPathMapper(arguments, element);
            break;
          default:
            throw new ArgumentOutOfRangeException("Did not expect mapping element:" + element.Name.LocalName);
        }
        Track._mappings.Add(mapperBase);
      }
      Track.UseReadMapping = true;
    }

    public bool DoesFilenameMap(string filepath)
    {
      foreach (var mapperBase in _mappings)
      {
        string mappedFile;
        if (mapperBase.TryMapFile(filepath, out mappedFile))
        {
          if (string.IsNullOrWhiteSpace(mappedFile) || !File.Exists(mappedFile))
            Logger.Message(TraceLevel.Warning, "Solution may not repack due to missing mapped file for: {0}", filepath);
          return true;
        }
      }
      return false;
    }

    public string MapFilename(string filepath)
    {
      var flag = false;
      foreach (var mapperBase in _mappings)
      {
        string mappedFile;
        flag = flag | mapperBase.TryMapFile(filepath, out mappedFile);
        if (File.Exists(mappedFile))
        {
          Logger.Message(TraceLevel.Info, "Mapping: {0} to {1}", Path.GetFullPath(filepath), mappedFile);
          return mappedFile;
        }
      }
      if (flag)
        Logger.Message(TraceLevel.Error, "Matched file '{0}' was not found in any mapping. Pack operation is aborted.", filepath);
      return filepath;
    }
  }
}
