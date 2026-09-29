namespace AtomFeedTestClient.Readers
{
    using System.Security.Authentication;
    using System.Threading;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    public class AzureAuthentication
    {
        private readonly string _aadInstance;
        private readonly string _tenantId;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _resource;

        public AzureAuthentication(string aadInstance, string tenantId, string clientId, string clientSecret, string resource)
        {
            _aadInstance = aadInstance;
            _tenantId = tenantId;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _resource = resource;
        }

        public AuthenticationResult GetAuthenticationResult()
        {
            string authority = string.Format(_aadInstance, _tenantId);
            AuthenticationContext authContext = new AuthenticationContext(authority);
            ClientCredential clientCredential = new ClientCredential(_clientId, _clientSecret);

            AuthenticationResult authResult = null;
            int retryCount = 0;
            bool retry;

            do
            {
                retry = false;
                try
                {
                    authResult = authContext.AcquireToken(_resource, clientCredential);
                    return authResult;
                }
                catch (AdalException ex)
                {
                    if (ex.ErrorCode == "temporarily_unavailable")
                    {
                        retry = true;
                        retryCount++;
                        Thread.Sleep(3000);
                    }
                }
            }
            while (retry && (retryCount < 3));

            if (authResult == null)
            {
                throw new AuthenticationException("Could not authenticate with the OAUTH2 claims provider after several attempts");
            }

            return authResult;
        }
    }
}
