using System;
using SFML.System;
using HostileSpaceNetLib;
using HostileSpaceNetLib.Packets;


namespace HostileSpace.Utils
{
    class PerformanceCounter : GameObject
    {
        Time second = Time.FromMilliseconds(1000);
        Time elapsed = Time.Zero;

        UInt16 fps = 0;
        UInt16 fpsCounter = 0;

        Clock pingClock = new Clock();
        Time pingcounter = Time.Zero;
        readonly object syncRoot = new object();

        Int32 ping = 0;

        public PerformanceCounter(HostileSpace Game)
            : base(Game)
        {
            Game.Client.PacketReceieved += Client_PacketReceieved;
        }


        private void Client_PacketReceieved(object sender, EventArgs e)
        {
            if (Game.Client.Packet.ID == PacketID.Ping)
            {
                lock (syncRoot)
                {
                    pingcounter = pingClock.Restart();

                    ping = pingcounter.AsMilliseconds();
                }
            }
        }

        public override void Update(Time Elapsed)
        {
            elapsed += Elapsed;

            fpsCounter++;

            if (elapsed >= second)
            {
                elapsed -= second;

                fps = fpsCounter;
                fpsCounter = 0;

                PacketBase ping = new PacketBase(PacketID.Ping);
                Game.Client.BeginSend(ping);

                lock (syncRoot)
                {
                    pingClock.Restart();
                }

            }
        }


        public UInt16 FPS
        {
            get { return fps; }
        }

        public Int32 Ping
        {
            get { return ping; }
        }


    }
}
