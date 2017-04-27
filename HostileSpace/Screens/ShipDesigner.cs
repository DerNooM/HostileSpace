using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace.Screens
{
    class ShipDesigner : GameComponent
    {
        RectangleShape background;

        List<RectangleShape> grid = new List<RectangleShape>();

        List<ShipComponent> palette = new List<ShipComponent>();

        Text summary;

        public ShipDesigner(HostileSpace Game)
            : base(Game)
        {
            background = new RectangleShape(new Vector2f(576, 384));
            background.Position = new Vector2f(340, 100);
            background.Texture = Game.ContentManager.GetTexture("Bigbox");

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    RectangleShape tmp = new RectangleShape(new Vector2f(30, 30));
                    tmp.FillColor = Color.Transparent;
                    tmp.OutlineColor = Color.White;
                    tmp.OutlineThickness = 1;
                    tmp.Position = new Vector2f(370 + (x * 32), 150 + (y * 32));

                    grid.Add(tmp);
                }
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    RectangleShape tmp = new RectangleShape(new Vector2f(30, 30));
                    tmp.FillColor = Color.Transparent;
                    tmp.OutlineColor = Color.White;
                    tmp.OutlineThickness = 1;
                    tmp.Position = new Vector2f(570 + (x * 32), 150 + (y * 32));

                    grid.Add(tmp);
                }
            }


            summary = new Text("", Game.ContentManager.GetFont("Arial"));
            summary.CharacterSize = 14;
            summary.Position = new Vector2f(750, 150);


            ShipComponent component = new ShipComponent(Game, ComponentTypes.Empty);
            component.Position = new Vector2f(369, 149);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.Laser);
            component.Position = new Vector2f(369, 149 + 32);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.MissileLauncher);
            component.Position = new Vector2f(369, 149 + 64);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.ShieldGenerator);
            component.Position = new Vector2f(369, 149 + 96);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.ShieldCapacitor);
            component.Position = new Vector2f(369 + 32, 149 + 96);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.EnergyGenerator);
            component.Position = new Vector2f(369, 149 + 128);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.EnergyCapacitor);
            component.Position = new Vector2f(369 + 32, 149 + 128);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.LightArmor);
            component.Position = new Vector2f(369, 149 + 160);
            palette.Add(component);

            component = new ShipComponent(Game, ComponentTypes.HeavyArmor);
            component.Position = new Vector2f(369 + 32, 149 + 160);
            palette.Add(component);


            summary.DisplayedString =
                "Armor:\n" +
                "9999999\n" +
                "Shield:\n" +
                "9999999\n" +
                "Energy:\n" +
                "9999999\n" +
                "Shieldregen:\n" +
                "500\n" +
                "Energyregen:\n" +
                "500";
        }


        public override void Update(int Elapsed)
        {

        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            Window.Draw(background);

            foreach(RectangleShape shape in grid)
            {
                Window.Draw(shape);
            }

            foreach(ShipComponent component in palette)
            {
                component.Draw(Window);
            }

            Window.Draw(summary);
        }


    }
}
