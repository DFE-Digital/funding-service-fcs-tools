using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{
    [DebuggerDisplay("{Name},{TotalTests},{State}")]
    public class TestRun
    {
                 
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("build")]
        public Build Build { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("totalTests")]
        public int? TotalTests { get; set; }

        [JsonProperty("passedTests")]
        public int? PassedTests { get; set; }

        [JsonProperty("failedTests")]
        public int? FailedTests { get; set; }

        [JsonProperty("unanalyzedTests")]
        public int? UnanalyzedTests { get; set; }

        [JsonProperty("testResults")]
        public JsonCollection<TestResult> TestResults { get; set; }
    }
}
