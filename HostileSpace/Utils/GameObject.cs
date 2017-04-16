using SFML.System;


namespace HostileSpace.Utils
{
    class GameObject
    {
        HostileSpace game;


        public GameObject(HostileSpace Game)
        {
            game = Game;
        }


        public virtual void Update(Time Elapsed)
        { }

        public virtual void Draw(Time Elapsed)
        { }


        public HostileSpace Game
        {
            get { return game; }
        }


    }
}
