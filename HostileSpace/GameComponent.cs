using System;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace
{
    class GameComponent : IGameComponent
    {
        HostileSpace game;
        Boolean active = false;


        public GameComponent(HostileSpace Game)
        {
            game = Game;
        }


        public virtual void Update(Int32 Elapsed)
        { }

        public virtual void Draw(RenderWindow Window)
        { }

        public virtual void Activate()
        {
            active = true;
        }

        public virtual void DeActivate()
        {
            active = false;
        }


        public HostileSpace Game
        {
            get { return game; }
        }

        public Boolean Active
        {
            get { return active; }
        }


    }
}
