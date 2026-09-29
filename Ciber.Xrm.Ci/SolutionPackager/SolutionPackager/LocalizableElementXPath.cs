// Type: Microsoft.Crm.Tools.SolutionPackager.LocalizableElementXPath
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
  public sealed class LocalizableElementXPath
  {
    public string XPath { get; internal set; }

    public string ValueAttribute { get; private set; }

    public string LcidAttribute { get; private set; }

    public string UniqueNameFormula { get; private set; }

    public string CommentFormula { get; private set; }

    public LocalizableElementXPath(string query, string valueAttribute, string lcidAttribute, string uniqueNameFormula, string commentFormula)
    {
      XPath = query;
      ValueAttribute = valueAttribute;
      LcidAttribute = lcidAttribute;
      UniqueNameFormula = uniqueNameFormula;
      CommentFormula = commentFormula;
    }

    public void UpdateCommentFormula(string commentFormula)
    {
      CommentFormula = commentFormula;
    }
  }
}
