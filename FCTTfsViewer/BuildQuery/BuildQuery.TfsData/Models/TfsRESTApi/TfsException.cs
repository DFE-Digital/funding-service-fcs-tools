using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildQuery.TfsData.Models.TfsRESTApi
{
    
    [JsonObject(MemberSerialization.OptIn)]
    public class TfsException : Exception
    {
        public TfsException()
        { }

        public TfsException(string errorMessage) : base(errorMessage)
        { }

        [JsonProperty(PropertyName = "$id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "innerException")]
        public object ServerInnerException { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string ErrorMessage { get; set; }

        public override string Message { get { return ErrorMessage; } }

        [JsonProperty(PropertyName = "typeName")]
        public string TypeName { get; set; }

        [JsonProperty(PropertyName = "typeKey")]
        public string TypeKey { get; set; }

        [JsonProperty(PropertyName = "errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty(PropertyName = "eventId")]
        public int EventId { get; set; }
    }

}
