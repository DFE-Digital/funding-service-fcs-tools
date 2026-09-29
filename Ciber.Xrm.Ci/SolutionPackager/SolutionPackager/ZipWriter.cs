// Type: Microsoft.Crm.Tools.SolutionPackager.ZipWriter
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.IO.Packaging;
    using System.Resources;
    using System.Xml.Linq;

    public sealed class ZipWriter : IPackageWriter, IDisposable
  {
    private bool _disposed;
    private Context _context;
    private Dictionary<string, Dictionary<string, string>> _availableResources;

    public void Initialize(Context context)
    {
      _context = context;
    }

    public void WriteComponents()
    {
      var dictionary = new Dictionary<string, ComponentCollection>();
      foreach (var componentCollection in _context.Customizations.Components)
      {
        if (componentCollection != null)
          dictionary.Add(componentCollection.Element.Name.LocalName, componentCollection);
      }
      var document = new XDocument(_context.Customizations.CustomizationsXDocument);
      foreach (var xelement in document.Root.Elements())
      {
        ComponentCollection componentCollection;
        dictionary.TryGetValue(xelement.Name.LocalName, out componentCollection);
        if (componentCollection != null)
        {
          xelement.Add(componentCollection.Element.Attributes());
          xelement.Add(componentCollection.Element.Nodes());
        }
      }
      Helper.EnsurePathDirectory(_context.ZipFile);
      using (var package = (ZipPackage) Package.Open(_context.ZipFile, FileMode.Create))
      {
        AddXDocumentPart(package, new Uri("customizations.xml", UriKind.Relative), document);
        AddXDocumentPart(package, new Uri("solution.xml", UriKind.Relative), _context.SolutionInformation.SolutionXDocument);
        foreach (var componentFile in _context.Customizations.ComponentFiles.Values)
          AddFile(package, componentFile.Uri, componentFile.Bytes);
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
      if (_disposed)
        return;
      var num = disposing ? 1 : 0;
      _disposed = true;
    }

    private static void AddXDocumentPart(ZipPackage package, Uri uri, XDocument document)
    {
      var zipPackagePart = (ZipPackagePart) package.CreatePart(PackUriHelper.CreatePartUri(uri), "text/xml", CompressionOption.Maximum);
      using (var memoryStream = new MemoryStream())
      {
        document.Save(memoryStream);
        memoryStream.Flush();
        memoryStream.Seek(0L, SeekOrigin.Begin);
        memoryStream.CopyTo(zipPackagePart.GetStream());
      }
    }

    private static void AddFile(ZipPackage package, Uri uri, byte[] data)
    {
      var zipPackagePart = (ZipPackagePart) package.CreatePart(PackUriHelper.CreatePartUri(uri), "application/octet-stream", CompressionOption.Maximum);
      using (var memoryStream = new MemoryStream(data))
        memoryStream.CopyTo(zipPackagePart.GetStream());
    }

    public void LocalizeComponents()
    {
      if (!_context.Localize)
        return;
      LoadAvailbleResources();
      foreach (var components in _context.Customizations.Components)
      {
        var componentProcessor = _context.GetComponentProcessor(components.ComponentType);
        if (componentProcessor != null)
        {
          Logger.Message(TraceLevel.Info, "Localizing Component: {0}", componentProcessor.SupportedElementName);
          if (!string.IsNullOrWhiteSpace(_context.TemplateLcid))
            ReplaceLocalizableElements(componentProcessor.GetLocalizableElements(components));
        }
      }
    }

    private void ReplaceLocalizableElements(Collection<LocalizableElement> localizableElements)
    {
      foreach (var localizableElement in localizableElements)
      {
        foreach (var index in _availableResources.Keys)
        {
          XElement xelement1 = null;
          foreach (var xelement2 in localizableElement.Element.Elements())
          {
            if (xelement2.Attribute(localizableElement.LocaleIdAttribute).Value == index)
              xelement1 = xelement2;
          }
          if (xelement1 == null)
          {
            xelement1 = new XElement((XElement) localizableElement.Element.FirstNode);
            xelement1.Attribute(localizableElement.LocaleIdAttribute).Value = index;
            localizableElement.Element.Add(xelement1);
          }
          if (!string.IsNullOrWhiteSpace(localizableElement.SourceAttribute == null ? xelement1.Value : xelement1.Attribute(localizableElement.SourceAttribute).Value))
          {
            try
            {
              var str = _availableResources[index][localizableElement.Name];
              if (localizableElement.SourceAttribute == null)
                xelement1.Value = str;
              else
                xelement1.Attribute(localizableElement.SourceAttribute).Value = str;
            }
            catch (Exception ex)
            {
              Logger.Message(TraceLevel.Error, ex, "Cannot find or read resource name {0} for language {1}", (object) index, (object) localizableElement.Name);
              throw;
            }
          }
        }
      }
    }

    private void LoadAvailbleResources()
    {
      var path = Path.Combine(_context.RootFolder, "Resources");
      if (!Directory.Exists(path))
        return;
      _availableResources = new Dictionary<string, Dictionary<string, string>>();
      foreach (var str1 in Directory.GetDirectories(path))
      {
        var fileName = Path.GetFileName(str1);
        int result;
        if (int.TryParse(fileName, out result))
        {
          try
          {
            if (CultureInfo.GetCultureInfo(result) == null)
              continue;
          }
          catch (CultureNotFoundException )
          {
            continue;
          }
        }
        else if (!_context.UseLcid)
        {
          try
          {
            result = new CultureInfo(fileName).LCID;
          }
          catch (CultureNotFoundException )
          {
            continue;
          }
        }
        var str2 = Path.Combine(str1, string.Format("resources.{0}.resx", fileName));
        if (File.Exists(str2))
          _availableResources.Add(result.ToString(), ReadResourceFile(str2));
      }
    }

    private Dictionary<string, string> ReadResourceFile(string resourceFile)
    {
      var dictionary = new Dictionary<string, string>();
      using (var resXresourceReader = new ResXResourceReader(resourceFile))
      {
        Version resourceVersionId = null;
        var metadataEnumerator = resXresourceReader.GetMetadataEnumerator();
        while (metadataEnumerator.MoveNext())
        {
          if (metadataEnumerator.Value is Version)
          {
            resourceVersionId = (Version) metadataEnumerator.Value;
            break;
          }
        }
        if (!Helper.IsResourceFileOnSupportedVersion(Path.GetFileName(resourceFile), resourceVersionId))
          return dictionary;
        resXresourceReader.UseResXDataNodes = false;
        foreach (DictionaryEntry dictionaryEntry in resXresourceReader)
          dictionary.Add(dictionaryEntry.Key.ToString(), dictionaryEntry.Value.ToString());
      }
      return dictionary;
    }
  }
}
