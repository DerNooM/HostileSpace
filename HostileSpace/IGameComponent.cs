using System;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace
{
    interface IGameComponent
    {
        void Update(Time Elapsed);
        void Draw(RenderWindow Window);

        void Activate();
        void DeActivate();

        HostileSpace Game { get; }
        Boolean Active { get; }
    }
}
