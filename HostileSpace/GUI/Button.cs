using System;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;
using HostileSpace.Utils;


namespace HostileSpace.GUI
{
    class Button : GameObject
    {
        Texture texture;
        Sprite sprite;

        Font font;
        Text text;

        SoundBuffer soundBuffer;
        Sound sound;

        IntRect position;


        public Button(HostileSpace Game, String Text, Int32 X, Int32 Y)
            : base(Game)
        {
            texture = new Texture("graphics/gui/button.png");
            texture.Smooth = true;

            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(X, Y);

            font = new Font("graphics/arial.ttf");

            text = new Text(Text, font, 24);
            text.Color = Color.Black;
            text.Position = new Vector2f(X + 20, Y + 9);

            soundBuffer = new SoundBuffer("audio/gui/buttonclick.wav");
            sound = new Sound(soundBuffer);

            position = new IntRect((Vector2i)sprite.Position, new Vector2i(200, 50));

            Game.MouseState.LeftPressed += MouseState_LeftPressed;
        }


        public override void Update(Time Elapsed)
        {
            if (position.Intersects(Game.MouseState.PositionRect))
            {
                sprite.Color = Color.Magenta;
            }
            else
            {
                sprite.Color = Color.White;
            }
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
                sound.Play();
                ButtonPressed?.Invoke(this, null);
            }
        }


        public event EventHandler ButtonPressed;


    }
}
