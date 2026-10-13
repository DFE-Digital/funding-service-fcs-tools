// Type: Microsoft.Crm.Tools.SolutionPackager.ReportProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class ReportProcessor : ComponentProcessorBase
  {
    public ReportProcessor()
      : base("Reports", ComponentType.Report)
    {
      IsFileBackedComponent = true;
    }

    protected override Component CreateComponent(XElement element)
    {
      var configuration = context.ComponentConfigurationManager.GetConfiguration(ComponentType.Report);
      var fileBackedComponent1 = new FileBackedComponent();
      fileBackedComponent1.ComponentType = ComponentType.Report;
      fileBackedComponent1.Id = Helper.GetElementValue(element, "reportid", true, Helper.GuidConverter, new Guid());
      fileBackedComponent1.PrimaryName = Helper.GetElementValue(element, "name", false, null);
      fileBackedComponent1.Element = element;
      var fileBackedComponent2 = fileBackedComponent1;
      if (!Helper.IsUnmodifiedComponent(element))
      {
        fileBackedComponent2.FileName = Helper.GetElementValue(element, "ExportedFileName", false, null);
        fileBackedComponent2.DiskFileName = Path.Combine(configuration.MainDirectory, Helper.GetElementValue(element, "languagecode", false, string.Empty), Helper.GetElementValue(element, "reportid", true, null), Helper.GetElementValue(element, "filename", true, null));
      }
      return fileBackedComponent2;
    }

    protected override IEnumerable<XElement> GetComponentElements(XElement componentCollectionElement)
    {
      return componentCollectionElement.Elements("Report");
    }

    private string GetReportExtraFilename(string elementName)
    {
      return Path.Combine(context.RootFolder, context.ComponentConfigurationManager.GetConfiguration(ComponentType.Report).MainDirectory, string.Format(CultureInfo.InvariantCulture, "{0}{1}", elementName, ".xml"));
    }

    public override void WriteToFiles(ComponentCollection components)
    {
      var element1 = components.Element.Element("ReportSignatureIdMappings");
      if (element1 != null)
        Helper.WriteToFile(GetReportExtraFilename("ReportSignatureIdMappings"), element1);
      var element2 = components.Element.Element("ReportLinks");
      if (element2 != null)
        Helper.WriteToFile(GetReportExtraFilename("ReportLinks"), element2);
      base.WriteToFiles(components);
    }

    public override ComponentCollection ReadFromFiles()
    {
      var componentCollection = base.ReadFromFiles();
      var reportExtraFilename1 = GetReportExtraFilename("ReportSignatureIdMappings");
      if (File.Exists(reportExtraFilename1))
      {
        var xelement = XElement.Load(reportExtraFilename1);
        componentCollection.Element.AddFirst(xelement);
      }
      var reportExtraFilename2 = GetReportExtraFilename("ReportLinks");
      if (File.Exists(reportExtraFilename2))
      {
        var xelement = XElement.Load(reportExtraFilename2);
        componentCollection.Element.Add(xelement);
      }
      return componentCollection;
    }
  }
}
