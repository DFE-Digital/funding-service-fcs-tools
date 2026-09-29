// Type: Microsoft.Crm.Tools.SolutionPackager.WorkflowProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Xml.Linq;

    [Export(typeof (IComponentProcessor))]
  internal sealed class WorkflowProcessor : ComponentProcessorBase
  {
    public WorkflowProcessor()
      : base("Workflows", ComponentType.Workflow)
    {
      IsFileBackedComponent = true;
    }

    protected override Component CreateComponent(XElement element)
    {
      var configuration = context.ComponentConfigurationManager.GetConfiguration(ComponentType.Workflow);
      var fileBackedComponent1 = new FileBackedComponent();
      fileBackedComponent1.ComponentType = ComponentType.Workflow;
      fileBackedComponent1.Id = Helper.GetAttributeValue(element, "WorkflowId", true, Helper.GuidConverter, new Guid());
      fileBackedComponent1.PrimaryName = Helper.GetAttributeValue(element, "Name", false, null);
      fileBackedComponent1.Element = element;
      var fileBackedComponent2 = fileBackedComponent1;
      if (!Helper.IsUnmodifiedComponent(element))
      {
        fileBackedComponent2.FileName = Helper.GetElementValue(element, "XamlFileName", false, null);
        fileBackedComponent2.DiskFileName = Path.Combine(configuration.MainDirectory, Helper.GetElementValue(element, "LanguageCode", false, string.Empty), Path.GetFileName(Helper.GetElementValue(element, "XamlFileName", true, null)));
      }
      return fileBackedComponent2;
    }
  }
}
