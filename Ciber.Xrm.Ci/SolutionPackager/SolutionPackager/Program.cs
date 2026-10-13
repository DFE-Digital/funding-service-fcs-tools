// Type: Microsoft.Crm.Tools.SolutionPackager.Program
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal static class Program
  {
    private const int GeneralErrorCode = 1;
    private const int CommandLineErrorCode = 2;
    private const int PluginErrorCode = 3;

    [STAThread]
    public static int Main(string[] args)
    {
      PackagerArguments arguments = null;
      var num = 0;
      try
      {
        if (!Environment.CommandLine.ToUpperInvariant().Contains("/NOLOGO") && !Environment.CommandLine.ToUpperInvariant().Contains("/N"))
        {
          Console.WriteLine("SolutionPackger : CRM Solution Packaging Tool [Version {0}]", ((AssemblyFileVersionAttribute) Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyFileVersionAttribute), true)[0]).Version);
          Console.WriteLine("© 2012 Microsoft Corporation.  All rights reserved");
          Console.WriteLine();
        }
        arguments = ParseCommandLine(args);
        VerboseEnvironment();
        new SolutionPackager(arguments).Run();
        if (Logger.AllWarnings.Count > 0)
        {
          var strArray = Logger.AllWarnings.ToArray();
          Logger.Message(TraceLevel.Warning, "{0} warnings encountered", strArray.Length);
          foreach (var messageText in strArray)
            Logger.Message(TraceLevel.Verbose, messageText);
        }
        if (Logger.AllErrors.Count > 0)
        {
          var strArray = Logger.AllErrors.ToArray();
          Logger.Message(TraceLevel.Error, "{0} errors encountered", strArray.Length);
          foreach (var messageText in strArray)
            Logger.Message(TraceLevel.Verbose, messageText);
        }
      }
      catch (CommandLineException ex)
      {
        Logger.Log(TraceLevel.Verbose, ex, "Failed to parse command line arguments.");
        num = 2;
      }
      catch (PluginExecutionException ex)
      {
        Logger.Message(TraceLevel.Error, "Error occurred during execution of plugin '{0}': {1}", ex.PluginName, ex.Message);
        LogExceptionIfLogFileEnabled(arguments, ex);
        num = 3;
      }
      catch (Exception ex)
      {
        Logger.Message(TraceLevel.Error, ex.Message);
        LogExceptionIfLogFileEnabled(arguments, ex);
        num = 1;
      }
      finally
      {
        Trace.Flush();
        if (Debugger.IsAttached)
        {
          Console.WriteLine("Press a key to terminate...");
          Console.ReadKey();
        }
      }
      return num;
    }

    private static PackagerArguments ParseCommandLine(string[] args)
    {
      var packagerArguments = new PackagerArguments();
      if (!Parser.ParseArgumentsWithUsage(args, packagerArguments))
        throw new CommandLineException();
        return packagerArguments;
    }

    private static void VerboseEnvironment()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("SolutionPackager started.");
      stringBuilder.AppendLine("  Arguments:");
      foreach (var str in Environment.GetCommandLineArgs())
      {
        stringBuilder.AppendFormat("    {0}", str);
        stringBuilder.AppendLine();
      }
      stringBuilder.AppendFormat("  Current Directory = {0}", Environment.CurrentDirectory);
      stringBuilder.AppendLine();
      Logger.Log(TraceLevel.Verbose, stringBuilder.ToString());
    }

    private static void LogExceptionIfLogFileEnabled(PackagerArguments arguments, Exception ex)
    {
      if (arguments != null && !string.IsNullOrWhiteSpace(arguments.LogFile))
        Logger.Message(TraceLevel.Error, "See log file '{0}' for details.", arguments.LogFile);
      Logger.Log(TraceLevel.Error, ex);
    }
  }
}
