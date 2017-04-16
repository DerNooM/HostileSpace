using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using HostileSpace.Utils;


namespace HostileSpace
{
    class HostileSpace
    {
        RenderWindow renderWindow;

        FPSCounter fpsCounter;
        MouseState mouseState;
        KeyboardState keyboardState;
        MusicPlayer musicPlayer;

        GameStates currentState = GameStates.Login;

        LoginScreen loginScreen;


        public HostileSpace()
        {
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 16;

            renderWindow = new RenderWindow(new VideoMode(1024, 768), "Hostile Space", Styles.Titlebar | Styles.Close, settings);

            renderWindow.SetVerticalSyncEnabled(true);
            renderWindow.Closed += RenderWindow_Closed;

            fpsCounter = new FPSCounter(this);
            mouseState = new MouseState(this);
            keyboardState = new KeyboardState(this);
            musicPlayer = new MusicPlayer(this);

            loginScreen = new LoginScreen(this);
        }

        

        public void Update(Time Elapsed)
        {
            fpsCounter.Update(Elapsed);
            mouseState.Update(Elapsed);

            musicPlayer.Update(Elapsed);

            switch (currentState)
            {
                case GameStates.Login:
                    {
                        loginScreen.Update(Elapsed);
                    }
                    break;
            }



            RenderWindow.SetTitle("current music: " + musicPlayer.GetCurrentTitle + "  -  FPS: " + fpsCounter.FPS);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                renderWindow.Close();
        }

        public void Draw(Time Elapsed)
        {
            switch (currentState)
            {
                case GameStates.Login:
                    {
                        loginScreen.Draw(Elapsed);
                    }
                    break;
            }
        }

        private void RenderWindow_Closed(object sender, EventArgs e)
        {
            renderWindow.Close();
        }


        public RenderWindow RenderWindow
        {
            get { return renderWindow; }
        }

        public GameStates CurrentState
        {
            get { return currentState; }
        }

        public UInt16 FPS
        {
            get { return fpsCounter.FPS; }
        }

        public MouseState MouseState
        {
            get { return mouseState; }
        }

        public KeyboardState KeyboardSate
        {
            get { return keyboardState; }
        }


        static void Main(string[] args)
        {

            Clock clock = new Clock();
            Time elapsed;

            HostileSpace game = new HostileSpace();

            while (game.RenderWindow.IsOpen)
            {
                elapsed = clock.Restart();

                game.RenderWindow.DispatchEvents();
                game.Update(elapsed);

                game.RenderWindow.Clear(Color.Blue);
                game.Draw(elapsed);
                game.RenderWindow.Display();
            }
        }


    }
}
