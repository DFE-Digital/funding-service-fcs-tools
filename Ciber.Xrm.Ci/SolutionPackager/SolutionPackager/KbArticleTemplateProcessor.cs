// Type: Microsoft.Crm.Tools.SolutionPackager.KbArticleTemplateProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Xml.Linq;

    internal sealed class KbArticleTemplateProcessor : SubTemplateProcessorBase
  {
    protected override string TemplateIdElementName
    {
      get
      {
        return "kbarticletemplateid";
      }
    }

    protected override string SubTemplateRootDirectory
    {
      get
      {
        return "KbArticleDocuments";
      }
    }

    public KbArticleTemplateProcessor(TemplateProcessor templateProcessor)
      : base(templateProcessor)
    {
    }

    protected override void WriteSubTemplateToFiles(XElement element, string subTemplateDirectory)
    {
      WriteSubElementValueToFile(element, "structurexml", subTemplateDirectory, ".xml");
      WriteSubElementValueToFile(element, "formatxml", subTemplateDirectory, ".xsl");
    }

    protected override void ReadSubTemplateFromFiles(XElement element, string subTemplateDirectory)
    {
      ReadSubElementValueFromFile(element, "structurexml", subTemplateDirectory, ".xml");
      ReadSubElementValueFromFile(element, "formatxml", subTemplateDirectory, ".xsl");
    }
  }
}
