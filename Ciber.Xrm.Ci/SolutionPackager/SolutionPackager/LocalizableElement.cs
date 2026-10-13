// Type: Microsoft.Crm.Tools.SolutionPackager.LocalizableElement
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Xml.Linq;

    public sealed class LocalizableElement
  {
    public string Name { get; private set; }

    public XElement Element { get; private set; }

    public string SourceAttribute { get; private set; }

    public string LocaleIdAttribute { get; private set; }

    public string Comment { get; private set; }

    public string Resource
    {
      get
      {
          if (SourceAttribute == null)
          return Element.Value;
          return Element.Attribute(SourceAttribute).Value;
      }
        set
      {
        if (SourceAttribute == ".")
          Element.SetValue(value);
        else
          Element.Attribute(SourceAttribute).SetValue(value);
      }
    }

    public LocalizableElement(string name, XElement element, string sourceAttributeName, string lcidAttributeName, string comment)
    {
      Name = name;
      Element = element;
      SourceAttribute = sourceAttributeName;
      LocaleIdAttribute = lcidAttributeName;
      Comment = comment;
    }

    public static int Compare(LocalizableElement left, LocalizableElement right)
    {
      return string.Compare(left.Name, right.Name, StringComparison.OrdinalIgnoreCase);
    }
  }
}
