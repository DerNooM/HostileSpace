using System;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace
{
    class GameComponent : IGameComponent
    {
        HostileSpace game;


        public GameComponent(HostileSpace Game)
        {
            game = Game;
        }


        public virtual void Update(Int32 Elapsed)
        { }

        public virtual void Draw(RenderWindow Window)
        { }


        public HostileSpace Game
        {
            get { return game; }
        }


    }
}
