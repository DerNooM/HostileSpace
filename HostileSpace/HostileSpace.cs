﻿using System;
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

        GameStates currentState = GameStates.Login;

        LoginScreen loginScreen;

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

            loginScreen = new LoginScreen(this);

            client.PacketReceieved += Client_PacketReceieved;
            client.Connect(IPAddress.Loopback);
        }

        private void Client_PacketReceieved(object sender, EventArgs e)
        {
            switch (client.Packet.ID)
            {
                case PacketID.LoginResponse:
                    {
                        LoginResponse response = new LoginResponse(client.Packet);

                        Console.WriteLine(response.Response);
                    }
                    break;
            }

        }

        public void Update(Time Elapsed)
        {
            performanceCounter.Update(Elapsed);
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



            RenderWindow.SetTitle("current music: " + musicPlayer.GetCurrentTitle + "  -  FPS: " + performanceCounter.FPS + "  - ping: " + performanceCounter.Ping);

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

                game.RenderWindow.Clear(Color.Blue);
                game.Draw(elapsed);
                game.RenderWindow.Display();
            }
        }


    }
}
