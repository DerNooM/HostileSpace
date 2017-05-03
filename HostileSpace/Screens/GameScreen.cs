using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace HostileSpace.Screens
{
    class GameScreen : GameComponent
    {
        List<IGameComponent> ships = new List<IGameComponent>();

        PlayerShip playerShip = null;

        
        public GameScreen(HostileSpace Game)
            : base(Game)
        {
            playerShip = new PlayerShip(Game);

            ships.Add(new SpaceShip(Game));
        }


        public override void Update(Time Elapsed)
        {
            playerShip.Update(Elapsed);

            foreach(IGameComponent ship in ships)
            {
                ship.Update(Elapsed);
            }
        }


        public override void Draw(RenderWindow Window)
        {
            playerShip.Draw(Window);

            foreach (IGameComponent ship in ships)
            {
                ship.Draw(Window);
            }
        }


        public override void Activate()
        {
            base.Activate();

            playerShip.Activate();

            foreach (IGameComponent ship in ships)
            {
                ship.Activate();
            }
        }



        public PlayerShip PlayerShip
        {
            get { return playerShip; }
        }
             



    }
}
