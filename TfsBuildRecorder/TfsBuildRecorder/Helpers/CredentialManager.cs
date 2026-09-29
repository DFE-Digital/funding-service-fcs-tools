using System.Configuration;
using System.Net;
using Microsoft.TeamFoundation.Client;

namespace TfsBuildRecorder.Helpers
{
    static class CredentialManager
    {
        private static readonly string _tfsUsername = ConfigurationManager.AppSettings["TfsUsername"];
        private static readonly string _tfsPassword = ConfigurationManager.AppSettings["TfsPassword"];
        private static readonly string _tfsDomain = ConfigurationManager.AppSettings["TfsDomain"];

        private static string TfsUsername
        {
            get { return _tfsUsername; }
        }

        private static string TfsPassword
        {
            get { return _tfsPassword; }
        }

        private static string TfsDomain
        {
            get { return _tfsDomain; }
        }

        public static TfsClientCredentials GetTfsCredentials()
        {
            // Auth with UserName & Password (Microsoft Acc):
            var basicCred =
                new BasicAuthCredential(new NetworkCredential(TfsUsername, TfsPassword, TfsDomain));
            return new TfsClientCredentials(basicCred) {AllowInteractive = false};
        }
    }
}
