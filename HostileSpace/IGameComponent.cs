using SFML.System;


namespace HostileSpace
{
    interface IGameComponent
    {
        HostileSpace Game { get; }

        void Update(Time Elapsed);
        void Draw(Time Elapsed);
    }
}
