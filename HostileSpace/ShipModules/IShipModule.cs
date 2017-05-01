using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace HostileSpace
{
    interface IShipModule
    {
        ModuleTypes Type { get; }
        Int32 Value { get; }
        Time MaxCooldown { get; }
        Time CurrentCooldown { get; set; }
        UInt16  ResearchLevel { get; }
        UInt32 Cost { get; }
        
        String Description { get; set; }
    }
}
