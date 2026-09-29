using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace CPDSTestClient
{
    class CPDSClient
    {
        public static void GetProviderSummaryByServiceContract()
        {
            using var client = new GatewayServiceContractClient();

            var response = client.GetProviderSummaryByName(new GProvByNameRequest(string.Empty));
            var xDoc = XDocument.Parse(response.RawCPDSResponse);
        }

        public static async Task GetProviderSummaryByFlurl(IFlurlClientFactory factory)
        {
            var rawXmlRequest = "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><TradingName xmlns=\"http://schemas.sfa.gov.uk/cpds.gatewayservice\"/></s:Body></s:Envelope>";
            var xDoc = await CPDSQuery(factory, "GetProviderSummaryByName", rawXmlRequest);
        }

        public static void GetProvidersByUkprnByServiceContract()
        {
            using var client = new GatewayServiceContractClient();

            var ukprnCollection = new schemas.sfa.gov.uk.cpds.gatewayservice.UKPRNCollection
            {
                new schemas.sfa.gov.uk.cpds.gatewayservice.UKPRN
                {
                    UKPRNData = "10004486"
                }
            };

            var response = client.GetProvidersByUKPRN(new GProvByUKPRINRequest(ukprnCollection));
            var xDoc = XDocument.Parse(response.RawCPDSResponse);
        }

        public static async Task GetProvidersByUkprnByFlurl(IFlurlClientFactory factory)
        {
            var ukprnList = new List<string> { "10004486" };
            StringBuilder ukprns = new StringBuilder();
            foreach (string ukprn in ukprnList.Select(n => $"<UKPRN><UKPRNData>{n}</UKPRNData></UKPRN>"))
            {
                ukprns.Append(ukprn);
            }
            var rawXmlRequest = $"<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><UKPRNs xmlns=\"http://schemas.sfa.gov.uk/cpds.gatewayservice\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">{ukprns}</UKPRNs></s:Body></s:Envelope>";

            var xDoc = await CPDSQuery(factory, "GetProvidersByUKPRN", rawXmlRequest);
        }

        public static async Task<XDocument> CPDSQuery(IFlurlClientFactory factory, string SOAPAction, string rawXmlRequest)
        {

            var cpdsUrl = ConfigurationManager.AppSettings["CPDSUrl"];
            var query = await
                factory
                .Get(cpdsUrl)
                .Request()
                .WithHeader("SOAPAction", $"\"{SOAPAction}\"")
                .WithHeader("Content-Type", "text/xml; charset=utf-8")
                .SendStringAsync(HttpMethod.Post, rawXmlRequest);

            var response = await query.Content.ReadAsStringAsync();
            Regex findRawResponse = new Regex("<RawCPDSResponse xmlns=\"http://schemas.sfa.gov.uk/cpds.gatewayservice\">(?<rawResponse>.*)</RawCPDSResponse>");
            var match = findRawResponse.Match(response);

            var htmlEncodedResponse = match.Groups["rawResponse"].Value;
            var decodedResponse = HttpUtility.HtmlDecode(htmlEncodedResponse);

            XDocument xDoc = XDocument.Parse(decodedResponse);

            return xDoc;
        }
    }
}
