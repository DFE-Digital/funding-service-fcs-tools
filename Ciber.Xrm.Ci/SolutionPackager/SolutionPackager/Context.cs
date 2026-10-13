// Type: Microsoft.Crm.Tools.SolutionPackager.Context
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;
    using System.Globalization;

    public sealed class Context : IPartImportsSatisfiedNotification
    {
        private ComponentType? _filterType = new ComponentType?();
#pragma warning disable 649 // populated with DI, only get this warning because it's declared as private
        [ImportMany(typeof (IComponentProcessor))] private List<IComponentProcessor> _componentProcessors;
#pragma warning restore 649

        private IDictionary<string, IComponentProcessor> _processorElementNameDictionary;
        private IDictionary<ComponentType, IComponentProcessor> _processorTypeDictionary;
        public SolutionPackageType PackageTypeArgument;
        public bool IsManagedPackage;
        public bool UseLcid;

        public CommandAction Action { get; private set; }

        public string ZipFile { get; internal set; }

        public string RootFolder { get; private set; }

        public SolutionInformation SolutionInformation { get; internal set; }

        public Customizations Customizations { get; internal set; }

        public ComponentConfigurationManager ComponentConfigurationManager { get; internal set; }

        public bool IsFilterApplied
        {
            get { return _filterType.HasValue; }
        }

        public string TemplateLcid { get; internal set; }

        public string TemplateIsoCode { get; internal set; }

        public bool Localize { get; private set; }

        public AllowDelete AllowDeletes { get; private set; }

        public AllowWrite AllowWrites { get; private set; }

        public Context(PackagerArguments arguments)
        {
            if (string.IsNullOrWhiteSpace(arguments.PathToZipFile))
                throw new CommandLineException("zip file cannot be empty.");
            Action = arguments.Action;
            RootFolder = arguments.Folder;
            ZipFile = arguments.PathToZipFile;
            PackageTypeArgument = arguments.PackageType;
            IsManagedPackage = arguments.PackageType == SolutionPackageType.Managed;
            AllowDeletes = arguments.AllowDeletes;
            AllowWrites = arguments.AllowWrites;
            var outLcid = string.Empty;
            TemplateIsoCode = ValidateLocaleId(arguments.LocaleTemplate, out outLcid, true);
            TemplateLcid = outLcid;
            Localize = arguments.Localize;
            UseLcid = arguments.UseLcid;
            switch (arguments.SingleComponent.ToUpperInvariant())
            {
                case "WEBRESOURCE":
                    _filterType = ComponentType.WebResource;
                    goto case "NONE";
                case "PLUGIN":
                    _filterType = ComponentType.PluginAssembly;
                    goto case "NONE";
                case "WORKFLOW":
                    _filterType = ComponentType.Workflow;
                    goto case "NONE";
                case "NONE":
                    SolutionInformation = new SolutionInformation();
                    ComponentConfigurationManager = new ComponentConfigurationManager();
                    using (var aggregateCatalog = new AggregateCatalog(new AssemblyCatalog(typeof (Context).Assembly)))
                    {
                        new CompositionContainer(aggregateCatalog).ComposeParts(this);
                        break;
                    }
                default:
                    Logger.Log(TraceLevel.Warning, "Unknown SingleComponent (sc) parameter: {0}. Ignored.", arguments.SingleComponent);
                    goto case "NONE";
            }
        }

        public string ValidateLocaleId(string localeId, out string outLcid, bool returnIsoCode = false)
        {
            var flag = true;
            outLcid = localeId;
            if (!string.IsNullOrWhiteSpace(localeId))
            {
                int result;
                if (int.TryParse(localeId, out result))
                {
                    try
                    {
                        var cultureInfo = new CultureInfo(result);
                        if (cultureInfo.LCID != result)
                            flag = false;
                        if (returnIsoCode)
                            return cultureInfo.Name;
                    }
                    catch (CultureNotFoundException)
                    {
                        flag = false;
                    }
                }
                else
                {
                    try
                    {
                        if (localeId.Equals("Auto", StringComparison.OrdinalIgnoreCase))
                            return string.Empty;
                        var cultureInfo = new CultureInfo(localeId);
                        outLcid = cultureInfo.LCID.ToString();
                        if (returnIsoCode)
                            return cultureInfo.Name;
                    }
                    catch (CultureNotFoundException)
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
                return string.Empty;
            throw new ArgumentException(string.Format(CultureInfo.InvariantCulture,
                "Locale specified for template LCID/ISO:'{0}' is unknown, aborting.", localeId));
        }

        public void OnImportsSatisfied()
        {
            var dictionary1 = new Dictionary<string, IComponentProcessor>();
            var dictionary2 =
                new Dictionary<ComponentType, IComponentProcessor>();
            foreach (var componentProcessor in _componentProcessors)
            {
                componentProcessor.Initialize(this);
                dictionary1.Add(componentProcessor.SupportedElementName, componentProcessor);
                dictionary2.Add(componentProcessor.SupportedComponentType, componentProcessor);
            }
            _processorElementNameDictionary = dictionary1;
            _processorTypeDictionary = dictionary2;
        }

        public IComponentProcessor GetComponentProcessor(string elementName)
        {
            IComponentProcessor componentProcessor;
            _processorElementNameDictionary.TryGetValue(elementName, out componentProcessor);
            return componentProcessor;
        }

        public IComponentProcessor GetComponentProcessor(ComponentType type)
        {
            IComponentProcessor componentProcessor;
            _processorTypeDictionary.TryGetValue(type, out componentProcessor);
            return componentProcessor;
        }

        public bool IsFilteredOut(ComponentType componentType)
        {
            return IsFilterApplied && _filterType.Value != componentType;
        }
    }
}