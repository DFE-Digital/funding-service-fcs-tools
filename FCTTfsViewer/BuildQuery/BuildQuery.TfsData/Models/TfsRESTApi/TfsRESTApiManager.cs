using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{
    public class TfsRESTApiManager
    {
        private NetworkCredential _tfsCredential;
       
        public struct TfsAPI
        {
            public const string V2 = "2.0";
        }

        public struct TfsProject
        {
            public const string Fct = "FCT";
        }

        public struct MediaType
        {
            public const string JSON_MEDIA_TYPE = "application/json";
            public const string JSON_PATCH_MEDIA_TYPE = "application/json-patch+json";
            public const string HTML_MEDIA_TYPE = "text/html";
            public const string OCTET_STREAM = "application/octet-stream";
            public const string ZIP = "application/zip";
        }


        private string _rootUrl;
        private IHttpRequestHeaderFilter _authProvider;

       

        public TfsRESTApiManager(string rootUrl, IHttpRequestHeaderFilter authProvider, NetworkCredential  credential)
        {
            _rootUrl = rootUrl;
            _authProvider = authProvider;
            _tfsCredential = credential;

        }

        protected string ApiVersion
        {
            get { return TfsAPI.V2; }
        }
        protected string ProjectName
        {
            get { return TfsProject.Fct; }
        }

        public async Task<JsonCollection<BuildDefinition>> GetBuildDefinitions(string type=null)
        {
            string response;
            if (type == null)
            {
                response = await GetResponse("build/definitions");
            }
            else
            {
                var args = new Dictionary<string, object>();
                args.Add("type", type);
                response = await GetResponse("build/definitions", args);

            }
            return JsonConvert.DeserializeObject<JsonCollection<BuildDefinition>>(response);
        }

        public async Task<BuildDefinition> GetBuildDefinition(int definitionId)
        {
            string response = await GetResponse(string.Format("build/definitions/{0}", definitionId));
            return JsonConvert.DeserializeObject<BuildDefinition>(response);
        }

        public async Task<JsonCollection<Build>> GetLatestBuilds(IEnumerable<int> definitionIds)
        {
            var args = new Dictionary<string, object>();
            args.Add("definitions", string.Join<int>(",", definitionIds));
            args.Add("maxBuildsPerDefinition", 1);
            args.Add("minFinishTime", DateTime.Now.AddDays(-30));

            string response = await GetResponse("build/builds", args);
            return JsonConvert.DeserializeObject<JsonCollection<Build>>(response);
        }
        public async Task<JsonCollection<Build>> GetLatestCompletedBuilds(IEnumerable<int> definitionIds)
        {
            var args = new Dictionary<string, object>();
            args.Add("definitions", string.Join<int>(",", definitionIds));
            args.Add("maxBuildsPerDefinition", 1);
            args.Add("minFinishTime", DateTime.Now.AddDays(-30));
            args.Add("statusFilter", "completed");
            string response = await GetResponse("build/builds", args);
            return JsonConvert.DeserializeObject<JsonCollection<Build>>(response);
        }
        public async Task<JsonCollection<TestRun>> GetTestRunsForBuild(int buildId)
        {
            var args = new Dictionary<string, object>();
            args.Add("buildUri", string.Format("vstfs%3a%2f%2f%2fBuild%2fBuild%2f{0}", buildId));
            args.Add("includeRunDetails", true);
            
            string response = await GetResponse("test/runs", args);
            return JsonConvert.DeserializeObject<JsonCollection<TestRun>>(response);
        }

        public async Task<JsonCollection<TestResult>> GetTestResultsForRun(int testRunId)
        {
            var args = new Dictionary<string, object>();
            args.Add("api-version", "1.0");
            
            string response = await GetResponse(string.Format("test/runs/{0}/results", testRunId),args);
            return JsonConvert.DeserializeObject<JsonCollection<TestResult>>(response);
        }
        protected async Task<string> GetResponse(string path)
        {
            return await GetResponse(path, new Dictionary<string, object>());
        }

        protected async Task<string> GetResponse(string path, IDictionary<string, object> arguments, string mediaType = MediaType.JSON_MEDIA_TYPE)
        {
            using (HttpClient client = GetHttpClient(mediaType))
            {
                using (HttpResponseMessage response = client.GetAsync(ConstructUrl(path, arguments)).Result)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    CheckResponse(response, responseBody);

                    return responseBody;
                }
            }
        }

        private string ConstructUrl(string path)
        {
            return ConstructUrl(path, new Dictionary<string, object>());
        }

        protected virtual string ConstructUrl(string path, IDictionary<string, object> arguments)
        {
            if (!arguments.ContainsKey("api-version"))
            {
                arguments.Add("api-version", ApiVersion);

            }

            StringBuilder resultUrl = new StringBuilder(
                string.IsNullOrEmpty(ProjectName) ?
                string.Format("{0}/_apis/", _rootUrl) :
                string.Format("{0}/{1}/_apis/", _rootUrl, ProjectName));

            if (!string.IsNullOrEmpty(path))
            {
                resultUrl.AppendFormat("/{0}", path);
            }

            resultUrl.AppendFormat("?{0}", string.Join("&", arguments.Where(kvp => kvp.Value != null).Select(kvp =>
            {
                if (kvp.Value is IEnumerable<string>)
                {
                    return string.Join("&", ((IEnumerable<string>)kvp.Value).Select(v => string.Format("{0}={1}", kvp.Key, v)));
                }
                else
                {
                    return string.Format("{0}={1}", kvp.Key, kvp.Value);
                }
            }
                )));
            return resultUrl.ToString();
        }
    


    private void CheckResponse(HttpResponseMessage response, object responseBody)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (responseBody is string)
                {
                    throw JsonConvert.DeserializeObject<TfsException>((string)responseBody);
                }
                else
                {
                    throw new TfsException(string.Format("{0}", response.StatusCode));
                }
            }
            else if (response.StatusCode == HttpStatusCode.NonAuthoritativeInformation)
            {
                throw new TfsException(HttpStatusCode.NonAuthoritativeInformation.ToString());
            }
        }


        private HttpClient GetHttpClient(string mediaType = MediaType.JSON_MEDIA_TYPE)
        {
            var httpClientHandler = new System.Net.Http.HttpClientHandler
            {
                Credentials = _tfsCredential
            };
            httpClientHandler.PreAuthenticate = true;
            var client = new HttpClient(httpClientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            //_authProvider.ProcessHeaders(client.DefaultRequestHeaders);
            
            return client;
        }



    }
}
