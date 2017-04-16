using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using HostileSpace.Utils;


namespace HostileSpace.GUI
{
    class InputField : GameObject
    {
        Texture texture;
        Sprite sprite;

        IntRect position;

        Font font;
        Text text;

        Boolean active = false;

        Boolean firstActive = false;

        public InputField(HostileSpace Game, String Text, Int32 X, Int32 Y)
            : base(Game)
        {
            texture = new Texture("graphics/gui/inputfield.png");
            texture.Smooth = true;

            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(X, Y);

            position = new IntRect((Vector2i)sprite.Position, new Vector2i(200, 50));

            font = new Font("graphics/arial.ttf");

            text = new Text(Text, font, 24);
            text.Color = Color.Black;
            text.Position = new Vector2f(X + 20, Y + 9);


            Game.MouseState.LeftPressed += MouseState_LeftPressed;
            Game.KeyboardSate.KeyPressed += KeyboardSate_KeyPressed;
            Game.KeyboardSate.BackspacePressed += KeyboardSate_BackspacePressed;
            Game.KeyboardSate.SpacePressed += KeyboardSate_SpacePressed;
        }

        private void KeyboardSate_SpacePressed(object sender, EventArgs e)
        {
            if (!active)
                return;

            if (text.DisplayedString.Length < 12)
            {
                text.DisplayedString += " ";
            }
        }

        private void KeyboardSate_BackspacePressed(object sender, EventArgs e)
        {
            if (!active)
                return;

            if (text.DisplayedString.Length >= 1)
            {
                text.DisplayedString =
                    text.DisplayedString.Remove(text.DisplayedString.Length - 1);
            }
        }

        private void KeyboardSate_KeyPressed(object sender, KeyboardState.KeyPressedArgs e)
        {
            if (!active)
                return;

            if (text.DisplayedString.Length < 12)
            {
                text.DisplayedString += e.Char;
            }
        }

        public override void Update(Time Elapsed)
        {
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(sprite);
            Game.RenderWindow.Draw(text);
        }

        private void MouseState_LeftPressed(object sender, EventArgs e)
        {
            if (position.Intersects(Game.MouseState.PositionRect))
            {
                active = true;

                sprite.Color = Color.Cyan;

                if (!firstActive)
                {
                    firstActive = true;
                    text.DisplayedString = "";
                }
            }
            else
            {
                active = false;

                sprite.Color = Color.White;
            }
        }


        public String Text
        {
            get { return text.DisplayedString; }
        }

    }
}
