using System;
using System.Timers;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace.Utils
{
    class FPSCounter : GameComponent
    {
        Int32 second = 1000;
        Int32 elapsed = 0;

        UInt16 fps = 0;
        UInt16 fpsCounter = 0;


        public FPSCounter(HostileSpace Game)
            : base(Game)
        {
        }


        public override void Update(Int32 Elapsed)
        {
            fpsCounter++;
            elapsed += Elapsed;

            if(elapsed >= second)
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
