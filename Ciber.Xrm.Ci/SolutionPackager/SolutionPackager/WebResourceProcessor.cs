// Type: Microsoft.Crm.Tools.SolutionPackager.WebResourceProcessor
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
  internal sealed class WebResourceProcessor : ComponentProcessorBase
  {
    public WebResourceProcessor()
      : base("WebResources", ComponentType.WebResource)
    {
      IsFileBackedComponent = true;
    }

    protected override Component CreateComponent(XElement element)
    {
      var elementValue = Helper.GetElementValue(element, "Name", true, null);
      var configuration = context.ComponentConfigurationManager.GetConfiguration(ComponentType.WebResource);
      var fileBackedComponent = new FileBackedComponent();
      fileBackedComponent.ComponentType = ComponentType.WebResource;
      fileBackedComponent.Id = Helper.GetElementValue(element, "WebResourceId", true, Helper.GuidConverter, new Guid());
      fileBackedComponent.PrimaryName = elementValue;
      fileBackedComponent.Element = element;
      fileBackedComponent.FileName = Helper.GetElementValue(element, "FileName", false, null);
      fileBackedComponent.DiskFileName = Path.Combine(configuration.MainDirectory, elementValue);
      return fileBackedComponent;
    }
  }
}
