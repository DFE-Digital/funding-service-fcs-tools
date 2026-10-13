namespace Ciber.Xrm.Ci.Common
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Xrm.Client;

    public class CrmConnectionConverter
    {
        [SuppressMessage("Microsoft.Contracts", "TestAlwaysEvaluatingToAConstant", Justification = "Credentials can be null if not properly wired.")]
        public static CrmConnectionAttributes ConvertFromConnectionString(string connectionString)
        {
            var connectionAttributes = new CrmConnectionAttributes();
            var crmConnection = CrmConnection.Parse(connectionString);
            var serviceUri = crmConnection.ServiceUri;
            connectionAttributes.Protocol = serviceUri.Scheme;
            connectionAttributes.Port = serviceUri.Port.ToString();

            if (crmConnection.ClientCredentials != null && crmConnection.ClientCredentials.Windows.ClientCredential != null)
            {
                connectionAttributes.Domain = crmConnection.ClientCredentials.Windows.ClientCredential.Domain;
                connectionAttributes.UserName = crmConnection.ClientCredentials.Windows.ClientCredential.UserName;
                connectionAttributes.Password = crmConnection.ClientCredentials.Windows.ClientCredential.Password;
            }
            else if (crmConnection.ClientCredentials != null)
            {
                connectionAttributes.UserName = crmConnection.ClientCredentials.UserName.UserName;
                connectionAttributes.Password = crmConnection.ClientCredentials.UserName.Password;
            }

            return connectionAttributes;
        }
    }
}
