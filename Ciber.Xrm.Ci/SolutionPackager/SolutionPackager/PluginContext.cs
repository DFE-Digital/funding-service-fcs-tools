// Type: Microsoft.Crm.Tools.SolutionPackager.PluginContext
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
  public sealed class PluginContext
  {
    public Context Context { get; private set; }

    internal PluginContext(Context context)
    {
      Context = context;
    }
  }
}
