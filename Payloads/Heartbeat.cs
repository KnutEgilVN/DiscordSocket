using DiscordWebSocket.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebSocket.Payloads
{
    class Heartbeat : Payload
    {
        public Heartbeat()
        {
            Opcode = (int)Opcodes.Heartbeat;
            Data = Gateway.LastSequence;
        }
    }
}
