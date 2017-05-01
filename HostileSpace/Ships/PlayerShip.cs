using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace
{
    class PlayerShip : SpaceShip
    {
        public PlayerShip(HostileSpace Game)
            : base(Game)
        {
            Ship = new RectangleShape(new Vector2f(291, 173));
            Ship.Texture = Game.ContentManager.GetTexture("Ship01");
            Ship.Origin = new Vector2f(Ship.Texture.Size.X / 2, Ship.Texture.Size.Y / 2);
            Ship.Scale = Ship.Scale / 2;
            Ship.Position = new Vector2f(Game.Window.Size.X / 2, Game.Window.Size.Y / 2);

            SetupShortRangeIndicator();
            SetupLongRangeIndicator();
        }




    }
}
