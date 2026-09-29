// Type: Microsoft.Crm.Tools.SolutionPackager.ComponentConfigurationElement
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Configuration;

    public sealed class ComponentConfigurationElement : ConfigurationElement
  {
    [ConfigurationProperty("type", IsKey = true, IsRequired = true)]
    public ComponentType ComponentType
    {
      get
      {
        return (ComponentType) this["type"];
      }
      set
      {
        this["type"] = value;
      }
    }

    [ConfigurationProperty("directory", DefaultValue = "Other", IsRequired = false)]
    [StringValidator(InvalidCharacters = "\"<>|\\/:*?", MinLength = 1)]
    public string MainDirectory
    {
      get
      {
        return (string) this["directory"];
      }
      set
      {
        this["directory"] = value;
      }
    }

    [ConfigurationProperty("file", DefaultValue = "$(type).xml", IsRequired = false)]
    public string FileName
    {
      get
      {
        return (string) this["file"];
      }
      set
      {
        this["file"] = value;
      }
    }

    [ConfigurationProperty("tag", DefaultValue = "", IsRequired = false)]
    public string Tag
    {
      get
      {
        return (string) this["tag"];
      }
      set
      {
        this["tag"] = value;
      }
    }

    public ComponentConfigurationElement()
    {
    }

    public ComponentConfigurationElement(ComponentType type, string directory, string file)
    {
      ComponentType = type;
      MainDirectory = directory;
      FileName = file;
    }
  }
}
