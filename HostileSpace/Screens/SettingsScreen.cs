using System;
using SFML.Graphics;
using SFML.System;
using HostileSpace.GUI;


namespace HostileSpace.Screens
{
    class SettingsScreen : GameComponent
    {
        RectangleShape background;
        Text title;

        Text txt1024x768;
        Text txt1280x720;
        Text txt1920x1080;
        Text txt1920x1200;

        CheckBox chk1024x786;
        CheckBox chk1280x720;
        CheckBox chk1920x1080;
        CheckBox chk1920x1200;

        Button accept;
        Button back;

        uint tmpX = 0;
        uint tmpY = 0;


        public SettingsScreen(HostileSpace Game)
            : base(Game)
        {
            background = new RectangleShape(new Vector2f(576, 384));
            background.Position = new Vector2f(Game.Window.Size.X / 2, Game.Window.Size.Y / 2);
            background.Origin = new Vector2f(background.Size.X / 2, background.Size.Y / 2);
            background.Texture = Game.ContentManager.GetTexture("Bigbox");

            title = new Text("Settings (needs restart)", Game.ContentManager.GetFont("Arial"), 34);
            title.Position = new Vector2f((int)background.Position.X - 250, (int)background.Position.Y - 170);

            txt1024x768 = new Text("1024x786", Game.ContentManager.GetFont("Arial"), 24);
            txt1024x768.Position = new Vector2f(background.Position.X - 180, background.Position.Y - 85);
            txt1280x720 = new Text("1280x720", Game.ContentManager.GetFont("Arial"), 24);
            txt1280x720.Position = new Vector2f(background.Position.X + 70, background.Position.Y - 85);
            txt1920x1080 = new Text("1920x1080", Game.ContentManager.GetFont("Arial"), 24);
            txt1920x1080.Position = new Vector2f(background.Position.X - 180, background.Position.Y + 15);
            txt1920x1200 = new Text("1920x1200", Game.ContentManager.GetFont("Arial"), 24);
            txt1920x1200.Position = new Vector2f(background.Position.X + 70, background.Position.Y + 15);

            chk1024x786 = new CheckBox(Game, (int)background.Position.X - 250, (int)background.Position.Y - 100);          
            chk1280x720 = new CheckBox(Game, (int)background.Position.X, (int)background.Position.Y - 100);            
            chk1920x1080 = new CheckBox(Game, (int)background.Position.X - 250, (int)background.Position.Y);           
            chk1920x1200 = new CheckBox(Game, (int)background.Position.X, (int)background.Position.Y);
            
            accept = new Button(Game, "Save", (int)background.Position.X - 220, (int)background.Position.Y + 100);          
            back = new Button(Game, "Back", (int)background.Position.X + 30 , (int)background.Position.Y + 100);

            tmpX = Game.Settings.ResolutionX;
            tmpY = Game.Settings.ResolutionY;
        }


        public override void Update(Time Elapsed)
        {
            if (!Active)
                return;

            if (tmpX == 1024)
            {
                chk1024x786.Checked = true;
                chk1280x720.Checked = false;
                chk1920x1080.Checked = false;
                chk1920x1200.Checked = false;
            }
            else if (tmpX == 1280)
            {
                chk1024x786.Checked = false;
                chk1280x720.Checked = true;
                chk1920x1080.Checked = false;
                chk1920x1200.Checked = false;
            }
            else if (tmpX == 1920)
            {
                if (tmpY == 1080)
                {
                    chk1024x786.Checked = false;
                    chk1280x720.Checked = false;
                    chk1920x1080.Checked = true;
                    chk1920x1200.Checked = false;
                }
                else if (tmpY == 1200)
                {
                    chk1024x786.Checked = false;
                    chk1280x720.Checked = false;
                    chk1920x1080.Checked = false;
                    chk1920x1200.Checked = true;
                }
            }
        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            Window.Draw(background);
            Window.Draw(title);

            chk1024x786.Draw(Window);
            chk1280x720.Draw(Window);
            chk1920x1080.Draw(Window);
            chk1920x1200.Draw(Window);

            Window.Draw(txt1024x768);
            Window.Draw(txt1280x720);
            Window.Draw(txt1920x1080);
            Window.Draw(txt1920x1200);

            accept.Draw(Window);
            back.Draw(Window);
        }

        public override void Activate()
        {
            base.Activate();

            chk1024x786.Activate();
            chk1024x786.CheckedEvent += Chk1024x786_CheckedEvent;
            chk1280x720.Activate();
            chk1280x720.CheckedEvent += Chk1280x720_CheckedEvent;
            chk1920x1080.Activate();
            chk1920x1080.CheckedEvent += Chk1920x1080_CheckedEvent;
            chk1920x1200.Activate();
            chk1920x1200.CheckedEvent += Chk1920x1200_CheckedEvent;

            accept.Activate();
            accept.ButtonPressed += Accept_ButtonPressed;

            back.Activate();
        }

        public override void DeActivate()
        {
            base.DeActivate();

            chk1024x786.DeActivate();
            chk1024x786.CheckedEvent -= Chk1024x786_CheckedEvent;
            chk1280x720.DeActivate();
            chk1280x720.CheckedEvent -= Chk1280x720_CheckedEvent;
            chk1920x1080.DeActivate();
            chk1920x1080.CheckedEvent -= Chk1920x1080_CheckedEvent;
            chk1920x1200.DeActivate();
            chk1920x1200.CheckedEvent -= Chk1920x1200_CheckedEvent;

            accept.DeActivate();
            accept.ButtonPressed -= Accept_ButtonPressed;

            back.DeActivate();
        }

        private void Accept_ButtonPressed(object sender, EventArgs e)
        {
            Game.Settings.ResolutionX = tmpX;
            Game.Settings.ResolutionY = tmpY;
            Game.Settings.Save("settings.xml");
        }

        private void Chk1024x786_CheckedEvent(object sender, EventArgs e)
        {
            tmpX = 1024;
            tmpY = 768;
        }

        private void Chk1280x720_CheckedEvent(object sender, EventArgs e)
        {
            tmpX = 1280;
            tmpY = 720;
        }

        private void Chk1920x1080_CheckedEvent(object sender, EventArgs e)
        {
            tmpX = 1920;
            tmpY = 1080;
        }

        private void Chk1920x1200_CheckedEvent(object sender, EventArgs e)
        {
            tmpX = 1920;
            tmpY = 1200;
        }


        public Button Back
        {
            get { return back; }
        }


    }
}