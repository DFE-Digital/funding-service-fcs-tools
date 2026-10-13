namespace AtomFeedTestClient.Readers.Cfs
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    public class AllocationNotificationFeedReader : IFeedReader
    {
        public string BaseAddress => ConfigurationManager.AppSettings["CalculateFundingService:Url"];

        public string FeedContentDescription => "Calculate Funding Service";

        public string ContentTypeFileSuffix => "json";

        private readonly AzureAuthentication _authenticationCredentials = new AzureAuthentication(
            ConfigurationManager.AppSettings["CalculateFundingService:AADInstance"],
            ConfigurationManager.AppSettings["CalculateFundingService:TenantId"],
            ConfigurationManager.AppSettings["CalculateFundingService:ClientId"],
            ConfigurationManager.AppSettings["CalculateFundingService:ClientSecret"],
            ConfigurationManager.AppSettings["CalculateFundingService:Resource"]);

        private const string FirstPageUrl = "/api/v1/allocations/notifications?pageRef=1";

        private const string AtomMediaType = "application/atom+json";

        public void Read(Action<int, string> writePage)
        {
            string currentPageUrl = $"{BaseAddress}{FirstPageUrl}";

            while (true)
            {
                string json = GetHttpResponse(AtomMediaType, currentPageUrl, _authenticationCredentials);

                AtomPage atomPage = JsonConvert.DeserializeObject<AtomPage>(json);

                writePage(atomPage.GetPageNumber(), json);

                if (atomPage.IsLastPage())
                {
                    break;
                }

                currentPageUrl = atomPage.GetNextUrl();
            }
        }

        private static string GetHttpResponse(string mediaType, string url, AzureAuthentication authenticationCredentials)
        {
            using (HttpClient client = GetAuthorizedHttpClient(authenticationCredentials))
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                try
                {
                    HttpResponseMessage content = client.GetAsync(url).Result;
                    content.EnsureSuccessStatusCode();
                    return content.Content.ReadAsStringAsync().Result;
                }
                catch (AggregateException aex)
                {
                    throw aex.InnerExceptions.First();
                }
            }
        }

        private static HttpClient GetAuthorizedHttpClient(AzureAuthentication authenticationCredentials)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", authenticationCredentials.GetAuthenticationResult().AccessToken);
            return client;
        }

        private class AtomPage
        {
            public Link[] Link { get; set;}

            public AtomEntry[] AtomEntry { get; set; }

            public int GetPageNumber()
            {
                string selfUrl = Link.Single(lnk => lnk.Rel == "self").Href;
                return int.Parse(selfUrl.Substring(selfUrl.LastIndexOf("=", StringComparison.Ordinal) + 1));
            }

            public bool IsLastPage()
            {
                string selfUrl = Link.Single(lnk => lnk.Rel == "self").Href;
                string lastUrl = Link.Single(lnk => lnk.Rel == "last").Href;

                return selfUrl == lastUrl;
            }

            public string GetNextUrl()
            {
                return Link.Single(lnk => lnk.Rel == "next").Href;
            }
        }

        private class Link
        {
            public string Href { get; set; }

            public string Rel { get; set; }
        }

        private class AtomEntry
        {
            public string Id { get; set; }

            public DateTime Published { get; set; } 
        }
    }
}
