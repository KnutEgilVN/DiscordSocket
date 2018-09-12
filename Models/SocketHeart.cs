using DiscordWebSocket.Controllers;
using DiscordWebSocket.Enums;
using DiscordWebSocket.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordWebSocket.Models
{
    public class SocketHeart
    {
        public bool DoHeartbeat { get; set; }
        public int HeartbeatInterval { get; set; }

        public delegate void HeartStartedCallback();
        public event HeartStartedCallback HeartStarted;
        public delegate void HeartbeatSentCallback(bool receivedAck);
        public event HeartbeatSentCallback HeartbeatSent;

        public SocketHeart()
        {

        }
        public SocketHeart(int interval)
        {
            HeartbeatInterval = interval;
        }

        public void Start()
        {
            DoHeartbeat = true;
            HeartStarted();

            new Thread(async () =>
            {
                while (DoHeartbeat)
                {
                    if (SocketController.IsConnected)
                    {
                        Thread.Sleep(HeartbeatInterval);

                        bool acknowledged = await Beat();
                        HeartbeatSent(acknowledged);
                    }
                }
            }).Start();
        }
        public void Stop()
        {
            DoHeartbeat = false;
        }
        public async Task<bool> Beat()
        {
            Payload response = await SocketController.Send(new Heartbeat());
            return response.Opcode == (int)Opcodes.HeartbeatACK;
        }
    }
}
