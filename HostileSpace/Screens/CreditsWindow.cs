using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace.Screens
{
    class CreditsWindow : GameComponent
    {
        RectangleShape background;

        Text title;
        Text text;

        public CreditsWindow(HostileSpace Game)
            : base(Game)
        {
            background = new RectangleShape(new Vector2f(576, 384));
            background.Position = new Vector2f(340, 100);
            background.Texture = Game.ContentManager.GetTexture("Bigbox");

            title = new Text("Credits:", Game.ContentManager.GetFont("Arial"));
            title.Position = new Vector2f(360, 110);
            title.CharacterSize = 34;

            text = new Text("", Game.ContentManager.GetFont("Arial"));
            text.Position = new Vector2f(380, 160);
            text.CharacterSize = 18;

            text.DisplayedString =
                "SFML - www.sfml-dev.org\n" +
                "#sfml for ideas and help\n" +
                "\n" +
                "audio:\n" +
                "www.nosoapradio.us\n" +
                "Deceased Superior Technician\n" + 
                "\n" +
                "graphics:\n" +
                "MillionthVector - www.millionthvector.blogspot.de\n" +
                "Daniel Cook - Lostgarden.com\n" +
                "VegaStrike by Grumbel\n" +
                "";
        }


        public override void Update(int Elapsed)
        {
            
        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            Window.Draw(background);

            Window.Draw(title);
            Window.Draw(text);
        }



    }
}
