using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace HostileSpace
{
    class AI : GameComponent
    {
        SpaceShip ship;

        public AI(HostileSpace Game, SpaceShip Ship)
            : base(Game)
        {
            ship = Ship;
        }


        public void Update(SpaceShip Player, Time Elapsed)
        {
            if (MathHelper.GetDistance(Player.Position, ship.Position) >= 1000)
                return;

            //ship.GetInRange(Player);

            ship.Update(Elapsed);
        }

        public override void Draw(RenderWindow Window)
        {
            ship.Draw(Window);
        }

        public override void Activate()
        {
            base.Activate();
            ship.Activate();
        }



        public SpaceShip Ship
        {
            get { return ship; }
        }

    }
}
