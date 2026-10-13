// Type: Microsoft.Crm.Tools.Logger
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text;

    public static class Logger
  {
    private static readonly TraceSwitch TraceSwitch = new TraceSwitch("DefaultSwitch", string.Empty, "Info");

    public static Collection<string> AllWarnings { get; private set; }

    public static Collection<string> AllErrors { get; private set; }

    public static TraceLevel Level
    {
      get
      {
        return TraceSwitch.Level;
      }
      set
      {
        TraceSwitch.Level = value;
      }
    }

    static Logger()
    {
      AllWarnings = new Collection<string>();
      AllErrors = new Collection<string>();
    }

    public static void Log(TraceLevel level, string message)
    {
      WriteLog(level, message);
    }

    public static void Log(TraceLevel level, string message, params object[] args)
    {
      WriteLog(level, string.Format(CultureInfo.InvariantCulture, message, args));
    }

    public static void Log(TraceLevel level, Exception exception)
    {
      WriteLog(level, exception.ToString());
    }

    public static void Log(TraceLevel level, Exception exception, string message, params object[] args)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat(CultureInfo.InvariantCulture, message, args);
      stringBuilder.AppendLine();
      stringBuilder.Append(exception);
      WriteLog(level, stringBuilder.ToString());
    }

    public static void Message(TraceLevel level, string messageText)
    {
      WriteMessage(level, messageText);
    }

    public static void Message(TraceLevel level, string messageText, params object[] args)
    {
      WriteMessage(level, string.Format(CultureInfo.InvariantCulture, messageText, args));
    }

    public static void Message(TraceLevel level, Exception exception, string msg, params object[] args)
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat(CultureInfo.InvariantCulture, msg, args);
      stringBuilder.AppendLine();
      stringBuilder.Append(exception);
      WriteLog(level, stringBuilder.ToString());
    }

    private static void WriteLog(TraceLevel level, string message)
    {
      var message1 = string.Format(CultureInfo.InvariantCulture, "{0} - {1}\t{2}", (object) DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture), (object) ((object) level).ToString(), (object) message);
      if (level > Level)
        return;
      Trace.WriteLine(message1);
    }

    private static void WriteMessage(TraceLevel level, string message)
    {
        var foregroundColor = Console.ForegroundColor;
        try
        {
            if (level <= Level)
            {
                switch (level)
                {
                    case TraceLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        AllErrors.Add(message);
                        break;
                    case TraceLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        AllWarnings.Add(message);
                        break;
                    case TraceLevel.Verbose:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                }
                Console.WriteLine(message);
            }
        }
        finally
        {
            Console.ForegroundColor = foregroundColor;
        }
        WriteLog(level, message);
    }
  }
}
