using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using HostileSpace.Utils;


namespace HostileSpace.GUI
{
    class InputField : GameObject
    {
        RectangleShape rectangle;
        IntRect position;

        Text text;

        Int32 maxChars;
        Boolean active = false;
        Boolean firstActive = false;


        public InputField(HostileSpace Game, String Text, Int32 X, Int32 Y, Int32 Height, Int32 Width, Int32 MaxChars)
            : base(Game)
        {
            rectangle = new RectangleShape(new Vector2f(Height, Width));
            rectangle.Position = new Vector2f(X, Y);
            rectangle.OutlineColor = Color.Black;
            rectangle.FillColor = Colors.GuiA;
            rectangle.OutlineThickness = 4;

            position = new IntRect(X, Y, Height, Width);


            text = new Text(Text, Game.ContentManager.GetFont("Arial"), 24);
            text.Color = Color.Black;
            text.Position = new Vector2f(X + 10, Y + 9);

            maxChars = MaxChars;

            Game.MouseState.LeftPressed += MouseState_LeftPressed;
            Game.KeyboardSate.KeyPressed += KeyboardSate_KeyPressed;
            Game.KeyboardSate.BackspacePressed += KeyboardSate_BackspacePressed;
            Game.KeyboardSate.SpacePressed += KeyboardSate_SpacePressed;
        }
        

        public override void Update(Time Elapsed)
        {
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(rectangle);
            Game.RenderWindow.Draw(text);
        }

        public void SetTextOffset(Int32 X, Int32 Y)
        {
            text.Position = new Vector2f(position.Left + X, position.Top + Y);
        }

        private void KeyboardSate_SpacePressed(object sender, EventArgs e)
        {
            if (!active)
                return;

            if (text.DisplayedString.Length < maxChars)
            {
                Console.WriteLine(text.DisplayedString.Length);

                if (text.DisplayedString.Length > 0)
                {
                    if (text.DisplayedString[text.DisplayedString.Length - 1] != ' ')
                        text.DisplayedString += " ";
                }
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

            if (text.DisplayedString.Length < maxChars)
            {
                text.DisplayedString += e.Char;
            }
        }

        private void MouseState_LeftPressed(object sender, EventArgs e)
        {
            if (position.Intersects(Game.MouseState.PositionRect))
            {
                active = true;

                rectangle.FillColor = Colors.GuiB;

                if (!firstActive)
                {
                    firstActive = true;
                    text.DisplayedString = "";
                }
            }
            else
            {
                active = false;

                rectangle.FillColor = Colors.GuiA;
            }
        }


        public String Text
        {
            get { return text.DisplayedString; }
        }

    }
}
