using System;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace.GUI
{
    class CheckBox : GameComponent
    {
        RectangleShape shape;
        Text check;

        Boolean boxChecked = false;


        public CheckBox(HostileSpace Game, Int32 X, Int32 Y)
            : base(Game)
        {
            shape = new RectangleShape(new Vector2f(64, 64));
            shape.Texture = Game.ContentManager.GetTexture("Checkbox");
            shape.Position = new Vector2f(X, Y);
            shape.FillColor = Color.White;

            check = new Text("X", Game.ContentManager.GetFont("Arial"));
            check.CharacterSize = 34;
            check.Origin = new Vector2f(check.GetGlobalBounds().Width / 2, 0);
            check.Position = shape.Position + new Vector2f(shape.GetGlobalBounds().Width / 2, 10);
        }


        public override void Update(Time Elapsed)
        {           
        }

        public override void Draw(RenderWindow Window)
        {
            if (!Active)
                return;

            Window.Draw(shape);

            if(boxChecked)
                Window.Draw(check);
        }

        public override void Activate()
        {
            base.Activate();
            Game.Input.Mouse.LeftClicked += Mouse_LeftClicked;
        }

        public override void DeActivate()
        {
            base.DeActivate();
            Game.Input.Mouse.LeftClicked -= Mouse_LeftClicked;
        }

        private void Mouse_LeftClicked(object sender, EventArgs e)
        {
            if (shape.GetGlobalBounds().Intersects(Game.Input.Mouse.Position))
            {
                Game.AudioPlayer.PlaySound("GUI_CLICK");

                if (boxChecked)
                {
                    boxChecked = false;
                    UnCheckedEvent?.Invoke(this, null);
                }
                else
                {
                    boxChecked = true;
                    CheckedEvent?.Invoke(this, null);
                }
            }
        }


        public event EventHandler CheckedEvent;
        public event EventHandler UnCheckedEvent;

        public Boolean Checked
        {
            get { return boxChecked; }
            set { boxChecked = value; }
        }


    }
}
