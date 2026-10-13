using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMOnlineHelper
{
    public class CrmOnlineConnection
    {
        public CrmServiceClient GetCrmServiceClient(string clientID, string appKey, string organizationUrl, string tenantId, string aadInstance)
        {
            AuthHook hook = new AuthHook(clientID,organizationUrl,aadInstance,tenantId, appKey);
            CrmServiceClient.AuthOverrideHook = hook;
            return new CrmServiceClient(GetServiceUrl(organizationUrl), useUniqueInstance: true);

        }
        private  Uri GetServiceUrl(string organizationUrl)
        {
            //https://fcs-dev.api.crm4.dynamics.com/XRMServices/2011/Organization.svc
            return new Uri(organizationUrl + @"/xrmservices/2011/organization.svc/web?SdkClientVersion=8.2");
        }

        public int Add (int x, int y)
        {
            return x + y;
        }
    }
}
