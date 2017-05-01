using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;


namespace HostileSpace.ShipModules
{
    class SmallLaser : ShipModule
    {
        public SmallLaser()
            : base( ModuleTypes.SmallLaser, 13, Time.FromMilliseconds(1000), 300)
        {
            Description =
                "A small Laser.\n" +
                "low damage\n" +
                "low cooldown\n" +
                "low range\n" +
                "and low cost";

        }
    }
}
