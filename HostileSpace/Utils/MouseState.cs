using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace HostileSpace.Utils
{
    class MouseState : GameObject
    {
        IntRect positionRect = new IntRect(0, 0, 1, 1);
        Vector2i positionVector = new Vector2i();

        Boolean leftPressed = false;
        Boolean rightPressed = false;


        public MouseState(HostileSpace Game)
            : base(Game)
        {
        }


        public override void Update(Time Elapsed)
        {
            positionVector = Mouse.GetPosition(Game.RenderWindow);
            positionRect.Left = positionVector.X;
            positionRect.Top = positionVector.Y;

            if (leftPressed && !Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                LeftPressed?.Invoke(this, null);
            }

            if (rightPressed && !Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                RightPressed?.Invoke(this, null);
            }

            leftPressed = Mouse.IsButtonPressed(Mouse.Button.Left);
            rightPressed = Mouse.IsButtonPressed(Mouse.Button.Right);
        }


        public event EventHandler LeftPressed;
        public event EventHandler RightPressed;

        public IntRect PositionRect
        {
            get { return positionRect; }
        }

        public Vector2f PositionVector
        {
            get { return (Vector2f)positionVector; }
        }


    }
}
