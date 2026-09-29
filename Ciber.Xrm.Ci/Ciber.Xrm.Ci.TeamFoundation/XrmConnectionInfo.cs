namespace Ciber.Xrm.Ci.TeamFoundation
{
    using Microsoft.Xrm.Client.Windows.Controls.ConnectionDialog;
    using Microsoft.Xrm.Sdk.Discovery;

    public class XrmConnectionInfo
    {
        public string ConnectionString { get; set; }

        public OrganizationDetail Organization { get; set; }

        public AuthenticationTypeCode AuthenticationType { get; set; }

        public XrmConnectionInfo()
        {
            ConnectionString = string.Empty;
            Organization = null;
            AuthenticationType = AuthenticationTypeCode.None;
        }

        public override string ToString()
        {
            return string.Format("{0}", ConnectionString);
        }
    }
}
