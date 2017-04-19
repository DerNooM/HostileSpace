using System;
using System.Net;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using HostileSpace.Utils;
using HostileSpaceNetLib;
using HostileSpaceNetLib.Packets;


namespace HostileSpace
{
    class HostileSpace
    {
        RenderWindow renderWindow;

        PerformanceCounter performanceCounter;
        MouseState mouseState;
        KeyboardState keyboardState;
        MusicPlayer musicPlayer;
        ContentManager contentManager = new ContentManager();
        AudioPlayer audioPlayer = new AudioPlayer();

        GameStates currentState = GameStates.GameScreen;

        LoginScreen loginScreen;
        GameScreen gameScreen;

        Client client = new Client();


        public HostileSpace()
        {
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 16;

            renderWindow = new RenderWindow(new VideoMode(1024, 768), "Hostile Space", Styles.Titlebar | Styles.Close, settings);

            renderWindow.SetVerticalSyncEnabled(true);
            renderWindow.Closed += RenderWindow_Closed;

            performanceCounter = new PerformanceCounter(this);
            mouseState = new MouseState(this);
            keyboardState = new KeyboardState(this);
            musicPlayer = new MusicPlayer(this);

            //loginScreen; = new LoginScreen(this);
            loginScreen = null;
            gameScreen = new GameScreen(this);

            client.PacketReceieved += Client_PacketReceieved;
            client.Connect(IPAddress.Loopback);
        }


        private void Client_PacketReceieved(object sender, EventArgs e)
        {
            switch (client.Packet.ID)
            {
            }

        }

        public void Update(Time Elapsed)
        {
            performanceCounter.Update(Elapsed);
            mouseState.Update(Elapsed);

            musicPlayer.Update(Elapsed);

            switch (currentState)
            {
                case GameStates.LoginScreen:
                    {
                        loginScreen.Update(Elapsed);
                    }
                    break;

                case GameStates.GameScreen:
                    {
                        gameScreen.Update(Elapsed);
                    }
                    break;
            }

            RenderWindow.SetTitle("current music: " + musicPlayer.GetCurrentTitle + "  -  FPS: " + performanceCounter.FPS + "  - ping: " + performanceCounter.Ping);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                renderWindow.Close();
        }

        public void Draw(Time Elapsed)
        {
            switch (currentState)
            {
                case GameStates.LoginScreen:
                    {
                        loginScreen.Draw(Elapsed);
                    }
                    break;

                case GameStates.GameScreen:
                    {
                        gameScreen.Draw(Elapsed);
                    }
                    break;
            }

            performanceCounter.Draw(Elapsed);
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
            set { currentState = value; }
        }

        public PerformanceCounter Performance
        {
            get { return performanceCounter; }
        }

        public MouseState MouseState
        {
            get { return mouseState; }
        }

        public KeyboardState KeyboardSate
        {
            get { return keyboardState; }
        }

        public Client Client
        {
            get { return client; }
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
                game.Update(elapsed);

                game.RenderWindow.Clear(Color.Black);
                game.Draw(elapsed);
                game.RenderWindow.Display();
            }
        }


    }
}
