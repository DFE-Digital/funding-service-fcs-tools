// Type: Microsoft.Crm.Tools.SolutionPackager.CommandLineException
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;

    [Serializable]
  public sealed class CommandLineException : Exception
  {
    public CommandLineException()
    {
    }

    public CommandLineException(string message)
      : base(message)
    {
    }

    public CommandLineException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
