using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using HostileSpace.GUI;


namespace HostileSpace.Screens
{
    class MainScreen : GameComponent
    {
        Button newGame;
        Button research;
        Button shipDesignerbtn;
        Button settings;
        Button creditsbtn;
        Button exitbtn;



        ShipDesigner shipDesigner;

        CreditsWindow creditsWindow;


        public MainScreen(HostileSpace Game)
            : base(Game)
        {
            newGame = new Button(Game, "Start Game", 50, 100);
            research = new Button(Game, "Research", 50, 190);
            shipDesignerbtn = new Button(Game, "Ship Designer", 50, 280);
            shipDesignerbtn.ButtonPressed += ShipDesigner_ButtonPressed;
            settings = new Button(Game, "Settings", 50, 400);

            creditsbtn = new Button(Game, "Credits", 50, 490);
            creditsbtn.ButtonPressed += Credits_ButtonPressed;

            exitbtn = new Button(Game, "Exit", 50, 580);
            exitbtn.ButtonPressed += Exit_ButtonPressed;

            shipDesigner = new ShipDesigner(Game);

            creditsWindow = new CreditsWindow(Game);
        }

        

        public override void Update(int Elapsed)
        {
            newGame.Update(Elapsed);
            research.Update(Elapsed);
            shipDesignerbtn.Update(Elapsed);
            settings.Update(Elapsed);
            creditsbtn.Update(Elapsed);
            exitbtn.Update(Elapsed);

            shipDesigner.Update(Elapsed);

            creditsWindow.Update(Elapsed);
        }

        public override void Draw(RenderWindow Window)
        {
            newGame.Draw(Window);
            research.Draw(Window);
            shipDesignerbtn.Draw(Window);
            settings.Draw(Window);
            creditsbtn.Draw(Window);
            exitbtn.Draw(Window);


            shipDesigner.Draw(Window);

            creditsWindow.Draw(Window);
        }

        private void ShipDesigner_ButtonPressed(object sender, EventArgs e)
        {
            if (shipDesigner.Active)
                shipDesigner.DeActivate();
            else
                shipDesigner.Activate();
        }

        private void Credits_ButtonPressed(object sender, EventArgs e)
        {
            if (creditsWindow.Active)
                creditsWindow.DeActivate();
            else
                creditsWindow.Activate();
        }

        private void Exit_ButtonPressed(object sender, EventArgs e)
        {
            Game.Window.Close();
        }


    }
}
