using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;


namespace HostileSpace.Input
{
    class MouseState : GameComponent
    {
        IntRect positionRect = new IntRect(0, 0, 1, 1);
        Vector2i positionVector = new Vector2i();

        Boolean leftPressed = false;
        Boolean rightPressed = false;

        Boolean leftClick = false;
        Boolean rightClick = false;

        public MouseState(HostileSpace Game)
            : base(Game)
        {
        }


        public override void Update(Int32 Elapsed)
        {
            positionVector = Mouse.GetPosition(Game.RenderWindow);
            positionRect.Left = positionVector.X;
            positionRect.Top = positionVector.Y;

            leftClick = false;
            rightClick = false;

            if (leftPressed && !Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                leftClick = true;
            }

            if (rightPressed && !Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                rightClick = true;
            }

            leftPressed = Mouse.IsButtonPressed(Mouse.Button.Left);
            rightPressed = Mouse.IsButtonPressed(Mouse.Button.Right);
        }


        public IntRect PositionRect
        {
            get { return positionRect; }
        }

        public Vector2f PositionVector
        {
            get { return (Vector2f)positionVector; }
        }

        public event EventHandler LeftClick;

        public event EventHandler RightClick;


    }
}
