// Type: Microsoft.Crm.Tools.SolutionPackager.ArgumentType
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;

    [Flags]
  public enum ArgumentType
  {
    Required = 1,
    Unique = 2,
    Multiple = 4,
    AtMostOnce = 0,
    LastOccurrenceWins = Multiple,
    MultipleUnique = LastOccurrenceWins | Unique,
    RequiresValue = 8,
    Hidden = 16,
    Basic = 32,
    ImpliedDefaultValue = 64
  }
}
