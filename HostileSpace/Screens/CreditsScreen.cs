using SFML.System;
using SFML.Graphics;
using HostileSpace.GUI;

namespace HostileSpace.Screens
{
    class CreditsScreen : GameComponent
    {
        RectangleShape background;
        Text title;
        Text text;

        Button back;


        public CreditsScreen(HostileSpace Game)
            : base(Game)
        {
            background = new RectangleShape(new Vector2f(576, 384));
            background.Position = new Vector2f(Game.Window.Size.X / 2, Game.Window.Size.Y / 2);
            background.Origin = new Vector2f(background.Size.X / 2, background.Size.Y / 2);
            background.Texture = Game.ContentManager.GetTexture("Bigbox");

            title = new Text("Credits:", Game.ContentManager.GetFont("Arial"), 34);
            title.Position = new Vector2f((int)background.Position.X - 250, (int)background.Position.Y - 170);

            text = new Text("", Game.ContentManager.GetFont("Arial"));
            text.Position = new Vector2f((int)background.Position.X - 250, (int)background.Position.Y - 110);
            text.CharacterSize = 18;

            text.DisplayedString =
                "SFML - www.sfml-dev.org\n" +
                "#sfml for ideas and help\n" +
                "www.opengameart.org\n" +
                "\n" +
                "audio:\n" +
                "www.nosoapradio.us\n" +
                "Deceased Superior Technician\n" + 
                "\n" +
                "graphics:\n" +
                "MillionthVector - www.millionthvector.blogspot.de\n" +
                "Daniel Cook - Lostgarden.com\n" +
                "";

            back = new Button(Game, "Back", (int)background.Position.X - 96, (int)background.Position.Y + 210);
        }


        public override void Update(Time Elapsed)
        {
            if (!Active)
                return;

            back.Update(Elapsed);
        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            Window.Draw(background);

            Window.Draw(title);
            Window.Draw(text);

            back.Draw(Window);
        }

        public override void Activate()
        {
            base.Activate();
            back.Activate();
        }

        public override void DeActivate()
        {
            base.DeActivate();
            back.DeActivate();
        }


        public Button Back
        {
            get { return back; }
        }


    }
}
