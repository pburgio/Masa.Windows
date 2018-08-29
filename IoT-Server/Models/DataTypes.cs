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

    public enum SemaphoreMode { Manual = 0, DrivenByPhase = 1, BlinkingYellow = 2 };
    public enum SemaphoreState { Off = 0, Green = 1, GreenYellow = 2, Red = 3, RedYellow = 4 };
    public enum SemaphoreCtrl { Server = 1, Modbus = 2, Internal = 3 };

    public class SemaphoreStatus
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;
        // Can remove this
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "phase")]
        public int Phase;
        [JsonProperty(PropertyName = "tl_mode")]
        public SemaphoreMode TlMode;
        [JsonProperty(PropertyName = "tl_state")]
        public SemaphoreState TlState;
        [JsonProperty(PropertyName = "ctrl_type")]
        public SemaphoreState CtrlType;

    } // SemaphoreStatus

    public class TokenChallenge
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserId;
        [JsonProperty(PropertyName = "secret")]
        public string Secret;
    } // TokenChallenge

} // ns