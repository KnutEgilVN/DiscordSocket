using DiscordWebSocket.Enums;
using DiscordWebSocket.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebSocket.Payloads
{
    public class Payload : IPayload
    {
        public int Opcode { get; set; }
        public object Data { get; set; }

        public Payload()
        {

        }
        public Payload(Opcodes opcode, object data)
        {
            Opcode = (int)opcode;
            Data = data;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
