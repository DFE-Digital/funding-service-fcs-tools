// Type: Microsoft.Crm.Tools.SolutionPackager.EmailTemplateProcessor
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

    internal sealed class EmailTemplateProcessor : SubTemplateProcessorBase
  {
    protected override string TemplateIdElementName
    {
      get
      {
        return "templateid";
      }
    }

    protected override string SubTemplateRootDirectory
    {
      get
      {
        return "EmailDocuments";
      }
    }

    public EmailTemplateProcessor(TemplateProcessor templateProcessor)
      : base(templateProcessor)
    {
    }

    protected override void WriteSubTemplateToFiles(XElement element, string subTemplateDirectory)
    {
      WriteSubElementValueToFile(element, "subject", subTemplateDirectory, ".xsl");
      WriteSubElementValueToFile(element, "subjectpresentationxml", subTemplateDirectory, ".xml");
      WriteSubElementValueToFile(element, "body", subTemplateDirectory, ".xsl");
      WriteSubElementValueToFile(element, "presentationxml", subTemplateDirectory, ".xml");
      WriteAttachments(element);
    }

    protected override void ReadSubTemplateFromFiles(XElement element, string subTemplateDirectory)
    {
      ReadSubElementValueFromFile(element, "subject", subTemplateDirectory, ".xsl");
      ReadSubElementValueFromFile(element, "subjectpresentationxml", subTemplateDirectory, ".xml");
      ReadSubElementValueFromFile(element, "body", subTemplateDirectory, ".xsl");
      ReadSubElementValueFromFile(element, "presentationxml", subTemplateDirectory, ".xml");
      ReadAttachments(element);
    }

    private void ReadAttachments(XElement element)
    {
      var xelement1 = element.Element("ActivityMimeAttachments");
      if (xelement1 == null)
        return;
      foreach (var xelement2 in xelement1.Elements("ActivityMimeAttachment"))
      {
        var elementValue = Helper.GetElementValue(xelement2, "SolutionAttachmentsFileName", false, null);
        if (!string.IsNullOrWhiteSpace(elementValue))
        {
          var attachmentDiskPath = GetAttachmentDiskPath(xelement2, elementValue);
          if (!File.Exists(attachmentDiskPath))
          {
            throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.MissingRequiredFile, Path.GetFullPath(attachmentDiskPath)));
          }
            var componentFile = new ComponentFile
            {
                FileName = elementValue,
                Uri = new Uri(elementValue, UriKind.Relative),
                Bytes = File.ReadAllBytes(attachmentDiskPath)
            };
            if (!TemplateProcessor.Context.Customizations.ComponentFiles.ContainsKey(componentFile.FileName))
                TemplateProcessor.Context.Customizations.ComponentFiles.Add(componentFile.FileName, componentFile);
        }
      }
    }

    private void WriteAttachments(XElement element)
    {
      var xelement1 = element.Element("ActivityMimeAttachments");
      if (xelement1 == null)
        return;
      foreach (var xelement2 in xelement1.Elements("ActivityMimeAttachment"))
      {
        var elementValue = Helper.GetElementValue(xelement2, "SolutionAttachmentsFileName", false, null);
        ComponentFile componentFile;
        if (!string.IsNullOrWhiteSpace(elementValue) && TemplateProcessor.Context.Customizations.ComponentFiles.TryGetValue(elementValue, out componentFile) && componentFile != null)
        {
          var attachmentDiskPath = GetAttachmentDiskPath(xelement2, elementValue);
          Helper.EnsurePathDirectory(attachmentDiskPath);
          File.WriteAllBytes(attachmentDiskPath, componentFile.Bytes);
        }
      }
    }

    private string GetAttachmentDiskPath(XElement attachment, string zipPath)
    {
      var path = Path.Combine(TemplateProcessor.Context.RootFolder, Helper.RemoveLeadingSlash(zipPath));
      var elementValue = Helper.GetElementValue(attachment, "filename", false, null);
      if (!string.IsNullOrWhiteSpace(elementValue))
        path = Path.Combine(Path.GetDirectoryName(path), elementValue);
      return path;
    }
  }
}
