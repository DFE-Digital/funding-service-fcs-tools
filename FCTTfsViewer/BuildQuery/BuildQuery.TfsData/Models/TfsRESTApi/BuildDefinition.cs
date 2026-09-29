using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{
    
    [DebuggerDisplay("{Name}")]
    public class BuildDefinition
    {
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
         
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "revision")]
        public string Revision { get; set; }
    }

}
