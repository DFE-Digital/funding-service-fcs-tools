using System;
using System.Configuration;
using System.IO;

namespace TfsBuildRecorder.Helpers
{
    class TextFileLogManager : ILogManager
    {
        private readonly string _logPath = ConfigurationManager.AppSettings["LogFilePath"] +
                               ConfigurationManager.AppSettings["LogFileName"] +
                               ConfigurationManager.AppSettings["LogFileExtension"];

        public string LogPath
        {
            get { return _logPath; }
        }

        public void WriteLog(string logMessage)
        {
            using (StreamWriter sw = File.AppendText(LogPath))
            {
                sw.WriteLine(string.Format("{0} - {1}", DateTime.Now, logMessage));
            }
        }

        public void WriteError(Exception ex)
        {
            using (StreamWriter sw = File.AppendText(LogPath))
            {
                sw.WriteLine(string.Format("{0} - The process encountered an error : {1} {2} --------------------------------", DateTime.Now, ex.Message, Environment.NewLine));
            }
        }
    }
}
