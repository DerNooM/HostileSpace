using System;
using System.Timers;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace.Utils
{
    class FPSCounter : GameComponent
    {
        Time second = Time.FromMilliseconds(1000);
        Time elapsed = Time.Zero;

        UInt16 fps = 0;
        UInt16 fpsCounter = 0;


        public FPSCounter(HostileSpace Game)
            : base(Game)
        {
        }


        public override void Update(Time Elapsed)
        {
            elapsed += Elapsed;

            if(elapsed >= second)
            {
                elapsed -= second;
                fps = fpsCounter;
                fpsCounter = 0;
            }
        }

        public override void Draw(RenderWindow Window)
        {
            fpsCounter++;
        }

        public UInt16 FPS
        {
            get { return fps; }
        }


    }
}
