using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;


namespace HostileSpace
{
    class GameMouse : GameComponent
    {
        FloatRect position = new FloatRect(0, 0, 1, 1);

        Boolean leftPressed = false;
        Boolean rightPressed = false;

        RectangleShape pointer;
        Vector2f pointerPosition = new Vector2f(0, 0);

        public GameMouse(HostileSpace Game)
            : base(Game)
        {
            pointer = new RectangleShape(new Vector2f(20, 20));
            pointer.Texture = Game.ContentManager.GetTexture("Mouse");
        }


        public override void Update(Time Elapsed)
        {
            position.Left = Mouse.GetPosition(Game.Window).X;
            position.Top = Mouse.GetPosition(Game.Window).Y;

            pointerPosition.X = position.Left;
            pointerPosition.Y = position.Top;
            pointer.Position = pointerPosition;

            if (leftPressed && !Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                LeftClicked?.Invoke(this, null);
            }

            if (rightPressed && !Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                RightClicked?.Invoke(this, null);
            }

            leftPressed = Mouse.IsButtonPressed(Mouse.Button.Left);
            rightPressed = Mouse.IsButtonPressed(Mouse.Button.Right);
        }

        public override void Draw(RenderWindow Window)
        {
            Window.SetView(Window.DefaultView);
            Window.Draw(pointer);
            Window.SetView(Game.Camera);
        }


        public event EventHandler LeftClicked;
        public event EventHandler RightClicked;

        public FloatRect Position
        {
            get { return position; }
        }


    }
}
