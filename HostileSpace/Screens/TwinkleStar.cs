using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace.Screens
{
    class TwinkleStar : GameComponent
    {
        Sprite star;
        Vector2f position = new Vector2f(0, 0);

        Int32 elapsed = 0;
        Int32 next = 0;

        static Random rand = new Random();

        Boolean up = true;

        public TwinkleStar(HostileSpace Game)
            : base(Game)
        {
            int tmp = rand.Next(0, 2);

            if(tmp == 0)
                star = new Sprite(Game.ContentManager.GetTexture("BigStar01"));
            else if(tmp == 1)
                star = new Sprite(Game.ContentManager.GetTexture("BigStar02"));

            star.Position = new Vector2f(100, 100);
            star.Origin = new Vector2f(8, 8);
            
        }


        public override void Update(Int32 Elapsed)
        {
            elapsed += Elapsed;

            if (elapsed >= next)
            {
                elapsed = 0;

                if (up)
                    up = false;
                else
                    up = true;
            }

            if (up)
            {
                star.Scale = new Vector2f(0.5f, 0.5f);
            }
            else
            {
                star.Scale = new Vector2f(1.6f, 1.6f);
            }

        }

        public override void Draw(RenderWindow Window)
        {
            Window.Draw(star);
        }

        public void SetPosition(Int32 X, Int32 Y)
        {
            position.X = X;
            position.Y = Y;
            star.Position = position;
        }

        public void Next(Int32 Next)
        {
            next = Next;
        }


    }
}
