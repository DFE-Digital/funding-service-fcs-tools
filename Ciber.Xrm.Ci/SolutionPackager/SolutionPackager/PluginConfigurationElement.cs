// Type: Microsoft.Crm.Tools.SolutionPackager.PluginConfigurationElement
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Configuration;
    using Properties;

    public sealed class PluginConfigurationElement : ConfigurationElement
    {
        private IPackagePlugin _pluginInstance;

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", IsKey = true, IsRequired = true)]
        public string PluginType
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }

        public IPackagePlugin PluginInstance
        {
            get
            {
                var pType = Type.GetType(PluginType);
                if (pType != null)
                {
                    _pluginInstance = Activator.CreateInstance(pType) as IPackagePlugin;
                    if (_pluginInstance != null)
                    {
                        return _pluginInstance;
                    }
                }

                throw new InvalidOperationException(string.Format("Failed to create an instance of {0} using the reflection Activator", PluginType));
            }
        }

        public PluginConfigurationElement()
        {
        }

        public PluginConfigurationElement(string name, string type)
        {
            Name = name;
            PluginType = type;
        }
    }
}
