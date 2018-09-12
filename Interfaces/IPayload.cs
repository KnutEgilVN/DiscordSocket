using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebSocket.Interfaces
{
    interface IPayload
    {
        [JsonProperty("op")]
        int Opcode { get; set; }
        [JsonProperty("d")]
        object Data { get; set; }
    }
}
