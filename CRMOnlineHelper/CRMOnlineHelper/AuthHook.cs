using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRMOnlineHelper
{
    public class AuthHook : IOverrideAuthHookWrapper
    {
        
        private string ClientId { get; set; }
        private string OrganizationUrl { get; set; }
        private string AadInstance { get; set; }
        private string TenantID { get; set; }
        private string AppKey { get; set; }

        public AuthHook(string clientID, string organizationUrl, string aadInstance, string tenantId, string appKey)
        {
            ClientId = clientID;
            OrganizationUrl = organizationUrl;
            AadInstance = aadInstance;
            TenantID = tenantId;
            AppKey = appKey;
        }
        Dictionary<string, AuthenticationResult> accessTokens = new Dictionary<string, AuthenticationResult>();

        public string GetAuthToken(Uri connectedUri)
        {
            if (accessTokens.ContainsKey(connectedUri.Host) && accessTokens[connectedUri.Host].ExpiresOn > DateTime.Now)
            {
                return accessTokens[connectedUri.Host].AccessToken;
            }
            else
            {
                accessTokens[connectedUri.Host] = GetAccessTokenFromAzureAD();
                return accessTokens[connectedUri.Host].AccessToken;
            }

        }

        private AuthenticationResult GetAccessTokenFromAzureAD()
        {
            ClientCredential clientcred = new ClientCredential(ClientId, AppKey);
            
            AuthenticationContext authenticationContext = new AuthenticationContext(AadInstance + TenantID);
            
            return GetAuthenticationResult(authenticationContext, OrganizationUrl, clientcred).Result;

        }

        private async Task<AuthenticationResult> GetAuthenticationResult(AuthenticationContext authenticationContext, string organizationUrl, ClientCredential clientcred)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(organizationUrl, clientcred);
            return authenticationResult;
        }
    }
}
