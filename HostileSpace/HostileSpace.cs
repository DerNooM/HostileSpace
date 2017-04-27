using System;
using System.Net;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using HostileSpace.Utils;
using HostileSpace.Screens;


namespace HostileSpace
{
    class HostileSpace
    {
        RenderWindow window;

        FPSCounter fpsCounter;
        Input input;
        ContentManager contentManager;

        MusicPlayer musicPlayer;
        AudioPlayer audioPlayer;

        Background background;

        IGameComponent currentScreen = null;

        MainScreen mainScreen;

        public HostileSpace()
        {
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 16;
            
            window = new RenderWindow(new VideoMode(1024, 768), "Hostile Space", Styles.None, settings);
            window.SetMouseCursorVisible(false);
            //window.Size = new Vector2u(1200, 800);
            //window.SetView(new View(new FloatRect(0, 0, window.Size.X, window.Size.Y)));

            window.SetVerticalSyncEnabled(true);

            contentManager = new ContentManager();

            fpsCounter = new FPSCounter(this);
            input = new Input(this);           

            musicPlayer = new MusicPlayer(this);
            audioPlayer = new AudioPlayer();

            background = new Background(this);

            mainScreen = new MainScreen(this);
            currentScreen = mainScreen;
            currentScreen.Activate();

            input.Keyboard.F12Pressed += Keyboard_F12Pressed;
        }


        public void Update(Int32 Elapsed)
        {
            fpsCounter.Update(Elapsed);
            input.Update(Elapsed);
            musicPlayer.Update(Elapsed);

            background.Update(Elapsed);

            if(currentScreen != null)
            {
                currentScreen.Update(Elapsed);
            }

            if(Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                window.Close();
            }

            Console.Title = "fps: " + fpsCounter.FPS;
        }

        
        public void Draw()
        {
            background.Draw(window);

            if (currentScreen != null)
            {
                currentScreen.Draw(window);
            }

            Input.Mouse.Draw(window);
        }

        private void Keyboard_F12Pressed(object sender, EventArgs e)
        {
            window.Clear(Color.Black);
            Draw();

            Image tmp = window.Capture();
            tmp.SaveToFile("screenshot.png");
            window.Clear(Color.Black);
            background.Generate();
        }


        public RenderWindow Window
        {
            get { return window; }
        }

        public Background Background
        {
            get { return background; }
        }

        public IGameComponent CurrentScreen
        {
            get { return currentScreen; }
            set { currentScreen = value; }
        }

        public FPSCounter FPSCounter
        {
            get { return fpsCounter; }
        }

        public Input Input
        {
            get { return input; }
        }

        public ContentManager ContentManager
        {
            get { return contentManager; }
        }

        public AudioPlayer AudioPlayer
        {
            get { return audioPlayer; }
        }


        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Time elapsed;

            HostileSpace game = new HostileSpace();

            while (game.Window.IsOpen)
            {
                elapsed = clock.Restart();

                game.Window.DispatchEvents();
                game.Window.Clear(Color.Black);

                game.Update(elapsed.AsMilliseconds());              
                game.Draw();

                game.Window.Display();
            }
        }


    }
}
