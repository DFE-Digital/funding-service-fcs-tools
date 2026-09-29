using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{

    [DebuggerDisplay("{Uri},{Definition.Id},{FinishTime}")]
    public class Build
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("finishTime")]
        public DateTime FinishTime { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("requestedFor")]
        public User RequestedFor { get; set; }

        [JsonProperty("definition")]
        public BuildDefinition Definition { get; set; }

        [JsonProperty("testRuns")]
        public JsonCollection<TestRun> TestRuns { get; set; }


    }

}
