// Type: Microsoft.Crm.Tools.SolutionPackager.ArgumentAttribute
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
  public class ArgumentAttribute : Attribute
  {
      private readonly ArgumentType _type;

    public ArgumentType Type
    {
      get
      {
        return _type;
      }
    }

    public bool DefaultShortName
    {
      get
      {
        return null == ShortName;
      }
    }

    public string ShortName { get; set; }

      public bool DefaultLongName
    {
      get
      {
        return null == LongName;
      }
    }

    public string LongName { get; set; }

      public object DefaultValue { get; set; }

      public string ImplicitDefaultValue { get; set; }

    public bool HasDefaultValue
    {
      get
      {
        return null != DefaultValue;
      }
    }

    public bool HasHelpText
    {
      get
      {
        return null != HelpText;
      }
    }

    public string HelpText { get; set; }

      public ArgumentAttribute(ArgumentType type)
    {
      _type = type;
    }
  }
}
