using System;
using System.Configuration;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using Flurl.Http.Configuration;

namespace CPDSTestClient
{
    class Program
    {
        public static async Task Main()
        {
            // done once at the beginning, and the IFlurlClientFactory would be a singleton IoC container injected into the objects needing it
            using IFlurlClientFactory flurlFactory = new PerBaseUrlFlurlClientFactory();
            SetupFlurl(flurlFactory);

            // CPDS by WCF Service Contract
            CPDSClient.GetProviderSummaryByServiceContract();
            CPDSClient.GetProvidersByUkprnByServiceContract();

            // CPDS by Flurl web request
            await CPDSClient.GetProviderSummaryByFlurl(flurlFactory);
            await CPDSClient.GetProvidersByUkprnByFlurl(flurlFactory);
        }


        static void SetupFlurl(IFlurlClientFactory flurlFactory)
        {
            // find the certificates by thumbprint in the appSettings from the location in the config
            X509Store certStore = new X509Store(StoreName.My, (StoreLocation)Enum.Parse(typeof(StoreLocation), ConfigurationManager.AppSettings["CertificateStoreLocation"]));
            certStore.Open(OpenFlags.ReadOnly);
            var cpdsClientCertCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, ConfigurationManager.AppSettings["CPDSCertificateThumbprint"], true);
            certStore.Close();

            // then for each of the clients set up the FlurlFactory and it will return a singleton client per Url configured
            if (cpdsClientCertCollection.Count == 1)
            {
                var cpdsCert = cpdsClientCertCollection[0];
                var cpdsUrl = ConfigurationManager.AppSettings["CPDSUrl"];
                flurlFactory.ConfigureClient($"{cpdsUrl}", cli =>
                {
                    cli.Settings.HttpClientFactory = new X509HttpFactory(cpdsCert);
                });
            }
        }

        class X509HttpFactory : DefaultHttpClientFactory
        {
            private readonly X509Certificate2 _cert;

            public X509HttpFactory(X509Certificate2 cert)
            {
                _cert = cert;
            }

            public override HttpMessageHandler CreateMessageHandler()
            {
                var handler = new WebRequestHandler();
                handler.ClientCertificates.Add(_cert);
                return handler;
            }
        }

    }
}
