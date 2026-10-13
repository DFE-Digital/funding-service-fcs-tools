using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{
    using System.Diagnostics;
    using Newtonsoft.Json;

    [DebuggerDisplay("{TestCaseTitle},{Outcome}")]
    public class TestResult
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "testCaseTitle")]
        public string TestCaseTitle { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("outcome")]
        public string Outcome { get; set; }

        [JsonProperty("durationInMs")]
        public decimal? DurationInMs { get; set; }
    }
}
