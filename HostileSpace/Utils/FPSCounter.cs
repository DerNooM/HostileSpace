using System;
using SFML.System;


namespace HostileSpace.Utils
{
    class FPSCounter : GameObject
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

            fpsCounter++;

            if (elapsed >= second)
            {
                elapsed -= second;

                fps = fpsCounter;
                fpsCounter = 0;
            }
        }


        public UInt16 FPS
        {
            get { return fps; }
        }


    }
}
