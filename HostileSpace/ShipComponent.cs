using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace
{
    class ShipComponent : GameComponent
    {
        ComponentTypes type = ComponentTypes.Empty;

        RectangleShape shape = new RectangleShape(new Vector2f(32, 32));
        String name = "null";


        public ShipComponent(HostileSpace Game, ComponentTypes Type)
            : base(Game)
        {
            type = Type;

            if (type == ComponentTypes.Laser)
            {
                shape.Texture = Game.ContentManager.GetTexture("Laser");
            }
            else if (type == ComponentTypes.MissileLauncher)
            {
                shape.Texture = Game.ContentManager.GetTexture("MissileLauncher");
            }
            else if (type == ComponentTypes.ShieldGenerator)
            {
                shape.Texture = Game.ContentManager.GetTexture("ShieldGenerator");
            }
            else if (type == ComponentTypes.ShieldCapacitor)
            {
                shape.Texture = Game.ContentManager.GetTexture("ShieldCapacitor");
            }
            else if (type == ComponentTypes.EnergyGenerator)
            {
                shape.Texture = Game.ContentManager.GetTexture("EnergyGenerator");
            }
            else if (type == ComponentTypes.EnergyCapacitor)
            {
                shape.Texture = Game.ContentManager.GetTexture("EnergyCapacitor");
            }
            else if (type == ComponentTypes.LightArmor)
            {
                shape.Texture = Game.ContentManager.GetTexture("LightArmor");
            }
            else if(type == ComponentTypes.HeavyArmor)
            {
                shape.Texture = Game.ContentManager.GetTexture("HeavyArmor");
            }
        }


        public override void Update(int Elapsed)
        {

        }

        public override void Draw(RenderWindow Window)
        {
            Window.Draw(shape);
        }


        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        public Vector2f Position
        {
            get { return shape.Position; }
            set { shape.Position = value; }
        }

    }
}
