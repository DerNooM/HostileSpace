using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace.Screens
{
    class Background : GameComponent
    {
        Random rand = new Random();

        List<TwinkleStar> twinkleStars = new List<TwinkleStar>();

        List<Sprite> smallStars = new List<Sprite>();
        List<Sprite> mediumStars = new List<Sprite>();
        List<Sprite> bigStars = new List<Sprite>();

        RenderTexture texture = new RenderTexture(8192, 8192);
        Sprite sprite;


        public Background(HostileSpace Game)
            : base(Game)
        {
            Generate();
        }

        public override void Update(Int32 Elapsed)
        {
            foreach(TwinkleStar star in twinkleStars)
            {
                star.Next(rand.Next(5, 30));
                star.Update(Elapsed);
            }
        }

        public override void Draw(RenderWindow Window)
        {
            Window.Draw(sprite);

            foreach (TwinkleStar star in twinkleStars)
            {
                star.Draw(Window);
            }
        }

        public void Generate()
        {
            twinkleStars.Clear();
            smallStars.Clear();
            mediumStars.Clear();
            bigStars.Clear();

            for (int i = 0; i < 100; i++)
            {
                TwinkleStar tmp = new TwinkleStar(Game);
                tmp.SetPosition(rand.Next(0, 8192), rand.Next(0, 8192));
                twinkleStars.Add(tmp);
            }

            for (int i = 0; i < 5000; i++)
            {
                Sprite sprite = null;

                int tmp = rand.Next(0, 2);

                if (tmp == 0)
                    sprite = new Sprite(Game.ContentManager.GetTexture("SmallStar01"));
                else if (tmp == 1)
                    sprite = new Sprite(Game.ContentManager.GetTexture("SmallStar02"));

                sprite.Position = new Vector2f(rand.Next(0, 8192), rand.Next(0, 8192));
                smallStars.Add(sprite);
            }

            for (int i = 0; i < 1500; i++)
            {
                Sprite sprite = null;

                int tmp = rand.Next(0, 2);

                if (tmp == 0)
                    sprite = new Sprite(Game.ContentManager.GetTexture("MediumStar01"));
                else if (tmp == 1)
                    sprite = new Sprite(Game.ContentManager.GetTexture("MediumStar02"));

                sprite.Position = new Vector2f(rand.Next(0, 8192), rand.Next(0, 8192));
                mediumStars.Add(sprite);
            }

            for (int i = 0; i < 1000; i++)
            {
                Sprite sprite = null;

                int tmp = rand.Next(0, 2);

                if (tmp == 0)
                    sprite = new Sprite(Game.ContentManager.GetTexture("BigStar01"));
                else if (tmp == 1)
                    sprite = new Sprite(Game.ContentManager.GetTexture("BigStar02"));

                sprite.Position = new Vector2f(rand.Next(0, 8192), rand.Next(0, 8192));
                bigStars.Add(sprite);
            }

            texture.Clear();

            foreach (Sprite star in smallStars)
            {
                texture.Draw(star);
            }

            foreach (Sprite star in mediumStars)
            {
                texture.Draw(star);
            }

            foreach (Sprite star in bigStars)
            {
                texture.Draw(star);
            }

            sprite = new Sprite(texture.Texture);
        }


    }
}
