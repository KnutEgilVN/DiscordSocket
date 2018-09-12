using DiscordWebSocket.Controllers;
using DiscordWebSocket.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordWebSocket.Models
{
    public class SocketListener
    {
        public bool IsListening { get; set; }

        public delegate void PayloadReceivedCallback(Payload payload);
        public event PayloadReceivedCallback PayloadReceived;

        public SocketListener()
        {

        }

        public void Listen()
        {
            IsListening = true;

            new Thread( () =>
            {
                while (IsListening)
                {
                    if (SocketController.IsConnected)
                    {
                        try
                        {
                            Payload payload = SocketController.Receive();
                            if (payload != null)
                                PayloadReceived(payload);
                        }
                        catch(WebSocketException ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }).Start();
        }
        public void Stop()
        {
            IsListening = false;
        }
    }
}
