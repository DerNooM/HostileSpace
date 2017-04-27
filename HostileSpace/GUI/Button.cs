using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace.GUI
{
    class Button : GameComponent
    {
        RectangleShape shape;
        Text text;

        Color normal = new Color(200, 200, 200);
        Boolean mouseClick = false;


        public Button(HostileSpace Game, String Text, Int32 X, Int32 Y)
            : base(Game)
        {
            shape = new RectangleShape(new Vector2f(192, 64));
            shape.Texture = Game.ContentManager.GetTexture("Button02");
            shape.Position = new Vector2f(X, Y);
            shape.FillColor = Color.White;


            text = new Text(Text, Game.ContentManager.GetFont("Arial"));
            text.CharacterSize = 24;
            text.Origin = new Vector2f(text.GetGlobalBounds().Width / 2, 0);
            text.Position = shape.Position + new Vector2f(shape.GetGlobalBounds().Width / 2, 18);

            Game.Input.Mouse.LeftClicked += Mouse_LeftClicked;
        }

        

        public override void Update(int Elapsed)
        {
            if (shape.GetGlobalBounds().Intersects(Game.Input.Mouse.Position))
            {
                shape.FillColor = Color.White;

                if (mouseClick)
                {                   
                    Game.AudioPlayer.PlaySound("GUI_CLICK");
                    ButtonPressed?.Invoke(this, null);
                }
            }
            else
            {
                shape.FillColor = normal;
            }

            mouseClick = false;
        }

        public override void Draw(RenderWindow Window)
        {
            Window.Draw(shape);
            Window.Draw(text);
        }

        private void Mouse_LeftClicked(object sender, EventArgs e)
        {
            mouseClick = true;
        }


        public event EventHandler ButtonPressed;

    }
}
