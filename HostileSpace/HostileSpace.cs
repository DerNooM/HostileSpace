using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using HostileSpace.Utils;
using HostileSpace.Screens;
using HostileSpace.Data;

namespace HostileSpace
{
    class HostileSpace
    {
        RenderWindow window;

        Settings settings;
        PlayerData playerData;

        FPSCounter fpsCounter;
        Input input;
        ContentManager contentManager;

        MusicPlayer musicPlayer;
        AudioPlayer audioPlayer;

        Background background;

        MainScreen mainScreen;

        GameScreen gameScreen;

        SettingsScreen settingsScreen;
        CreditsScreen creditsScreen;

        IGameComponent currentScreen = null;
        
        View camera;
        Int16 zoom = 0;


        public HostileSpace()
        {
            LoadSettings();
            LoadPlayerData();

            ContextSettings contextSettings = new ContextSettings();
            contextSettings.AntialiasingLevel = 16;       
            window = new RenderWindow(new VideoMode(settings.ResolutionX, settings.ResolutionY), "Hostile Space", Styles.None, contextSettings);
            window.SetMouseCursorVisible(false);
            window.SetVerticalSyncEnabled(false);

            contentManager = new ContentManager();

            fpsCounter = new FPSCounter(this);
            input = new Input(this);           

            musicPlayer = new MusicPlayer(this);
            audioPlayer = new AudioPlayer(this);

            background = new Background(this);

            mainScreen = new MainScreen(this);
            mainScreen.NewGameBTN.ButtonPressed += NewGameBTN_ButtonPressed;
            mainScreen.SettingsBTN.ButtonPressed += SettingsBTN_ButtonPressed;
            mainScreen.CreditsBTN.ButtonPressed += CreditsBTN_ButtonPressed;

            gameScreen = new GameScreen(this);

            settingsScreen = new SettingsScreen(this);
            settingsScreen.Back.ButtonPressed += Back_ButtonPressed;
            creditsScreen = new CreditsScreen(this);
            creditsScreen.Back.ButtonPressed += Back_ButtonPressed;

            currentScreen = mainScreen;
            currentScreen.Activate();

            camera = window.DefaultView;
            input.Keyboard.F12Pressed += Keyboard_F12Pressed;

            window.MouseWheelMoved += Window_MouseWheelMoved;
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
            fpsCounter.Draw(window);

            if(currentScreen is GameScreen)
            {
                camera.Center = (currentScreen as GameScreen).PlayerShip.Position;
                window.SetView(camera);
            }
            else
            {
                window.SetView(window.DefaultView);
            }

            background.Draw(window);

            if (currentScreen != null)
            {
                currentScreen.Draw(window);
            }

            Input.Mouse.Draw(window);
        }

        void LoadSettings()
        {
            try
            {
                settings = Settings.Load("settings.xml");
            }
            catch
            {
                settings = new Settings();
                settings.Save("settings.xml");
            }
        }

        void LoadPlayerData()
        {
            try
            {
                playerData = PlayerData.Load("player.xml");
            }
            catch
            {
                playerData = new PlayerData();

                playerData.Credits = 1000;

                for (int i = 0; i < 24; i++)
                {
                    playerData.Modules[i] = 0;
                }

                playerData.Modules[0] = (int)ModuleTypes.SmallLaser;
                playerData.Modules[1] = (int)ModuleTypes.ShieldCapacitor;
                playerData.Modules[2] = (int)ModuleTypes.ShieldGenerator;
                playerData.Modules[3] = (int)ModuleTypes.LightArmor;
            }
        }

        private void Back_ButtonPressed(object sender, EventArgs e)
        {
            currentScreen.DeActivate();
            currentScreen = mainScreen;
            currentScreen.Activate();
        }

        private void CreditsBTN_ButtonPressed(object sender, EventArgs e)
        {
            currentScreen.DeActivate();
            currentScreen = creditsScreen;
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

        private void Keyboard_F12Pressed(object sender, EventArgs e)
        {
            window.Clear(Color.Black);
            Draw();

            Image tmp = window.Capture();
            System.IO.Directory.CreateDirectory("screenshots");
            tmp.SaveToFile("screenshots/" +
                DateTime.Now.Hour + "_" +
                DateTime.Now.Minute + "_" +
                DateTime.Now.Second + "-" +
                DateTime.Now.Day + "_" +
                DateTime.Now.Month + "_" +
                DateTime.Now.Year +                
                ".png");

            window.Clear(Color.Black);

            Console.WriteLine("screenshot");
        }

        private void Window_MouseWheelMoved(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta <= -1)
            {
                zoom += 1;

                if (zoom > 8)
                {
                    zoom = 8;
                    return;
                }

                camera.Zoom(1.1f);
            }
            if (e.Delta >= 1)
            {
                zoom -= 1;

                if (zoom <= 0)
                {
                    zoom = 0;
                    camera.Reset(new FloatRect(camera.Center, new Vector2f(settings.ResolutionX, settings.ResolutionY)));
                    return;
                }

                camera.Zoom(0.9f);
            }
        }


        public RenderWindow Window
        {
            get { return window; }
        }

        public View Camera
        {
            get { return camera; }
        }

        public Settings Settings
        {
            get { return settings; }
        }

        public PlayerData PlayerData
        {
            get { return playerData; }
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
            Time timerPerFrame = Time.FromSeconds(1.0f / 60.0f);
            Time timeSinceLastUpdate = Time.Zero;

            HostileSpace game = new HostileSpace();

            while (game.Window.IsOpen)
            {
                elapsed = clock.Restart();

                timeSinceLastUpdate += elapsed;

                while (timeSinceLastUpdate > timerPerFrame)
                {
                    timeSinceLastUpdate -= timerPerFrame;

                    game.Window.DispatchEvents();
                    game.Update(timerPerFrame);
                }

                game.Window.Clear(Color.Black);
                game.Draw();

                game.Window.Display();
            }
        }


    }
}
