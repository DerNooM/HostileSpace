using System;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;
using HostileSpace.Utils;


namespace HostileSpace.GUI
{
    class Button : GameObject
    {
        RectangleShape rectangle;
        IntRect position;

        Text text;

        SoundBuffer soundBuffer;
        Sound sound;


        public Button(HostileSpace Game, String Text, Int32 X, Int32 Y, Int32 Height, Int32 Width)
            : base(Game)
        {
            rectangle = new RectangleShape(new Vector2f(Height, Width));
            rectangle.Position = new Vector2f(X, Y);
            rectangle.OutlineColor = Color.Black;
            rectangle.OutlineThickness = 4;

            position = new IntRect(X, Y, Height, Width);


            text = new Text(Text, Game.ContentManager.GetFont("Arial"), 24);
            text.Color = Color.Black;
            text.Position = new Vector2f(X + 20, Y + 9);

            soundBuffer = new SoundBuffer("audio/gui/buttonclick.wav");
            sound = new Sound(soundBuffer);

            Game.MouseState.LeftPressed += MouseState_LeftPressed;
        }


        public override void Update(Time Elapsed)
        {
            if (position.Intersects(Game.MouseState.PositionRect))
            {
                rectangle.FillColor = Colors.GuiB;
            }
            else
            {
                rectangle.FillColor = Colors.GuiA;
            }
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

        private void MouseState_LeftPressed(object sender, EventArgs e)
        {
            if (position.Intersects(Game.MouseState.PositionRect))
            {
                ButtonPressed?.Invoke(this, null);
            }
        }


        public event EventHandler ButtonPressed;


    }
}
