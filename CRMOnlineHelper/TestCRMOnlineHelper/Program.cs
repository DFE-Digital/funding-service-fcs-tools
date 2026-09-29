using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCRMOnlineHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            CRMOnlineHelper.CrmOnlineConnection connection = new CRMOnlineHelper.CrmOnlineConnection();
            Guid id = connection.GetCrmServiceClient(clientID: "b2312120-4944-4f8e-8436-d78a19722c1d", appKey: "YXR3WRuFaeCZdS3bXykWz9pS5FFSdEukXYPTCB8ktFU=", organizationUrl: "https://fcs-dev-at.crm4.dynamics.com"
                                            , tenantId: "educationgovuk.onmicrosoft.com", aadInstance: "https://login.microsoftonline.com/").ConnectedOrgId;

            //GetCrmServiceClient($ClientId,$AppKey,$CrmUrl,$TenantId,$AadInstance)
            Debug.WriteLine (id);

            int sum = connection.Add(5, 10);
            Debug.WriteLine(sum);
        }
    }
}
