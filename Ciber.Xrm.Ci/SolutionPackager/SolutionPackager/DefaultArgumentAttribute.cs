// Type: Microsoft.Crm.Tools.SolutionPackager.DefaultArgumentAttribute
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
  public sealed class DefaultArgumentAttribute : ArgumentAttribute
  {
    public DefaultArgumentAttribute(ArgumentType type)
      : base(type)
    {
    }
  }
}
