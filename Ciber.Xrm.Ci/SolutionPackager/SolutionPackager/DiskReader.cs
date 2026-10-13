// Type: Microsoft.Crm.Tools.SolutionPackager.DiskReader
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;
    using Properties;

    internal sealed class DiskReader : IPackageReader, IDisposable
  {
    private Context _context;
    private bool _disposed;

    public void Initialize(Context context)
    {
      _context = context;
    }

    public void Load()
    {
      var str = Path.Combine(_context.RootFolder, _context.ComponentConfigurationManager.ConfigurationSection.CustomizationsFile);
      var path = Path.Combine(_context.RootFolder, _context.ComponentConfigurationManager.ConfigurationSection.SolutionFile);
      if (!File.Exists(str) || !File.Exists(path))
      {
        throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.MissingRequiredFile, Path.GetFullPath(str)));
      }
        using (Stream solutionXml = File.OpenRead(path))
            Helper.LoadSolutionInformation(solutionXml, _context);
        var xdocument = XDocument.Load(str, LoadOptions.None);
        foreach (var other in xdocument.Root.Elements())
        {
            var componentProcessor = _context.GetComponentProcessor(other.Name.LocalName);
            if (componentProcessor != null)
            {
                Logger.Message(TraceLevel.Info, "Processing Component: {0}", componentProcessor.SupportedElementName);
                var componentCollection = componentProcessor.ReadFromFiles();
                if (componentCollection == null)
                {
                    componentCollection = componentProcessor.CreateComponents(new XElement(other));
                    other.RemoveAll();
                }
                _context.Customizations.Components.Add(componentCollection);
            }
        }
        _context.Customizations.CustomizationsXDocument = xdocument;
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
  }
}
