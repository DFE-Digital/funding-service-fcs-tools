using System;

namespace TfsBuildRecorder.Helpers
{
    internal interface ILogManager
    {
        void WriteLog(string logMessage);

        void WriteError(Exception ex);
    }
}
