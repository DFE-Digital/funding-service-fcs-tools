// Type: Microsoft.Crm.Tools.SolutionPackager.EntityRelationshipProcessor
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;
    using Properties;

    [Export(typeof (IComponentProcessor))]
  internal sealed class EntityRelationshipProcessor : ComponentProcessorBase
  {
    public string CommentFormula = "{EntityRelationship//ReferencingEntityName} {.} for EntityRelationship '{EntityRelationship@Name}'";
    public string CommentFormulaM2M = "{EntityRelationship//IntersectEntityName} {.} for EntityRelationship '{EntityRelationship@Name}'";
    private const string RelationshipDirectoryName = "Relationships";
    private const string NameAttributeName = "Name";
    private const string RelationshipFileExtension = ".xml";

    public EntityRelationshipProcessor()
      : base("EntityRelationships", ComponentType.EntityRelationship)
    {
      IsWriteIndividualComponent = true;
      LocableElementXPaths.Add(new LocalizableElementXPath("//EntityRelationship//displayname", "description", "languagecode", "EntityRelationship@Name", CommentFormula));
      LocableElementXPaths.Add(new LocalizableElementXPath("//EntityRelationship//Description", "description", "languagecode", "EntityRelationship@Name", CommentFormula));
      LocableElementXPaths.Add(new LocalizableElementXPath("//EntityRelationship//CustomLabel", "description", "languagecode", "EntityRelationship@Name", CommentFormula));
    }

    protected override string GetElementResourceName(ComponentType componentType, LocalizableElementXPath query, XElement element)
    {
      var str = base.GetElementResourceName(componentType, query, element);
      if (GetRelativeElement(element, "EntityRelationship/EntityRelationshipType").Value == "ManyToMany")
        str = str + "Ordinal:" + GetRelativeElement(element, "EntityRelationshipRole/AssociationRoleOrdinal").Value;
      return str;
    }

    protected override Component CreateComponent(XElement element)
    {
      return new Component
      {
        ComponentType = ComponentType.EntityRelationship,
        PrimaryName = Helper.GetAttributeValue(element, "Name", true, null),
        Element = element
      };
    }

    public override ComponentCollection ReadFromFiles()
    {
      var mainDirectory = GetMainDirectory(SupportedComponentType);
      var componentPath = GetComponentPath(SupportedComponentType, null);
      if (!File.Exists(componentPath))
        return null;
      Logger.Message(TraceLevel.Verbose, "Reading: {0}", componentPath);
      var element1 = XElement.Load(componentPath);
      var dictionary = ReadRelationshipFiles(mainDirectory);
      foreach (var element2 in element1.Elements("EntityRelationship"))
      {
        var attributeValue = Helper.GetAttributeValue(element2, "Name", true, null);
        XElement xelement;
        if (dictionary.TryGetValue(attributeValue, out xelement))
        {
            if (element2.HasElements)
            throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.DuplicatedRelationshipName, attributeValue));
            element2.Add(xelement.Elements());
        }
      }
      return CreateComponents(element1);
    }

    public override void WriteToFiles(ComponentCollection components)
    {
      WriteRelationshipFiles(GetComponentPath(components.ComponentType, null), components.Element);
    }

    private static IDictionary<string, XElement> ReadRelationshipFiles(string mainDirectory)
    {
      var path = Path.Combine(mainDirectory, "Relationships");
      var dictionary = new Dictionary<string, XElement>();
      if (Directory.Exists(path))
      {
        foreach (var uri in Directory.GetFiles(path, "*.xml"))
        {
          Logger.Message(TraceLevel.Verbose, "Reading: {0}", uri);
          foreach (var element in XElement.Load(uri).Elements("EntityRelationship"))
          {
            var attributeValue = Helper.GetAttributeValue(element, "Name", true, null);
            if (dictionary.ContainsKey(attributeValue))
              throw new DiskReaderException(string.Format(CultureInfo.InvariantCulture, Resources.DuplicatedRelationshipName, attributeValue));
              dictionary.Add(attributeValue, element);
          }
        }
      }
      return dictionary;
    }

    private static void WriteRelationshipFiles(string componentsPath, XElement relationshipsElement)
    {
      var path1 = Path.Combine(Path.GetDirectoryName(componentsPath), "Relationships");
      var localName = relationshipsElement.Name.LocalName;
      var element = new XElement(relationshipsElement);
      var dictionary = new Dictionary<string, XElement>();
      foreach (var xelement1 in element.Elements("EntityRelationship"))
      {
        var relationshipFileName = GetEntityRelationshipFileName(xelement1);
        XElement xelement2;
        if (!dictionary.TryGetValue(relationshipFileName, out xelement2))
        {
          xelement2 = new XElement(localName);
          dictionary.Add(relationshipFileName, xelement2);
        }
        xelement2.Add(new XElement(xelement1));
        xelement1.RemoveNodes();
      }
      foreach (var keyValuePair in dictionary)
        Helper.WriteToFile(Path.Combine(path1, Path.ChangeExtension(keyValuePair.Key, ".xml")), keyValuePair.Value);
      Helper.WriteToFile(componentsPath, element);
    }

    private static string GetEntityRelationshipFileName(XElement relationshipElement)
    {
      var elementValue = Helper.GetElementValue(relationshipElement, "EntityRelationshipType", true, null);
      switch (elementValue)
      {
        case "ManyToMany":
          return Helper.GetElementValue(relationshipElement, "FirstEntityName", true, null);
        case "OneToMany":
          return Helper.GetElementValue(relationshipElement, "ReferencedEntityName", true, null);
        default:
          throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, Resources.UnknownRelationType, elementValue), "relationshipElement");
      }
    }
  }
}
