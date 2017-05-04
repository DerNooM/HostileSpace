using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostileSpace
{
    class Player : GameComponent
    {
        SpaceShip ship;

        public Player(HostileSpace Game)
            : base(Game)
        {

        }
    }
}
