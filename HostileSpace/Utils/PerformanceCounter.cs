using System;
using System.Timers;
using SFML.System;
using SFML.Graphics;
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

        RectangleShape rectangle;
        Text fpsText;
        Text pingText;

        public PerformanceCounter(HostileSpace Game)
            : base(Game)
        {
            rectangle = new RectangleShape(new Vector2f(98, 50));
            rectangle.Position = new Vector2f(1024-100, 2);
            rectangle.OutlineColor = Color.Black;
            rectangle.FillColor = Colors.GuiA;
            rectangle.OutlineThickness = 2;

            fpsText = new Text("fps: 9999", Game.ContentManager.GetFont("Arial"), 16);
            fpsText.Color = Color.Black;
            fpsText.Position = new Vector2f(1024 - 100 + 11, 4);

            pingText = new Text("ping: 9999", Game.ContentManager.GetFont("Arial"), 16);
            pingText.Color = Color.Black;
            pingText.Position = new Vector2f(1024 - 100 + 5, 24);

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
                    pingcounter = pingClock.Restart();
                }

                fpsText.DisplayedString = "fps: " + FPS;
                pingText.DisplayedString = "ping: " + Ping;

            }
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(rectangle);
            Game.RenderWindow.Draw(fpsText);
            Game.RenderWindow.Draw(pingText);
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
