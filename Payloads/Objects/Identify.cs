using DiscordWebSocket.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebSocket.Payloads.Objects
{
    class Identify
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("properties")]
        public object Properties { get; set; }
        [JsonProperty("compress")]
        public bool Compress { get; set; }
        [JsonProperty("large_threshold")]
        public int Large_threshold { get; set; }
        [JsonProperty("shard")]
        public int[] Shard { get; set; }
        [JsonProperty("presence")]
        public object Presence { get; set; }
    }
}
