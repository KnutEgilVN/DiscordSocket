using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebSocket.Payloads
{
    class Gateway : Payload
    {
        [JsonProperty("s")]
        public int SequenceNumber
        {
            get
            {
                return _SequenceNumber;
            }
            set
            {
                _SequenceNumber = value;
                LastSequence = _SequenceNumber;
            }
        }
        [JsonProperty("t")]
        public string EventName { get; set; }

        private int _SequenceNumber;
        public static int LastSequence { get; set; }
    }
}
