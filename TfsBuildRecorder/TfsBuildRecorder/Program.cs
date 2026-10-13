using System;
using TfsBuildRecorder.Helpers;

namespace TfsBuildRecorder
{
    internal class Program
    {
        private static readonly BuildRecorder BuildRecorder = new BuildRecorder();
        private static readonly ILogManager _logger = new TextFileLogManager();

        private static ILogManager Logger
        {
            get { return _logger; }
        }

        private static void Main(string[] args)
        {
            try
            {
                Logger.WriteLog("Started the build recorder.");

                BuildRecorder.Start();
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                Logger.WriteLog("Something went wrong and the process did not complete.");
            }
        }
    }
}
