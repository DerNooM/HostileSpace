using System;
using SFML.System;
using SFML.Graphics;
using HostileSpace.GUI;


namespace HostileSpace.Screens
{
    class MainScreen : GameComponent
    {
        Button newGameBTN;
        Button modulesBTN;
        Button settingsBTN;
        Button creditsBTN;
        Button exitBTN;


        public MainScreen(HostileSpace Game)
            : base(Game)
        {
            newGameBTN = new Button(Game, "Start Game", (int)(Game.Window.Size.X / 2) - 96, (int)Game.Window.Size.Y - 460);
            modulesBTN = new Button(Game, "Ship Modules", (int)(Game.Window.Size.X / 2) - 96, (int)Game.Window.Size.Y - 380);
            settingsBTN = new Button(Game, "Settings", (int)(Game.Window.Size.X / 2) - 96, (int)Game.Window.Size.Y - 260);
            creditsBTN = new Button(Game, "Credits", (int)(Game.Window.Size.X / 2) - 96, (int)Game.Window.Size.Y - 180);
            exitBTN = new Button(Game, "Exit", (int)(Game.Window.Size.X / 2) - 96, (int)Game.Window.Size.Y - 100);          
        }


        public override void Update(Time Elapsed)
        {
            if (!Active)
                return;

            newGameBTN.Update(Elapsed);
            modulesBTN.Update(Elapsed);
            settingsBTN.Update(Elapsed);
            creditsBTN.Update(Elapsed);
            exitBTN.Update(Elapsed);
        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            newGameBTN.Draw(Window);
            modulesBTN.Draw(Window);
            settingsBTN.Draw(Window);
            creditsBTN.Draw(Window);
            exitBTN.Draw(Window);
        }

        public override void Activate()
        {
            base.Activate();

            newGameBTN.Activate();
            modulesBTN.Activate();
            settingsBTN.Activate();
            creditsBTN.Activate();
            exitBTN.Activate();
            exitBTN.ButtonPressed += Exit_ButtonPressed;
        }

        public override void DeActivate()
        {
            base.DeActivate();

            newGameBTN.DeActivate();
            modulesBTN.DeActivate();
            settingsBTN.DeActivate();
            creditsBTN.DeActivate();
            exitBTN.DeActivate();
            exitBTN.ButtonPressed -= Exit_ButtonPressed;
        }

        private void Exit_ButtonPressed(object sender, EventArgs e)
        {
            Game.PlayerData.Save("player.xml");      
            Game.Window.Close();
        }


        public Button NewGameBTN
        {
            get { return newGameBTN; }
        }

        public Button ModulesBTN
        {
            get { return modulesBTN; }
        }

        public Button SettingsBTN
        {
            get { return settingsBTN; }
        }

        public Button CreditsBTN
        {
            get { return creditsBTN; }
        }


    }
}
