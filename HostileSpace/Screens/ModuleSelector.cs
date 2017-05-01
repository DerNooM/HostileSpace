using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;
using SFML.Graphics;
using HostileSpace.ShipModules;

namespace HostileSpace.Screens
{
    class ModuleSelector : GameComponent
    {
        RectangleShape background;

        List<RectangleShape> grid = new List<RectangleShape>();

        List<ShipModule> palette = new List<ShipModule>();

        Text title;

        Text selected;

        Text summary;

        public ModuleSelector(HostileSpace Game)
            : base(Game)
        {
            background = new RectangleShape(new Vector2f(576, 384));
            background.Position = new Vector2f(340, 100);
            background.Texture = Game.ContentManager.GetTexture("Bigbox");

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    RectangleShape tmp = new RectangleShape(new Vector2f(30, 30));
                    tmp.FillColor = Color.Transparent;
                    tmp.OutlineColor = Color.White;
                    tmp.OutlineThickness = 1;
                    tmp.Position = new Vector2f(370 + (x * 32), 182 + (y * 32));

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
                    tmp.Position = new Vector2f(570 + (x * 32), 182 + (y * 32));

                    grid.Add(tmp);
                }
            }


            title = new Text("Module Selector:", Game.ContentManager.GetFont("Arial"));
            title.Position = new Vector2f(360, 110);
            title.CharacterSize = 34;


            SmallLaser laser = new SmallLaser();

            selected = new Text("text", Game.ContentManager.GetFont("Arial"));
            selected.CharacterSize = 14;
            selected.Position = new Vector2f(450, 182);
            selected.DisplayedString = laser.Description;
            

            summary = new Text("", Game.ContentManager.GetFont("Arial"));
            summary.CharacterSize = 14;
            summary.Position = new Vector2f(750, 182);
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



        public override void Update(Time Elapsed)
        {
            if (!Active)
                return;
        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            Window.Draw(background);
            Window.Draw(title);

            Window.Draw(selected);

            foreach(RectangleShape shape in grid)
            {
                Window.Draw(shape);
            }


            Window.Draw(summary);
        }


    }
}
