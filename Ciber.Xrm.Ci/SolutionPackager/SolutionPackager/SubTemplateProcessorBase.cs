// Type: Microsoft.Crm.Tools.SolutionPackager.SubTemplateProcessorBase
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;
    using Properties;

    internal abstract class SubTemplateProcessorBase : ISubComponentProcessor
  {
    protected const string XmlExtension = ".xml";
    protected const string StyleSheetExtension = ".xsl";

    protected TemplateProcessor TemplateProcessor { get; private set; }

    protected abstract string TemplateIdElementName { get; }

    protected abstract string SubTemplateRootDirectory { get; }

    protected SubTemplateProcessorBase(TemplateProcessor templateProcessor)
    {
      TemplateProcessor = templateProcessor;
    }

    public void ReadFromFiles(XElement componentElement, string componentPath)
    {
      var directoryName = Path.GetDirectoryName(componentPath);
      foreach (var xelement in componentElement.Elements())
      {
        if (!Helper.IsUnmodifiedComponent(xelement))
        {
          var templateDirectory = GetSubTemplateDirectory(xelement, directoryName);
          ReadSubTemplateFromFiles(xelement, templateDirectory);
        }
      }
    }

    public void WriteToFiles(XElement componentElement, string componentPath)
    {
      var element = new XElement(componentElement);
      var directoryName = Path.GetDirectoryName(componentPath);
      foreach (var xelement in element.Elements())
      {
        if (!Helper.IsUnmodifiedComponent(xelement))
        {
          var templateDirectory = GetSubTemplateDirectory(xelement, directoryName);
          WriteSubTemplateToFiles(xelement, templateDirectory);
        }
      }
      Helper.WriteToFile(componentPath, element);
    }

    protected abstract void WriteSubTemplateToFiles(XElement element, string subTemplateDirectory);

    protected abstract void ReadSubTemplateFromFiles(XElement element, string subTemplateDirectory);

    protected virtual string GetSubTemplateDirectory(XElement element, string componentDirectory)
    {
      var elementValue1 = Helper.GetElementValue(element, TemplateIdElementName, true, null);
      var elementValue2 = Helper.GetElementValue(element, "languagecode", false, string.Empty);
      return Path.Combine(componentDirectory, SubTemplateRootDirectory, elementValue2, elementValue1);
    }

    protected void WriteSubElementValueToFile(XElement element, string subElementName, string directory, string extension)
    {
      Helper.WriteToFile(Path.Combine(directory, Path.ChangeExtension(subElementName, extension)), Helper.GetElementValue(element, subElementName, true, null), Encoding.UTF8);
      Helper.SetElementValue(element, subElementName, null, false);
    }

    protected void ReadSubElementValueFromFile(XElement element, string subElementName, string directory, string extension)
    {
      var path = Path.Combine(directory, Path.ChangeExtension(subElementName, extension));
      if (!string.IsNullOrEmpty(Helper.GetElementValue(element, subElementName, true, null)))
        return;
      if (!File.Exists(path))
      {
        throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.MissingRequiredFile, Path.GetFullPath(path)));
      }
        var str = File.ReadAllText(path);
        Helper.SetElementValue(element, subElementName, str, false);
    }
  }
}
