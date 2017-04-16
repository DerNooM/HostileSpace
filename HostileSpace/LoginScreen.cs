using System;
using System.Text;
using SFML.System;
using SFML.Graphics;
using HostileSpace.Utils;
using HostileSpace.GUI;
using System.Security.Cryptography;

namespace HostileSpace
{
    class LoginScreen : GameObject
    {
        InputField name;
        InputField password;
        Button login;

        Texture backgroundTexture;
        Sprite backgroundSprite;


        public LoginScreen(HostileSpace Game)
            : base(Game)
        {
            backgroundTexture = new Texture("graphics/backgrounds/large_web.jpg");
            backgroundTexture.Smooth = true;

            backgroundSprite = new Sprite(backgroundTexture, new IntRect(200 - 24, 0, 1024, 768));
            backgroundSprite.Position = new Vector2f(0, 0);

            name = new InputField(Game, "username", (1024 / 2) - 100, 200);
            password = new InputField(Game, "password", (1024 / 2) - 100, 270);

            login = new Button(Game, "Login", (1024 / 2) - 100, 370);
        }


        public override void Update(Time Elapsed)
        {
            name.Update(Elapsed);
            password.Update(Elapsed);

            login.Update(Elapsed);
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(backgroundSprite);

            name.Draw(Elapsed);
            password.Draw(Elapsed);

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
