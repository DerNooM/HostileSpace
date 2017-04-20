using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;


namespace HostileSpace
{
    class GameComponent : IGameComponent
    {
        HostileSpace game;


        public GameComponent(HostileSpace Game)
        {
            game = Game;
        }


        public virtual void Update(Time Elapsed)
        {

        }

        public virtual void Draw(Time Elapsed)
        {

        }


        public HostileSpace Game
        {
            get { return game; }
        }


    }
}
