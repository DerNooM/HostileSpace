using System;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace
{
    interface IGameComponent
    {
        void Update(Int32 Elapsed);
        void Draw(RenderWindow Window);

        HostileSpace Game { get; }
    }
}
