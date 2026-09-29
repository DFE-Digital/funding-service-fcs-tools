// Type: Microsoft.Crm.Tools.SolutionPackager.MailMergeTemplateProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;
    using Properties;

    internal sealed class MailMergeTemplateProcessor : SubTemplateProcessorBase
  {
    protected override string TemplateIdElementName
    {
      get
      {
        return "mailmergetemplateid";
      }
    }

    protected override string SubTemplateRootDirectory
    {
      get
      {
        return "MailMergeDocuments";
      }
    }

    public MailMergeTemplateProcessor(TemplateProcessor templateProcessor)
      : base(templateProcessor)
    {
    }

    protected override void WriteSubTemplateToFiles(XElement element, string subTemplateDirectory)
    {
      var elementValue = Helper.GetElementValue(element, "filename", false, null);
      if (string.IsNullOrEmpty(elementValue))
        return;
      var path = Path.Combine(subTemplateDirectory, elementValue);
      Helper.EnsurePathDirectory(path);
      var bytes = Convert.FromBase64String(Helper.GetElementValue(element, "body", true, null));
      File.WriteAllBytes(path, bytes);
      Helper.SetElementValue(element, "body", null, false);
    }

    protected override void ReadSubTemplateFromFiles(XElement element, string subTemplateDirectory)
    {
      var elementValue = Helper.GetElementValue(element, "filename", false, null);
      if (string.IsNullOrEmpty(elementValue))
        return;
      var path = Path.Combine(subTemplateDirectory, elementValue);
      if (!string.IsNullOrEmpty(Helper.GetElementValue(element, "body", false, null)))
        return;
      if (!File.Exists(path))
      {
        throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.MissingRequiredFile, Path.GetFullPath(path)));
      }
        var inArray = File.ReadAllBytes(path);
        Helper.SetElementValue(element, "body", Convert.ToBase64String(inArray), false);
        Helper.SetElementValue(element, "filesize", inArray.Length.ToString(CultureInfo.InvariantCulture), false);
    }
  }
}
