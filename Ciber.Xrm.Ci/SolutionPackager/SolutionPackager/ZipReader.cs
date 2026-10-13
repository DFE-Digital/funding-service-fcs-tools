// Type: Microsoft.Crm.Tools.SolutionPackager.ZipReader
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.IO;
    using System.IO.Packaging;
    using System.Xml.Linq;

    public sealed class ZipReader : IPackageReader, IDisposable
  {
    private const string SolutionFileName = "/SOLUTION.XML";
    private const string CustomizationFileName = "/CUSTOMIZATIONS.XML";
    private bool _disposed;
    private Context _context;

    public void Initialize(Context context)
    {
      _context = context;
    }

    public void Load()
    {
      using (var zipPackage = (ZipPackage) Package.Open(_context.ZipFile, FileMode.Open, FileAccess.Read))
      {
        foreach (ZipPackagePart zipPackagePart in zipPackage.GetParts())
        {
          switch (Uri.UnescapeDataString(zipPackagePart.Uri.ToString()).ToUpperInvariant())
          {
            case "/SOLUTION.XML":
              Helper.LoadSolutionInformation(zipPackagePart.GetStream(), _context);
              continue;
            case "/CUSTOMIZATIONS.XML":
              LoadCustomizations(zipPackagePart.GetStream(), _context);
              continue;
            default:
              _context.Customizations.AddComponentFile(zipPackagePart.Uri, GetPartBytes(zipPackagePart));
              continue;
          }
        }
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void LoadCustomizations(Stream customizationXml, Context context)
    {
      var xdocument1 = XDocument.Load(customizationXml, LoadOptions.None);
      var xdocument2 = new XDocument(xdocument1.Declaration, new XElement(xdocument1.Root.Name, xdocument1.Root.Attributes()));
      foreach (var xelement1 in xdocument1.Root.Elements())
      {
        var xelement2 = new XElement(xelement1.Name);
        var componentProcessor = context.GetComponentProcessor(xelement1.Name.LocalName);
        if (componentProcessor != null)
          context.Customizations.Components.Add(componentProcessor.CreateComponents(xelement1));
        else
          xelement2 = new XElement(xelement1);
        xdocument2.Root.Add(xelement2);
      }
      context.Customizations.CustomizationsXDocument = xdocument2;
    }

    private void Dispose(bool disposing)
    {
      if (_disposed)
        return;
      var num = disposing ? 1 : 0;
      _disposed = true;
    }

    private byte[] GetPartBytes(PackagePart part)
    {
      using (var memoryStream = new MemoryStream())
      {
        part.GetStream().CopyTo(memoryStream);
        return memoryStream.ToArray();
      }
    }
  }
}
