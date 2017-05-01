using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace
{
    class ShipModule : IShipModule
    {
        ModuleTypes type = ModuleTypes.Empty;
        Int32 value = 0;
        Time maxCooldown = Time.Zero;
        Time currentCooldown = Time.Zero;
        UInt16 researchLevel = 1;
        UInt32 cost = 0;

        String description = "";


        public ShipModule(ModuleTypes Type, UInt16 Value, Time MaxCooldown, UInt32 Cost)
        {
            type = Type;
            value = Value;
            maxCooldown = MaxCooldown;
            cost = Cost;
        }

        public ShipModule()
        {
            
        }


        public ModuleTypes Type
        {
            get { return type; }
        }

        public Int32 Value
        {
            get { return value *  researchLevel; }
        }

        public Time MaxCooldown
        {
            get { return maxCooldown; }
        }

        public Time CurrentCooldown
        {
            get { return currentCooldown; }
            set { currentCooldown = value; }
        }

        public UInt16 ResearchLevel
        {
            get { return researchLevel; }
            set { researchLevel = value; }
        }

        public UInt32 Cost
        {
            get { return cost * researchLevel; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }


    }
}
