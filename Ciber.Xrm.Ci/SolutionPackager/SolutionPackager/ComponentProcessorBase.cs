// Type: Microsoft.Crm.Tools.SolutionPackager.ComponentProcessorBase
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using Properties;
    using Extensions = System.Xml.XPath.Extensions;

    internal abstract class ComponentProcessorBase : IComponentProcessor
  {
    internal static Dictionary<string, XElement> Unique = new Dictionary<string, XElement>();
    public List<LocalizableElementXPath> LocableElementXPaths = new List<LocalizableElementXPath>();
    protected Context context;
    protected bool IsSingleComponentElement;
    protected bool IsWriteIndividualComponent;
    protected bool IsFileBackedComponent;
    protected bool IsCollectionComponent;

    public bool IsDifferentInManaged { get; protected set; }

    public string SupportedElementName { get; private set; }

    public ComponentType SupportedComponentType { get; private set; }

    static ComponentProcessorBase()
    {
    }

    protected ComponentProcessorBase(string elementName, ComponentType componentType)
    {
      SupportedElementName = elementName;
      SupportedComponentType = componentType;
    }

    public void Initialize(Context context)
    {
      this.context = context;
    }

    public ComponentCollection CreateComponents(XElement element)
    {
      var componentCollection = new ComponentCollection(SupportedComponentType, element);
      if (IsSingleComponentElement)
      {
        componentCollection.Add(CreateComponent(element));
      }
      else
      {
        foreach (var element1 in GetComponentElements(element))
        {
          var component = CreateComponent(element1);
          if (component != null)
            componentCollection.Add(component);
        }
      }
      return componentCollection;
    }

    public virtual ComponentCollection ReadFromFiles()
    {
      GetMainDirectory(SupportedComponentType);
      if (!IsSingleComponentElement && IsWriteIndividualComponent)
        throw new NotImplementedException();
      var componentPath = GetComponentPath(SupportedComponentType, null);
      if (File.Exists(componentPath))
      {
        Logger.Message(TraceLevel.Verbose, "Reading: {0}", componentPath);
        XElement.Load(componentPath);
        return CreateComponents(XElement.Load(componentPath));
      }
        if (IsFileBackedComponent && Directory.Exists(Path.GetDirectoryName(componentPath)))
        {
            var xelement = new XElement(SupportedElementName);
            ReadCollectionFromFiles(Directory.GetFiles(Path.GetDirectoryName(componentPath), "*.data.xml", SearchOption.AllDirectories), xelement);
            var components = CreateComponents(xelement);
            LoadComponentFiles(components);
            return components;
        }
        else
        {
            if (!IsCollectionComponent)
                return null;
            var mainDirectory = GetMainDirectory(SupportedComponentType);
            var xelement = new XElement(SupportedElementName);
            ReadCollectionFromFolder(mainDirectory, xelement);
            return CreateComponents(xelement);
        }
    }

    public virtual void WriteToFiles(ComponentCollection components)
    {
      if (components.Count == 0 || context.PackageTypeArgument == SolutionPackageType.Both && context.SolutionInformation.IsManaged && !IsDifferentInManaged)
        return;
      if (IsWriteIndividualComponent)
      {
        foreach (var component in components)
          Helper.WriteToFile(GetComponentPath(component), component.Element);
      }
      else if (IsFileBackedComponent)
      {
        foreach (var component in components)
        {
          ShowProcessing(component);
          WriteComponentFile((FileBackedComponent) component);
        }
      }
      else if (IsCollectionComponent)
      {
        foreach (var component in components)
        {
          ShowProcessing(component);
          var primaryName = component.PrimaryName ?? component.Id.ToString("B");
          Helper.WriteToFile(GetComponentPath(components.ComponentType, primaryName), component.Element);
        }
      }
      else
        Helper.WriteToFile(GetComponentPath(components.ComponentType, null), components.Element);
    }

    protected abstract Component CreateComponent(XElement element);

    protected string GetMainDirectory(ComponentType componentType)
    {
      return Path.Combine(context.RootFolder, context.ComponentConfigurationManager.GetConfiguration(componentType).MainDirectory);
    }

    protected virtual void WriteComponentFile(FileBackedComponent fileBackedComponent)
    {
      ComponentFile componentFile;
      if (string.IsNullOrWhiteSpace(fileBackedComponent.FileName) || !context.Customizations.ComponentFiles.TryGetValue(fileBackedComponent.FileName, out componentFile) || componentFile == null)
        return;
      var str = Path.Combine(context.RootFolder, fileBackedComponent.DiskFileName);
      var filename = Path.Combine(context.RootFolder, fileBackedComponent.DiskFileName + ".data.xml");
      if (!Filer.Track.DoesFilenameMap(str))
        Helper.WriteToFile(str, componentFile.Bytes);
      else
        Logger.Message(TraceLevel.Info, "Skipping '{0}' as it matches a mapping directive", str);
      Helper.WriteToFile(filename, fileBackedComponent.Element);
    }

    protected virtual IEnumerable<XElement> GetComponentElements(XElement componentCollectionElement)
    {
      return componentCollectionElement.Elements();
    }

    protected string GetComponentPath(Component component)
    {
      return GetComponentPath(component.ComponentType, component.PrimaryName);
    }

    protected string GetComponentPath(ComponentType componentType, string primaryName)
    {
      var configuration = context.ComponentConfigurationManager.GetConfiguration(componentType);
      var path3 = Regex.Replace(configuration.FileName, "\\$\\(.+?\\)", match =>
      {
          switch (match.Value)
          {
              case "$(PrimaryName)":
                  return primaryName ?? match.Value;
              case "$(type)":
                  return ((object) componentType).ToString();
              case "$(managed)":
                  if (!context.SolutionInformation.IsManaged)
                      return string.Empty;
                  return "_managed";
              default:
                  return match.Value;
          }
      });
      return Path.Combine(context.RootFolder, configuration.MainDirectory, path3);
    }

    protected virtual bool NeedManagedFilename(XElement item)
    {
      return false;
    }

    protected void LoadComponentFiles(ComponentCollection components)
    {
      foreach (var component in components)
      {
        ShowProcessing(component);
        var fileBackedComponent = component as FileBackedComponent;
        if (fileBackedComponent != null && !string.IsNullOrWhiteSpace(fileBackedComponent.FileName))
        {
          var path = Filer.Track.MapFilename(Path.Combine(context.RootFolder, fileBackedComponent.DiskFileName));
          if (!File.Exists(path))
            path = Path.Combine(context.RootFolder, Helper.RemoveLeadingSlash(fileBackedComponent.FileName));
          Logger.Message(TraceLevel.Verbose, "Reading: {0}", path);
          if (!File.Exists(path))
          {
            throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.MissingRequiredFile, Path.GetFullPath(path)));
          }
            var componentFile = new ComponentFile
            {
                Bytes = File.ReadAllBytes(path),
                Uri = new Uri(fileBackedComponent.FileName, UriKind.Relative),
                FileName = fileBackedComponent.FileName
            };
            context.Customizations.ComponentFiles.Add(componentFile.FileName, componentFile);
        }
      }
    }

    protected void WriteCollectionToSubFolders(string folder, XElement collectionContainer, string folderNameAttribute, string itemIdAttribute)
    {
      foreach (var subCollection in collectionContainer.Elements())
        WriteCollectionToFolder(Path.Combine(folder, collectionContainer.Name.LocalName, subCollection.Attribute(folderNameAttribute).Value), subCollection, itemIdAttribute);
    }

    protected void WriteCollectionToFolder(string folder, XElement subCollection, string idElement)
    {
      foreach (var element in subCollection.Elements())
      {
        var str = Path.Combine(folder, element.Element(idElement).Value);
        if (context.IsManagedPackage && IsDifferentInManaged && NeedManagedFilename(element.Parent))
          str = Helper.AppendManagedFileName(str);
        else if (context.PackageTypeArgument == SolutionPackageType.Both && context.SolutionInformation.IsManaged)
          continue;
        if (string.IsNullOrWhiteSpace(Path.GetExtension(str)))
          str = Path.ChangeExtension(str, ".xml");
        Helper.WriteToFile(str, element);
      }
    }

    protected void ReadCollectionFromFolder(string collectionFolder, XElement collection)
    {
      if (!Directory.Exists(collectionFolder) || collection == null)
        return;
      var searchPattern = "*.*";
      if (context.IsManagedPackage && NeedManagedFilename(collection))
        searchPattern = string.Format(CultureInfo.InvariantCulture, "*{0}.*", "_managed");
      var list = new List<string>(Directory.GetFiles(collectionFolder, searchPattern));
      list.Sort();
      if (!context.IsManagedPackage)
      {
        for (var index = 0; index < list.Count; ++index)
        {
          if (Path.GetFileNameWithoutExtension(list[index]).EndsWith("_managed", StringComparison.OrdinalIgnoreCase))
          {
            list.RemoveAt(index);
            --index;
          }
        }
      }
      ReadCollectionFromFiles(list.ToArray(), collection);
    }

    protected void ReadCollectionFromFiles(string[] filenames, XElement subCollection)
    {
      foreach (var str in filenames)
      {
        if (File.Exists(str))
        {
          Logger.Message(TraceLevel.Verbose, "Reading: {0}", str);
          var xelement = XElement.Load(str);
          if (xelement != null)
            subCollection.Add(xelement);
        }
      }
    }

    protected virtual void ShowProcessing(Component component)
    {
      ShowProcessing(component.PrimaryName ?? component.Id.ToString());
    }

    protected virtual void ShowProcessing(string name)
    {
      Logger.Message(TraceLevel.Info, " - {0}", name);
    }

    public virtual Collection<LocalizableElement> GetLocalizableElements(ComponentCollection components)
    {
      var baseLocale = context.SolutionInformation.BaseLocale;
      var collection = new Collection<LocalizableElement>();
      foreach (var query in LocableElementXPaths)
      {
        var expression = string.Format(CultureInfo.InvariantCulture, "{0}[@{1}='{2}']", (object) query.XPath, (object) query.LcidAttribute, (object) baseLocale);
        foreach (var element in Extensions.XPathSelectElements(components.Element, expression))
        {
          var elementResourceName = GetElementResourceName(components.ComponentType, query, element);
          if (elementResourceName.Length > 115)
            Logger.Log(TraceLevel.Warning, "Customer can ignore this warning - Localization name exceeds loc manager name field limit. Name={0}", elementResourceName);
          if (components.ComponentType == ComponentType.EntityRelationship && GetRelativeElement(element, "EntityRelationship/EntityRelationshipType") != null && this is EntityRelationshipProcessor)
          {
            var relationshipProcessor = (EntityRelationshipProcessor) this;
            if (GetRelativeElement(element, "EntityRelationship/EntityRelationshipType").Value.Equals("ManyToMany", StringComparison.OrdinalIgnoreCase))
              query.UpdateCommentFormula(relationshipProcessor.CommentFormulaM2M);
            else if (!query.CommentFormula.Equals(relationshipProcessor.CommentFormula))
              query.UpdateCommentFormula(relationshipProcessor.CommentFormula);
          }
          var comment = ConstructFormula(element, query.CommentFormula);
          var localizableElement = new LocalizableElement(elementResourceName, element.Parent, query.ValueAttribute, query.LcidAttribute, comment);
          collection.Add(localizableElement);
        }
      }
      return collection;
    }

    protected virtual string GetElementResourceName(ComponentType componentType, LocalizableElementXPath query, XElement element)
    {
      var elementAttribute = GetRelativeElementAttribute(element, query.UniqueNameFormula);
      return string.Format(CultureInfo.InvariantCulture, "{0}:{1},{2}", (object) componentType, (object) element.Name.LocalName, (object) elementAttribute);
    }

    protected string GetRelativeElementAttribute(XElement sourceElement, string relativeAttributePath)
    {
      var strArray1 = relativeAttributePath.Split('+');
      string str1 = null;
      foreach (var str2 in strArray1)
      {
        var relativePath = str2;
        string str3 = null;
        if (str2.Contains("@"))
        {
          var strArray2 = str2.Split('@');
          relativePath = strArray2[0];
          str3 = strArray2[1];
        }
        var relativeElement = GetRelativeElement(sourceElement, relativePath);
        if (relativeElement != null)
          str1 = !relativePath.EndsWith(".", StringComparison.OrdinalIgnoreCase) || relativePath.EndsWith("..", StringComparison.OrdinalIgnoreCase) ? (str3 != null ? str1 + relativeElement.Attribute(str3).Value : str1 + relativeElement.Value) : str1 + relativeElement.Name.LocalName;
      }
      return str1;
    }

    public static XElement GetRelativeElement(XElement element, string relativePath)
    {
      var xelement = element;
      var list = new List<string>(relativePath.Split('/'));
      var flag = false;
      var str = string.Empty;
      if (list != null && list.Count > 1)
        str = list[0];
      do
      {
        if (list[0] == "..")
        {
          xelement = xelement.Parent;
          list.RemoveAt(0);
        }
        else if (list[0] == xelement.Name.LocalName || string.IsNullOrWhiteSpace(list[0]) || list[0] == ".")
        {
          if (list[0] == str)
            flag = true;
          list.RemoveAt(0);
        }
        else if (xelement.Element(list[0]) != null)
        {
          xelement = xelement.Element(list[0]);
          list.RemoveAt(0);
        }
        else if (xelement.Parent != null && !flag)
          xelement = xelement.Parent;
        else
          break;
      }
      while (list.Count > 0);
      return xelement;
    }

    protected string ConstructFormula(XElement element, string formula)
    {
      foreach (Match match in new Regex("{(.*?)}", RegexOptions.Compiled | RegexOptions.Singleline).Matches(formula))
      {
        var elementAttribute = GetRelativeElementAttribute(element, match.Groups[1].Value);
        formula = formula.Replace(match.Value, elementAttribute);
      }
      return formula;
    }
  }
}
