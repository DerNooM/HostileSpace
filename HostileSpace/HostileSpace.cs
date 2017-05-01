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

        Settings settings = new Settings();

        FPSCounter fpsCounter;
        Input input;
        ContentManager contentManager;

        MusicPlayer musicPlayer;
        AudioPlayer audioPlayer;

        Background background;

        IGameComponent currentScreen = null;

        PlayerData playerData;

        MainScreen mainScreen;

        GameScreen gameScreen;

        SettingsScreen settingsScreen;

        public HostileSpace()
        {
            try
            {
                settings = Settings.Load("settings.xml");
            }
            catch
            {
                settings.ResolutionX = 1024;
                settings.ResolutionY = 768;
            }

            ContextSettings contextSettings = new ContextSettings();
            contextSettings.AntialiasingLevel = 16;
            
            window = new RenderWindow(new VideoMode(settings.ResolutionX, settings.ResolutionY), "Hostile Space", Styles.None, contextSettings);
            window.SetMouseCursorVisible(false);

            window.SetVerticalSyncEnabled(false);

            contentManager = new ContentManager();

            fpsCounter = new FPSCounter(this);
            input = new Input(this);           

            musicPlayer = new MusicPlayer(this);
            audioPlayer = new AudioPlayer();

            background = new Background(this);


            try
            {
                playerData = PlayerData.Load("player.xml");
                Console.WriteLine("player credits: " + playerData.Credits);
            }
            catch
            {
                playerData = new PlayerData();

                playerData.Credits = 1000;

                for(int i = 0; i < 24; i++)
                {
                    playerData.Modules[i] = 0;
                }
                playerData.Modules[0] = (int)ModuleTypes.SmallLaser;
                playerData.Modules[1] = (int)ModuleTypes.ShieldCapacitor;
                playerData.Modules[2] = (int)ModuleTypes.ShieldGenerator;
            }

            

            mainScreen = new MainScreen(this);
            mainScreen.NewGameBTN.ButtonPressed += NewGameBTN_ButtonPressed;
            mainScreen.SettingsBTN.ButtonPressed += SettingsBTN_ButtonPressed;

            gameScreen = new GameScreen(this);

            settingsScreen = new SettingsScreen(this);
            settingsScreen.Back.ButtonPressed += Back_ButtonPressed;

            currentScreen = mainScreen;
            currentScreen.Activate();

            

            input.Keyboard.F12Pressed += Keyboard_F12Pressed;
        }

        private void Back_ButtonPressed(object sender, EventArgs e)
        {
            currentScreen.DeActivate();
            currentScreen = mainScreen;
            currentScreen.Activate();
        }

        private void SettingsBTN_ButtonPressed(object sender, EventArgs e)
        {
            currentScreen.DeActivate();
            currentScreen = settingsScreen;
            currentScreen.Activate();
        }

        private void NewGameBTN_ButtonPressed(object sender, EventArgs e)
        {
            currentScreen.DeActivate();
            currentScreen = gameScreen;
            currentScreen.Activate();
        }

        public void Update(Time Elapsed)
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
                currentScreen.DeActivate();
                currentScreen = mainScreen;
                currentScreen.Activate();
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
        }


        public RenderWindow Window
        {
            get { return window; }
        }

        public Settings Settings
        {
            get { return settings; }
        }

        public Background Background
        {
            get { return background; }
        }

        public PlayerData PlayerData
        {
            get { return playerData; }
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

                game.Update(elapsed);              
                game.Draw();

                game.Window.Display();
            }
        }


    }
}
