namespace AtomFeedTestClient.Readers.Fcs
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.ServiceModel.Syndication;
    using System.Xml;

    public abstract class FcsFeedReader : IFeedReader
    {
        public abstract AzureAuthentication AuthenticationCredentials { get; }

        public abstract string BaseAddress { get; }

        public abstract string MostRecentPageUrl { get; }

        public abstract string VendorAtomMediaType { get; }

        public abstract string FeedContentDescription { get; }

        public string ContentTypeFileSuffix => "xml";

        public void Read(Action<int, string> writePage)
        {
            GetLatestItemsThenWalkLinksToTheStart(writePage);
        }

        private void GetLatestItemsThenWalkLinksToTheStart(Action<int, string> writePage)
        {
            string response = CallEndpointAndReturnResultForFullUrl(VendorAtomMediaType, BaseAddress + MostRecentPageUrl /* + "/1000" */); // uncomment code to start at page 1000
            SyndicationFeed feed = SyndicationFeed.Load(new XmlTextReader(new StringReader(response)));
            writePage(ExtractPageNumberFromFeedItem(feed), response);

            SyndicationLink link;
            do
            {
                link = feed.Links.FirstOrDefault(li => li.RelationshipType == "prev-archive");

                if (link != null)
                {
                    response = CallEndpointAndReturnResultForFullUrl(VendorAtomMediaType, link.Uri.ToString());
                    feed = SyndicationFeed.Load(new XmlTextReader(new StringReader(response)));
                    writePage(ExtractPageNumberFromFeedItem(feed), response);
                }
            }
            while (link != null);
        }

        private int ExtractPageNumberFromFeedItem(SyndicationFeed feed)
        {
            if (feed.Links.Any(li => li.RelationshipType == "current"))
            {
                return ExtractPageNumberFromFeedLink(feed.Links.Single(li => li.RelationshipType == "current"));
            }

            return 0;
        }

        private int ExtractPageNumberFromFeedLink(SyndicationLink feedLink)
        {
            string linkUri = feedLink.Uri.AbsoluteUri;
            int pageNumber = int.Parse(linkUri.Substring(linkUri.LastIndexOf("/", StringComparison.Ordinal) + 1));
            return pageNumber;
        }

        private string CallEndpointAndReturnResultForFullUrl(string mediaType, string url)
        {
            using (HttpClient client = GetAuthorizedHttpClient())
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

        private HttpClient GetAuthorizedHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", AuthenticationCredentials.GetAuthenticationResult().AccessToken);
            return client;
        }
    }
}
