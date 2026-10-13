// Type: Microsoft.Crm.Tools.SolutionPackager.Helper
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;

    internal static class Helper
  {
    private static bool _denyWrite;
    private static bool _clobber = true;
    private static readonly List<string> writtenFiles = new List<string>();
    private static readonly List<string> readOnlyFiles = new List<string>();

    public static List<string> WrittenFiles
    {
      get
      {
        return writtenFiles;
      }
    }

    public static List<string> ReadOnlyFiles
    {
      get
      {
        return readOnlyFiles;
      }
    }

    static Helper()
    {
    }

    public static string GetElementValue(XElement element, string childName, bool throwIfNull, string @default = null)
    {
      return GetElementValue(element, childName, throwIfNull, s => s, @default);
    }

    public static T GetElementValue<T>(XElement element, string childName, bool throwIfNull, Func<string, T> converter, T @default = default(T))
    {
      var xelement = element.Element(childName);
      if (xelement == null && throwIfNull)
      {
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Cannot find child element {0} of element {1}.", childName, element.Name));
      }
        var obj = @default;
        if (xelement != null)
            obj = converter(xelement.Value);
        return obj;
    }

    public static void SetElementValue(XElement element, string childName, string value, bool appendIfNull)
    {
      var xelement = element.Element(childName);
      if (xelement == null)
      {
        if (!appendIfNull)
          throw new ArgumentException(string.Format("Cannot find child element {0} of element {1}.", childName, element.Name));
        xelement = new XElement(childName);
        element.Add(xelement);
      }
      xelement.Value = value ?? string.Empty;
    }

    public static string GetAttributeValue(XElement element, string attributeName, bool throwIfNull, string @default = null)
    {
      return GetAttributeValue(element, attributeName, throwIfNull, s => s, @default);
    }

    public static T GetAttributeValue<T>(XElement element, string childName, bool throwIfNull, Func<string, T> converter, T @default = default(T))
    {
      var xattribute = element.Attribute(childName);
      if (xattribute == null && throwIfNull)
      {
        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Cannot find child attribute {0} of element {1}.", childName, element.Name));
      }
        var obj = @default;
        if (xattribute != null)
            obj = converter(xattribute.Value);
        return obj;
    }

    public static Guid GuidConverter(string value)
    {
      return Guid.Parse(value);
    }

    public static bool BooleanConverter(string value)
    {
      bool result;
      if (!bool.TryParse(value, out result))
        return value == "1";
        return result;
    }

    public static void LoadSolutionInformation(Stream solutionXml, Context context)
    {
      var xdocument = XDocument.Load(solutionXml, LoadOptions.None);
      var xelement = xdocument.Element("ImportExportXml").Element("SolutionManifest");
      context.SolutionInformation.UniqueName = xelement.Element("UniqueName").Value;
      context.SolutionInformation.BaseLocale = xdocument.Element("ImportExportXml").Attribute("languagecode").Value;
      if (context.Action == CommandAction.Extract && !string.IsNullOrWhiteSpace(context.TemplateLcid) && context.TemplateLcid.Equals("Auto", StringComparison.OrdinalIgnoreCase))
      {
        var outLcid = string.Empty;
        context.TemplateIsoCode = context.ValidateLocaleId(context.SolutionInformation.BaseLocale, out outLcid, true);
        context.TemplateLcid = outLcid;
        Logger.Message(TraceLevel.Info, string.Format("Resource template will be generated for default solution language.\b\n\rLCID:{0} ISO Code:{1}.\n\r ", context.TemplateLcid, context.TemplateIsoCode));
      }
      context.SolutionInformation.PackageType = (SolutionPackageType) Enum.Parse(typeof (SolutionPackageType), xelement.Element("Managed").Value);
      if (context.PackageTypeArgument == SolutionPackageType.None)
        context.PackageTypeArgument = context.SolutionInformation.PackageType;
      switch (context.Action)
      {
        case CommandAction.Extract:
          context.SolutionInformation.IsManaged = context.SolutionInformation.PackageType == SolutionPackageType.Managed;
          if (context.PackageTypeArgument != SolutionPackageType.Both && context.SolutionInformation.PackageType != context.PackageTypeArgument)
            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Solution package type did not match requested type.{2}Command line argument: {0}{2}Package type: {1}", (object) context.SolutionInformation.PackageType, (object) context.PackageTypeArgument, (object) Environment.NewLine));
              break;
          case CommandAction.Pack:
          if (context.SolutionInformation.PackageType != SolutionPackageType.Both && context.SolutionInformation.PackageType != context.PackageTypeArgument)
            throw new ArgumentException(string.Format("Solution package type did not match requested type.\r\nCommand line argument: {0}\r\nPackage type: {1}", context.SolutionInformation.PackageType, context.PackageTypeArgument));
          if (context.SolutionInformation.PackageType == SolutionPackageType.Both)
          {
            context.SolutionInformation.IsManaged = context.IsManagedPackage;
            xelement.Element("Managed").Value = context.SolutionInformation.IsManaged ? "1" : "0";
            break;
          }
              context.SolutionInformation.IsManaged = context.SolutionInformation.PackageType != SolutionPackageType.Unmanaged;
              break;
          default:
          throw new NotImplementedException();
      }
      context.SolutionInformation.SolutionXDocument = xdocument;
    }

    public static void EnsurePathDirectory(string path)
    {
      var directoryName = Path.GetDirectoryName(path);
      if (string.IsNullOrWhiteSpace(directoryName) || Directory.Exists(directoryName))
        return;
      Directory.CreateDirectory(directoryName);
    }

    public static bool IsUnmodifiedComponent(XElement componentElement)
    {
      return GetAttributeValue(componentElement, "unmodified", false, BooleanConverter, false);
    }

    public static string RemoveLeadingSlash(string path)
    {
      return path.TrimStart('/', '\\');
    }

    internal static string AppendManagedFileName(string name)
    {
      return name + "_managed";
    }

    public static void SetSafety(bool denyWrite, bool clobber)
    {
      _denyWrite = denyWrite;
      _clobber = clobber;
      if (denyWrite)
        Logger.Message(TraceLevel.Warning, "No disk writes or deletes will occur.");
      if (!clobber)
        return;
      Logger.Message(TraceLevel.Warning, "Read-only files will be over-written or deleted.");
    }

    public static bool WriteToFile(string filename, byte[] bytes)
    {
      AddWrittenFile(filename);
      var flag = !File.Exists(filename);
      if (flag)
      {
        Logger.Message(TraceLevel.Verbose, "Creating: {0}", filename);
      }
      else
      {
        var numArray = File.ReadAllBytes(filename);
        flag = bytes.SequenceEqual(numArray);
        if (!flag)
          Logger.Message(TraceLevel.Verbose, "No change: {0}", filename);
        else
          flag = VerifyReadOnly(filename, "Writing");
      }
      if (!flag || _denyWrite)
        return false;
      EnsurePathDirectory(filename);
      File.WriteAllBytes(filename, bytes);
      return true;
    }

    public static bool WriteToFile(string filename, XElement element)
    {
      var builder = new StringBuilder();
      using (var writerWithEncoding = new StringWriterWithEncoding(builder, Encoding.UTF8))
        element.Save(writerWithEncoding);
      return WriteToFile(filename, builder.ToString(), Encoding.UTF8);
    }

    public static bool WriteToFile(string filename, XDocument document)
    {
      var builder = new StringBuilder();
      using (var writerWithEncoding = new StringWriterWithEncoding(builder, Encoding.UTF8))
        document.Save(writerWithEncoding);
      return WriteToFile(filename, builder.ToString(), Encoding.UTF8);
    }

    public static bool WriteToFile(string filename, string content, Encoding encoding)
    {
      if (string.IsNullOrWhiteSpace(Path.GetExtension(filename)))
        filename = filename + ".xml";
      AddWrittenFile(filename);
      var flag = !File.Exists(filename);
      if (flag)
      {
        Logger.Message(TraceLevel.Verbose, "Creating: {0}", filename);
      }
      else
      {
        var strB = File.ReadAllText(filename);
        flag = string.Compare(content, strB) != 0;
        if (!flag)
          Logger.Message(TraceLevel.Verbose, "No change: {0}", filename);
        else
          flag = VerifyReadOnly(filename, "Writing");
      }
      if (!flag || _denyWrite)
        return false;
      EnsurePathDirectory(filename);
      File.WriteAllText(filename, content, encoding);
      return true;
    }

    public static bool DeleteFile(string filename)
    {
      var flag = File.Exists(filename);
      if (flag)
        flag = VerifyReadOnly(filename, "Deleting");
      if (!flag || _denyWrite)
        return false;
      File.Delete(filename);
      CleanFolder(Path.GetDirectoryName(filename));
      return true;
    }

    private static void CleanFolder(string folder)
    {
      if (!Directory.Exists(folder) || Directory.GetFileSystemEntries(folder).Length > 0)
        return;
      Logger.Message(TraceLevel.Verbose, "Removing empty folder: {0}", folder);
      try
      {
        Directory.Delete(folder);
      }
      catch
      {
      }
      CleanFolder(Path.GetDirectoryName(folder));
    }

    private static void AddWrittenFile(string filename)
    {
      filename = filename.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
      if (writtenFiles.Contains(filename))
        return;
      writtenFiles.Add(filename);
    }

    private static bool VerifyReadOnly(string filename, string verb)
    {
      if ((File.GetAttributes(filename) & FileAttributes.ReadOnly) != 0)
      {
        if (_clobber && !_denyWrite)
        {
          File.SetAttributes(filename, FileAttributes.Normal);
          Logger.Message(TraceLevel.Warning, "Clobbering: {0}", filename);
          return true;
        }
          Logger.Message(TraceLevel.Warning, "Read-only: {0}", filename);
          AddReadOnlyFile(filename);
          return false;
      }
        Logger.Message(TraceLevel.Verbose, "{0}: {1}", verb, filename);
        return true;
    }

    private static void AddReadOnlyFile(string filename)
    {
      filename = filename.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
      if (readOnlyFiles.Contains(filename))
        return;
      readOnlyFiles.Add(filename);
    }

    public static bool IsResourceFileOnSupportedVersion(string resourceName, Version resourceVersionId)
    {
      var version = Assembly.GetExecutingAssembly().GetName().Version;
      if (resourceVersionId != null)
      {
        if (resourceVersionId.CompareTo(version) <= 0)
          return true;
        Logger.Message(TraceLevel.Error, string.Format("The resource file {0} was created by a newer version ({1}) of the solutionpackager.exe tool, You must use the same version or older to repack localizations", resourceName, resourceVersionId));
        return false;
      }
        Logger.Message(TraceLevel.Error, string.Format("Failed to determine version id of the resource file {0}. The resource file must be exported from the solutionpackager.exe tool in order to be used as part of the pack process", resourceName));
        return false;
    }

    private class StringWriterWithEncoding : StringWriter
    {
      private readonly Encoding _encoding;

      public override Encoding Encoding
      {
        get
        {
          return _encoding;
        }
      }

      public StringWriterWithEncoding(StringBuilder builder, Encoding encoding)
        : base(builder)
      {
        _encoding = encoding;
      }
    }
  }
}
