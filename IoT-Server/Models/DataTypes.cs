using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoT_Server.Models
{
    public class ListResponse
    {
        public IList<string> Rows { get; set; }

        public ListResponse()
        {
            this.Rows = new List<string>();
        }
    } // ListResponse

    public class SemaphoreStatus
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;
    } // SemaphoreStatus

    public class TokenChallenge
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserId;
        [JsonProperty(PropertyName = "secret")]
        public string Secret;
    } // TokenChallenge

} // ns