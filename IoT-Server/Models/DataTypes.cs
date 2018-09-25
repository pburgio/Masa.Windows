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
    public enum SemaphoreState { Off = 0, Green = 1, GreenYellow = 2, Red = 3, RedYellow = 4, Yellow = 5, Blinking = 10 };
    public enum SemaporeMaster { Unknown = 0, Server = 1, Modbus = 2, Internal = 3 };
    
    public class SemaphoreStatus
    {
        [JsonProperty(PropertyName = "id")]
        public string Id;
        // Can remove this
        [JsonProperty(PropertyName = "status")]
        public SemaphoreState Status;

        [JsonProperty(PropertyName = "phase")]
        public int Phase;
        [JsonProperty(PropertyName = "tl_mode")]
        public SemaphoreMode TlMode;
        [JsonProperty(PropertyName = "tl_state")]
        public SemaphoreState TlState;
        [JsonProperty(PropertyName = "ctrl_type")]
        public SemaporeMaster CtrlType;
        [JsonProperty(PropertyName = "time_to_change")]
        public int TimeToChange;

    } // SemaphoreStatus

    public class SemaphoreCtrl
    {
        [JsonProperty(PropertyName = "key")]
        public string Key;
        [JsonProperty(PropertyName = "status")]
        public SemaphoreStatus Status;
    }

    public class TokenChallenge
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserId;
        [JsonProperty(PropertyName = "secret")]
        public string Secret;
    } // TokenChallenge

    public class VehiclePosition
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "position")]
        public Position Position;

        public static IList<VehiclePosition> FromDictionary(IDictionary<string, Position> positions)
        {
            var ret = new List<VehiclePosition>();

            foreach(var p in positions)
                ret.Add(new VehiclePosition()
                {
                    Name = p.Key,
                    Position = p.Value
                });

            return ret;
        }
    } // TokenChallenge

    public class Position
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "lng")]
        public double Longitude { get; set; }
    }

    public class VehicleCtrl
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "path")]
        public int Path;
        [JsonProperty(PropertyName = "key")]
        public string Key;
    }

} // ns