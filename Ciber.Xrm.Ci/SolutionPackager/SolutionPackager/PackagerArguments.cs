// Type: Microsoft.Crm.Tools.SolutionPackager.PackagerArguments
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System.Diagnostics;
    using System.Globalization;

    public sealed class PackagerArguments
  {
    [Argument(ArgumentType.RequiresValue, HelpText = "When Extracting use to specify dual Managed and Unmanaged operation. When Packing use to specify Managed or Unmanaged from a previous 'Extract Both'.", LongName = "packagetype", ShortName = "p")]
    public SolutionPackageType PackageType = SolutionPackageType.None;
    [Argument(ArgumentType.Required | ArgumentType.RequiresValue, HelpText = "Action to Perform", LongName = "action", ShortName = "a")]
    public CommandAction Action;
    [Argument(ArgumentType.Required | ArgumentType.RequiresValue, HelpText = "The full path to the customization ZIP file: C:\\customization.zip", LongName = "zipfile", ShortName = "z")]
    public string PathToZipFile;
    [Argument(ArgumentType.RequiresValue, DefaultValue = ".", HelpText = "The path to the root folder: C:\\Solutions\\Solution1. When Extracting this will be written to, when Packing this will be read from.", LongName = "folder", ShortName = "f")]
    public string Folder;

    [Argument(ArgumentType.RequiresValue, HelpText = "The path to the log file.", LongName = "log", ShortName = "l")]
    public string LogFile;
    [Argument(ArgumentType.RequiresValue, DefaultValue = TraceLevel.Info, HelpText = "Minimum logging level for log output [Verbose|Info|Warning|Error|Off].", LongName = "errorlevel", ShortName = "e")]
    public TraceLevel ErrorLevel;
    [Argument(ArgumentType.RequiresValue | ArgumentType.Hidden, DefaultValue = "None", HelpText = "Only perform action on a single component type [WebResource|Plugin|Workflow|None].", LongName = "singleComponent", ShortName = "sc")]
    public string SingleComponent;
    [Argument(ArgumentType.RequiresValue, DefaultValue = AllowDelete.Prompt, HelpText = "Dictates if delete operations may occur.", LongName = "allowDelete", ShortName = "ad")]
    public AllowDelete AllowDeletes;
    [Argument(ArgumentType.RequiresValue, DefaultValue = AllowWrite.Yes, HelpText = "Dictates if write operations may occur.", LongName = "allowWrite", ShortName = "aw")]
    public AllowWrite AllowWrites;
    [Argument(ArgumentType.Basic, HelpText = "Enables that files marked read-only can be deleted or overwritten.", LongName = "clobber", ShortName = "c")]
    public bool Clobber;
    [Argument(ArgumentType.RequiresValue, HelpText = "The full path to a mapping xml file: C:\\maps.xml", LongName = "map", ShortName = "m")]
    public string MappingFile;
    [Argument(ArgumentType.Basic, HelpText = "Suppresses the banner.", LongName = "nologo", ShortName = "n")]
    public bool NoLogo;
    [Argument(ArgumentType.ImpliedDefaultValue, HelpText = "Generates a template resource file. Valid only on Extract. Possible Values are auto or an LCID/ISO code of the language you wish to export. When Present, this will extract the string resources from the given locale as a neutral .resx. If auto or just the long or short form of the switch is specified the base locale for the solution will be used.", ImplicitDefaultValue = "Auto", LongName = "sourceLoc", ShortName = "src")]
    public string LocaleTemplate;
    [Argument(ArgumentType.Basic, HelpText = "Extract or merge all string resources into .resx files.", LongName = "localize", ShortName = "loc")]
    public bool Localize;
    [Argument(ArgumentType.Hidden | ArgumentType.Basic, HelpText = "Use LCID's (1033) rather than ISO codes (en-US) for language files; ", LongName = "useLcid", ShortName = "lcid")]
    public bool UseLcid;
    [Argument(ArgumentType.Hidden | ArgumentType.Basic, HelpText = "Do an immediate pack after extract - used for internal testing.", LongName = "RepackOnPackForTesting", ShortName = "test")]
    public bool RepackOnPackForTesting;

    public override string ToString()
    {
      return string.Format(CultureInfo.InvariantCulture, "/Action: {0} /PathToZipFile: {1} /PackageType: {2} /Folder: {3} /ErrorLevel: {4} /LogFile: {5}", (object) Action, (object) PathToZipFile, (object) PackageType, (object) Folder, (object) ErrorLevel, (object) LogFile);
    }
  }
}
