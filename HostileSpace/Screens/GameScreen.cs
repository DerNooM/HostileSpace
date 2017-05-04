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
        List<AI> enemies = new List<AI>();

        PlayerShip playerShip = null;

        
        public GameScreen(HostileSpace Game)
            : base(Game)
        {
            playerShip = new PlayerShip(Game);

            enemies.Add(new AI(Game, new SpaceShip(Game)));
        }


        public override void Update(Time Elapsed)
        {
            playerShip.Update(Elapsed);

            foreach(AI enemy in enemies)
            {
                enemy.Update(playerShip ,Elapsed);
            }
        }


        public override void Draw(RenderWindow Window)
        {
            playerShip.Draw(Window);

            foreach (AI enemy in enemies)
            {
                enemy.Draw(Window);
            }
        }


        public override void Activate()
        {
            base.Activate();

            playerShip.Activate();

            foreach (AI enemy in enemies)
            {
                enemy.Activate();
            }
        }



        public PlayerShip PlayerShip
        {
            get { return playerShip; }
        }
             



    }
}
