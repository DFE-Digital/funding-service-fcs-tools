// Type: Microsoft.Crm.Tools.SolutionPackager.DiskWriter
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public sealed class DiskWriter : IPackageWriter, IDisposable
  {
    private static readonly Collection<LocalizableElement> AllLocalizableElements = new Collection<LocalizableElement>();
    private string _rootDirectory;
    private bool _disposed;
    private Context _context;

    static DiskWriter()
    {
    }

    public void Initialize(Context context)
    {
      _context = context;
      _rootDirectory = context.RootFolder;
      if (!string.IsNullOrWhiteSpace(_rootDirectory))
        return;
      _rootDirectory = Environment.CurrentDirectory;
    }

    public void WriteComponents()
    {
      foreach (var components in _context.Customizations.Components)
      {
        var componentProcessor = _context.GetComponentProcessor(components.ComponentType);
        if (componentProcessor != null && !_context.IsFilteredOut(componentProcessor.SupportedComponentType) && (_context.PackageTypeArgument != SolutionPackageType.Both || !_context.SolutionInformation.IsManaged || componentProcessor.IsDifferentInManaged))
        {
          Logger.Message(TraceLevel.Info, "Processing Component: {0}", componentProcessor.SupportedElementName);
          componentProcessor.WriteToFiles(components);
        }
      }
      if (_context.IsFilterApplied)
        return;
      var filename1 = Path.Combine(_rootDirectory, _context.ComponentConfigurationManager.ConfigurationSection.CustomizationsFile);
      var filename2 = Path.Combine(_rootDirectory, _context.ComponentConfigurationManager.ConfigurationSection.SolutionFile);
      Helper.WriteToFile(filename1, _context.Customizations.CustomizationsXDocument);
      if (_context.PackageTypeArgument == SolutionPackageType.Both)
        _context.SolutionInformation.SolutionXDocument.Root.Elements("SolutionManifest").Elements("Managed").FirstOrDefault().Value = 2.ToString(CultureInfo.InvariantCulture);
      Helper.WriteToFile(filename2, _context.SolutionInformation.SolutionXDocument);
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

    public void LocalizeComponents()
    {
      if (!_context.Localize && string.IsNullOrWhiteSpace(_context.TemplateLcid))
        return;
      var oLock = new object();
      Logger.Message(TraceLevel.Info, "Localizing Assets...");
      Parallel.ForEach(_context.Customizations.Components, components =>
      {
          var local0 = _context.GetComponentProcessor(components.ComponentType);
          if (local0 == null || _context.IsFilteredOut(local0.SupportedComponentType) || _context.PackageTypeArgument == SolutionPackageType.Both && _context.SolutionInformation.IsManaged && !local0.IsDifferentInManaged)
              return;
          Logger.Message(TraceLevel.Info, "Localizing component: {0}", local0.SupportedElementName);
          foreach (var item0 in local0.GetLocalizableElements(components))
          {
              lock (oLock)
                  AllLocalizableElements.Add(item0);
          }
      });
      if (!_context.Localize && string.IsNullOrWhiteSpace(_context.TemplateLcid) || _context.PackageTypeArgument == SolutionPackageType.Both && !_context.IsManagedPackage)
        return;
      WriteResxFile(AllLocalizableElements);
      Logger.Message(TraceLevel.Info, "");
    }

    private void WriteResxFile(Collection<LocalizableElement> allLocalizableElements)
    {
      Logger.Message(TraceLevel.Info, "Writing string resources...");
      var list = new List<LocalizableElement>(allLocalizableElements);
      list.Sort(LocalizableElement.Compare);
      var writers = new Dictionary<string, Tuple<ResXResourceWriter, StringBuilder>>();
      var vsr = Assembly.GetExecutingAssembly().GetName().Version;
      var oLock = new object();
      Parallel.ForEach(list, localizable => Parallel.ForEach(localizable.Element.Elements(), sourceElement =>
      {
          lock (oLock)
          {
              var local0 = sourceElement.Attribute(localizable.LocaleIdAttribute).Value;
              if (writers.ContainsKey(local0))
                  return;
              var local1 = new StringBuilder();
              var local2 = new ResXResourceWriter(new StringWriter(local1, CultureInfo.InvariantCulture));
              local2.AddMetadata("Source LCID", local0);
              local2.AddMetadata("Source file", Path.GetFileName(_context.ZipFile));
              local2.AddMetadata("Source package type", ((object) _context.PackageTypeArgument).ToString());
              local2.AddMetadata("SolutionPackager Version", vsr);
              writers[local0] = new Tuple<ResXResourceWriter, StringBuilder>(local2, local1);
          }
      }));
      using (var enumerator = list.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          var localizable = enumerator.Current;
          Parallel.ForEach(writers, writer =>
          {
              var local0 = localizable.Element.Elements().Where(w => w.Attribute(localizable.LocaleIdAttribute).Value.Equals(writer.Key)).FirstOrDefault();
              var local1 = string.Empty;
              if (local0 != null)
                  local1 = localizable.SourceAttribute == null ? local0.Value : local0.Attribute(localizable.SourceAttribute).Value;
              var local2 = new ResXDataNode(localizable.Name, local1)
              {
                  Comment = localizable.Comment
              };
              lock (oLock)
                  writer.Value.Item1.AddResource(local2);
          });
        }
      }
      Parallel.ForEach(writers.Keys, lcid =>
      {
          lock (oLock)
              writers[lcid].Item1.Close();
          if (!_context.Localize)
              return;
          var local1 = lcid;
          if (!_context.UseLcid)
          {
              try
              {
                  local1 = new CultureInfo(int.Parse(lcid)).Name;
              }
              catch (FormatException )
              {
              }
              catch (CultureNotFoundException )
              {
              }
          }
          Helper.WriteToFile(Path.Combine(_context.RootFolder, "Resources", local1, string.Format("resources.{0}.resx", local1)), writers[lcid].Item2.ToString(), Encoding.UTF8);
      });
      if (!string.IsNullOrWhiteSpace(_context.TemplateLcid) && writers.ContainsKey(_context.TemplateLcid))
      {
        Helper.WriteToFile(Path.Combine(_context.RootFolder, "Resources", "template_resources.resx"), writers[_context.TemplateLcid].Item2.ToString(), Encoding.UTF8);
      }
      else
      {
        if (string.IsNullOrWhiteSpace(_context.TemplateLcid))
          return;
        Logger.Message(TraceLevel.Warning, string.Format("Failed to write template, LCID {0} / {1} is not present in the resources for this solution", _context.TemplateLcid, _context.TemplateIsoCode));
      }
    }
  }
}
