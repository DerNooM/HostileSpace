using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace HostileSpace
{
    class PlayerShip : GameComponent
    {
        List<ShipComponent> components = new List<ShipComponent>();


        public PlayerShip(HostileSpace Game)
            : base(Game)
        {

        }


        public override void Update(int Elapsed)
        {
            
        }

        public override void Draw(RenderWindow Window)
        {
            
        }


    }
}
