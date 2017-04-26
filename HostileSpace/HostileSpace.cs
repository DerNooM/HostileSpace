using System;
using System.Net;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using HostileSpace.Utils;
using HostileSpace.Screens;
using HostileSpace.Input;

namespace HostileSpace
{
    class HostileSpace
    {
        RenderWindow renderWindow;

        Stats stats;
        
        MouseState mouseState;
        KeyboardState keyboardState;
        MusicPlayer musicPlayer;
        ContentManager contentManager = new ContentManager();
        AudioPlayer audioPlayer = new AudioPlayer();

        Background background;

        IGameComponent currentScreen;



        public HostileSpace()
        {
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 16;

            renderWindow = new RenderWindow(new VideoMode(1024, 768), "Hostile Space", Styles.Titlebar | Styles.Close, settings);

            renderWindow.SetVerticalSyncEnabled(false);
            renderWindow.Closed += RenderWindow_Closed;

            stats = new Stats(this);

            mouseState = new MouseState(this);
            keyboardState = new KeyboardState(this);
            musicPlayer = new MusicPlayer(this);

            background = new Background(this);



        }


        public void Update(Int32 Elapsed)
        {
            stats.Update(Elapsed);
            mouseState.Update(Elapsed);
            keyboardState.Update(Elapsed);
            musicPlayer.Update(Elapsed);

            background.Update(Elapsed);



            RenderWindow.SetTitle("fps: " + stats.FPS);
        }

        Image tmp;
        public void Draw()
        {
            background.Draw(renderWindow);



            if (keyboardState.F12Pressed)
            {
                tmp = renderWindow.Capture();

                tmp.SaveToFile("screenshot.png");
                Console.WriteLine("screenshot");
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

        public Background Background
        {
            get { return background; }
        }

        public IGameComponent CurrentScreen
        {
            get { return currentScreen; }
            set { currentScreen = value; }
        }

        public Stats Stats
        {
            get { return stats; }
        }

        public MouseState MouseState
        {
            get { return mouseState; }
        }

        public KeyboardState KeyboardSate
        {
            get { return keyboardState; }
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

            while (game.RenderWindow.IsOpen)
            {
                elapsed = clock.Restart();

                game.RenderWindow.DispatchEvents();
                game.Update(elapsed.AsMilliseconds());

                game.RenderWindow.Clear(Color.Black);
                game.Draw();
                game.RenderWindow.Display();
            }
        }


    }
}
