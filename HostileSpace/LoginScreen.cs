using System;
using System.Text;
using SFML.System;
using SFML.Graphics;
using HostileSpace.Utils;
using HostileSpace.GUI;
using System.Security.Cryptography;
using HostileSpaceNetLib;
using HostileSpaceNetLib.Packets;


namespace HostileSpace
{
    class LoginScreen : GameObject
    {
        InputField name;
        InputField password;
        Button login;

        Texture backgroundTexture;
        Sprite backgroundSprite;
        
        RectangleShape statusBackground;
        Text status;
        Boolean showStatus = false;


        public LoginScreen(HostileSpace Game)
            : base(Game)
        {
            backgroundTexture = new Texture("graphics/backgrounds/large_web.jpg");
            backgroundTexture.Smooth = true;

            backgroundSprite = new Sprite(backgroundTexture, new IntRect(200 - 24, 0, 1024, 768));
            backgroundSprite.Position = new Vector2f(0, 0);

            name = new InputField(Game, "username", (1024 / 2) - 100, 200, 200, 30, 10);
            name.SetTextOffset(6, 3);
            password = new InputField(Game, "password", (1024 / 2) - 100, 250, 200, 30, 10);
            password.SetTextOffset(6, 3);

            login = new Button(Game, "Login", (1024 / 2) - 75, 320, 150, 30);
            login.SetTextOffset(45, 3);
            login.ButtonPressed += Login_ButtonPressed;

            statusBackground = new RectangleShape(new Vector2f(200, 30));
            statusBackground.Position = new Vector2f((1024 / 2) - 100, 370);
            statusBackground.FillColor = Colors.GuiA;

            status = new Text("invalid password", Game.ContentManager.GetFont("Arial"), 24);
            status.Position = new Vector2f((1024 / 2) - 90, 370);
            status.Color = Color.Black;

            Game.Client.PacketReceieved += Client_PacketReceieved;
        }

        private void Client_PacketReceieved(object sender, EventArgs e)
        {
            Client client = (Client)sender;

            if(client.Packet.ID == PacketID.LoginResponse)
            {
                LoginResponse response = new LoginResponse(client.Packet);

                if(response.Response == LoginResponse.Responses.AccountCreated)
                {
                    status.DisplayedString = "account created";
                }
                else if(response.Response == LoginResponse.Responses.InvalidPassword)
                {
                    status.DisplayedString = "invalid password";
                }
                else if(response.Response == LoginResponse.Responses.Accepted)
                {
                    Game.CurrentState = GameStates.MainScreen;
                }

                showStatus = true;
            }
        }

        private void Login_ButtonPressed(object sender, EventArgs e)
        {
            if(Game.Client.Connected)
            {
                if (Username.Length >= 3)
                {
                    if (password.Text != "")
                    {
                        Game.AudioPlayer.PlaySound("GUI_CLICK");

                        LoginRequest request = new LoginRequest(
                        Username,
                        Password);
                           
                        Game.Client.BeginSend(request.Packet);
                    }
                    else
                    {
                        Game.AudioPlayer.PlaySound("GUI_ERROR");
                    }
                }
                else
                {
                    Game.AudioPlayer.PlaySound("GUI_ERROR");
                }
            }
            else
            {
                Game.AudioPlayer.PlaySound("GUI_ERROR");
            }
        }

        public override void Update(Time Elapsed)
        {
            name.Update(Elapsed);
            password.Update(Elapsed);

            login.Update(Elapsed);

            if (!Game.Client.Connected)
            {
                status.DisplayedString = "not connected";
                showStatus = true;
            }
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(backgroundSprite);

            name.Draw(Elapsed);
            password.Draw(Elapsed);

            if (showStatus)
            {
                Game.RenderWindow.Draw(statusBackground);
                Game.RenderWindow.Draw(status);
            }

            login.Draw(Elapsed);
        }


        public Button LoginButton
        {
            get { return login; }
        }

        public String Username
        {
            get { return name.Text; }
        }

        public Byte[] Password
        {
            get
            {
                SHA256 mySHA256 = SHA256Managed.Create();

                Char[] tmp = password.Text.ToCharArray();
                Encoding enc = Encoding.ASCII;
                Byte[] bytes = enc.GetBytes(tmp);

                return mySHA256.ComputeHash(bytes);
            }
        }


    }
}
