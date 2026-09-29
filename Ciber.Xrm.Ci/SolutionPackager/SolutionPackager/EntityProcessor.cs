// Type: Microsoft.Crm.Tools.SolutionPackager.EntityProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    [Export(typeof(IComponentProcessor))]
    internal sealed class EntityProcessor : ComponentProcessorBase
    {
        public EntityProcessor()
            : base("Entities", ComponentType.Entity)
        {
            IsWriteIndividualComponent = true;
            IsDifferentInManaged = true;
            var uniqueNameFormula1 = "entity@Name+entity/.+../..@Name";
            var commentFormula1 = " '{entity@Name}' : {.} for Entity";
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/LocalizedNames/LocalizedName", "description", "languagecode", uniqueNameFormula1, commentFormula1));
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/LocalizedCollectionNames/LocalizedCollectionName", "description", "languagecode", uniqueNameFormula1, commentFormula1));
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/Descriptions/Description", "description", "languagecode", uniqueNameFormula1, commentFormula1));
            var uniqueNameFormula2 = "entity@Name+attribute@PhysicalName";
            var commentFormula2 = "'{entity@Name}' : {.} for Attribute '{attribute@PhysicalName}' on Entity";
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/displaynames/displayname", "description", "languagecode", uniqueNameFormula2, commentFormula2));
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/Descriptions/Description", "description", "languagecode", uniqueNameFormula2, commentFormula2));
            var uniqueNameFormula3 = "entity@Name+optionset@Name";
            var commentFormula3 = "'{entity@Name}' : {.} for OptionSet '{optionset@Name}' on Entity";
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/optionset/displaynames/displayname", "description", "languagecode", uniqueNameFormula3, commentFormula3));
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/optionset/Descriptions/Description", "description", "languagecode", uniqueNameFormula3, commentFormula3));
            var commentFormula4 = "'{entity@Name}' : {.} for {../../.} '{../..@value}' on Entity";
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/optionset/options/option/labels/label", "description", "languagecode", uniqueNameFormula3 + "+option@value", commentFormula4));
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/optionset/statuses/status/labels/label", "description", "languagecode", uniqueNameFormula3 + "+status@value", commentFormula4));
            LocableElementXPaths.Add(new LocalizableElementXPath("//entity/attributes/attribute/optionset/states/state/labels/label", "description", "languagecode", uniqueNameFormula3 + "+state@value", commentFormula4));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/FormXml//label", "description", "languagecode", "Entity/Name@LocalizedName+../..@id", "'{Entity/Name@LocalizedName}' : {.} for {../../.} in Entity FormXml ID: '{../../@id}'"));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/FormXml//Title", "Text", "LCID", "Entity/Name@LocalizedName+../..@Id+systemform/formid", "'{Entity/Name@LocalizedName}' : {.} for {../../.} in Entity FormXml ID: '{../../@Id}'"));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/FormXml/forms/systemform/LocalizedNames/LocalizedName", "description", "languagecode", "Entity/Name@LocalizedName+systemform/formid", "'{Entity/Name@LocalizedName}' : {.} for {../../.} in Entity FormXml ID: '{systemform/formid}'"));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/FormXml/forms/systemform/Descriptions/Description", "description", "languagecode", "Entity/Name@LocalizedName+systemform/formid", "'{Entity/Name@LocalizedName}' : {.} for {../../.} in Entity FormXml ID: '{systemform/formid}'"));
            var uniqueNameFormula4 = "Entity/Name@LocalizedName+savedquery/savedqueryid";
            var commentFormula5 = "'{Entity/Name@LocalizedName}' : {.} for SavedQuery on Entity QueryId: '{savedquery/savedqueryid}'";
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/SavedQueries//LocalizedName", "description", "languagecode", uniqueNameFormula4, commentFormula5));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/SavedQueries//Description", "description", "languagecode", uniqueNameFormula4, commentFormula5));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/Strings/Strings/String", null, "languagecode", "Strings@ResourceKey+Entity/Name@LocalizedName", "'{Entity/Name@LocalizedName}' : {.} for string on Entity ID: {Strings@ResourceKey}"));
            var commentFormula6 = "'{Entity/Name@LocalizedName}' : {.} for Visualization '{visualization/savedqueryvisualizationid}' on  Entity";
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/Visualizations/visualization/LocalizedNames/LocalizedName", "description", "languagecode", "Entity/Name@LocalizedName+visualization/savedqueryvisualizationid", commentFormula6));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/Visualizations/visualization/Descriptions/Description", "description", "languagecode", "Entity/Name@LocalizedName+visualization/savedqueryvisualizationid", commentFormula6));
            LocableElementXPaths.Add(new LocalizableElementXPath("//Entity/RibbonDiffXml/LocLabels/LocLabel/Titles/Title", "description", "languagecode", "Entity/Name@LocalizedName+LocLabel@Id", "'{Entity/Name@LocalizedName}' : {.} for LocLabel on Entity ID: '{LocLabel@Id}'"));
        }

        protected override Component CreateComponent(XElement element)
        {
            return new Component
            {
                ComponentType = ComponentType.Entity,
                PrimaryName = Helper.GetElementValue(element, "Name", true, null),
                Element = element
            };
        }

        public override ComponentCollection ReadFromFiles()
        {
            var mainDirectory = GetMainDirectory(SupportedComponentType);
            var element = new XElement(SupportedElementName);
            if (Directory.Exists(mainDirectory))
            {
                foreach (var entityDirectory in Directory.GetDirectories(mainDirectory))
                {
                    var xelement = ReadEntityDirectory(entityDirectory);
                    if (xelement != null)
                        element.Add(xelement);
                }
            }
            return CreateComponents(element);
        }

        public override void WriteToFiles(ComponentCollection components)
        {
            foreach (var component in components)
            {
                ShowProcessing(component);
                var componentPath = GetComponentPath(component);
                var directoryName = Path.GetDirectoryName(componentPath);
                var element = new XElement(component.Element.Name);
                foreach (var xelement1 in component.Element.Elements())
                {
                    XElement xelement2;
                    switch (xelement1.Name.LocalName)
                    {
                        case "FormXml":
                            WriteCollectionToSubFolders(directoryName, xelement1, "type", "FormId".ToLowerInvariant());
                            xelement2 = new XElement("FormXml");
                            break;
                        case "SavedQueries":
                            WriteCollectionToFolder(Path.Combine(directoryName, "SavedQueries"), xelement1.Element("SavedQueries".ToLowerInvariant()), "savedqueryid");
                            xelement2 = new XElement("SavedQueries");
                            break;
                        case "Visualizations":
                            WriteCollectionToFolder(Path.Combine(directoryName, "Visualizations"), xelement1, "savedqueryvisualizationid");
                            xelement2 = new XElement("Visualizations");
                            break;
                        case "RibbonDiffXml":
                            Helper.WriteToFile(Path.Combine(directoryName, Path.ChangeExtension("RibbonDiff.xml", ".xml")), xelement1);
                            xelement2 = new XElement(xelement1.Name);
                            break;
                        default:
                            xelement2 = xelement1;
                            break;
                    }
                    element.Add(xelement2);
                }
                Helper.WriteToFile(componentPath, element);
            }
        }

        protected override bool NeedManagedFilename(XElement item)
        {
            return item.Name.LocalName == "forms";
        }

        private XElement ReadEntityDirectory(string entityDirectory)
        {
            ShowProcessing(Path.GetFileName(entityDirectory));
            var xelement1 = ReadSubComponent(entityDirectory, "Entity");
            if (xelement1 == null)
                return null;
            ReadFormXmlCollectionsFromFolder(Path.Combine(entityDirectory, "FormXml"), xelement1.Element("FormXml"), "forms".ToLowerInvariant(), "type".ToLowerInvariant());
            if (xelement1.Element("SavedQueries") != null)
            {
                var collection = new XElement("SavedQueries".ToLowerInvariant());
                xelement1.Element("SavedQueries").Add(collection);
                ReadCollectionFromFolder(Path.Combine(entityDirectory, "SavedQueries"), collection);
            }
            ReadCollectionFromFolder(Path.Combine(entityDirectory, "Visualizations"), xelement1.Element("Visualizations"));
            var xelement2 = ReadSubComponent(entityDirectory, "RibbonDiff.xml");
            if (xelement2 != null)
                xelement1.Element(xelement2.Name).ReplaceWith(xelement2);
            return xelement1;
        }

        private void ReadFormXmlCollectionsFromFolder(string folder, XElement collectionContainer, string collectionNodeName, string collectionAttribute)
        {
            if (!Directory.Exists(folder) || collectionContainer == null)
                return;
            var directories = new List<string>(Directory.EnumerateDirectories(folder).OrderByDescending(filename => filename));

            var list = new List<XElement>();
            foreach (var str in directories)
            {
                var fileName = Path.GetFileName(str);
                var collection = new XElement(collectionNodeName);
                collection.Add(new XAttribute(collectionAttribute, fileName));
                ReadCollectionFromFolder(str, collection);
                list.Add(collection);
            }
            list.Sort((formCollectionA, formCollectionB) =>
            {
                if (formCollectionA.Element("systemform") == null && formCollectionB.Element("systemform") == null)
                    return 0;
                if (formCollectionA.Element("systemform") == null)
                    return -1;
                if (formCollectionB.Element("systemform") == null)
                    return 1;
                return string.CompareOrdinal(formCollectionA.Element("systemform").Element("FormId".ToLower(CultureInfo.InvariantCulture)).Value, formCollectionB.Element("systemform").Element("FormId".ToLower(CultureInfo.InvariantCulture)).Value);
            });
            foreach (var xelement in list)
            {
                if (xelement.HasElements)
                    collectionContainer.Add(xelement);
            }
        }

        private static XElement ReadSubComponent(string entityDirectory, string componentName)
        {
            var str = Path.Combine(entityDirectory, Path.ChangeExtension(componentName, ".xml"));
            if (!File.Exists(str))
                return null;
            Logger.Message(TraceLevel.Verbose, "Reading: {0}", str);
            return XElement.Load(str);
        }
    }
}