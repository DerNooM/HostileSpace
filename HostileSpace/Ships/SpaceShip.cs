using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace HostileSpace
{
    class SpaceShip : GameComponent
    {
        RectangleShape ship = null;

        const Single shortRangeDistance = 200;
        const Single longRangeDistance = 350;

        Boolean alive = true;


        Vector2f destination = new Vector2f(0, 0);

        Vector2f direction = new Vector2f(0, 0);
        Single velocity = 0.1f;
        Single rotation = 0.0f;

        Single mass = 500;


        Boolean stopped = true;

        public SpaceShip(HostileSpace Game)
            : base(Game)
        {
            Ship = new RectangleShape(new Vector2f(291, 173));
            Ship.Texture = Game.ContentManager.GetTexture("Ship01");
            Ship.Origin = new Vector2f(Ship.Texture.Size.X / 2, Ship.Texture.Size.Y / 2);
            Ship.Scale = Ship.Scale / 4;
            Ship.Position = new Vector2f(Game.Window.Size.X / 2, Game.Window.Size.Y / 2);
        }


        public void SetDestination(Vector2f Destination)
        {
            if (MathHelper.GetDistance(ship.Position, Destination) > 30)
            {
                destination = Destination;
            }
        }

        public override void Update(Time Elapsed)
        {
            if (!alive || !Active)
                return;

            if (MathHelper.GetDistance(ship.Position, destination) < 30)
            {
                velocity = 0;
                stopped = true;
                return;
            }
            else
                stopped = false;
            
            if (MathHelper.GetDistance(ship.Position, destination) > 100)
            {
                velocity = (Single)Math.Min(1.0, velocity + (0.5f * Elapsed.AsMilliseconds()) / mass);
            }
            else
            {
                velocity = (Single)Math.Max(0.2f, velocity - (0.5f * Elapsed.AsMilliseconds()) / mass);
            }
            
            if (ship.Rotation >= 360)
            {
                ship.Rotation = 0;
            }
            if (ship.Rotation <= -360)
            {
                ship.Rotation = 0;
            }

            direction = destination - ship.Position;

            rotation = (float)Math.Atan2(direction.Y, direction.X);
            rotation = MathHelper.RadianToDegree(rotation);
            ship.Rotation -= (0.002f * Elapsed.AsMilliseconds()) * MathHelper.ShortestRotation(rotation, ship.Rotation);

            direction.Y = (Single)Math.Sin(MathHelper.DegreeToRadian(ship.Rotation));
            direction.X = (Single)Math.Cos(MathHelper.DegreeToRadian(ship.Rotation));

            ship.Position += direction * velocity * 0.2f * Elapsed.AsMilliseconds();
        }


        public override void Draw(RenderWindow Window)
        {
            if (!alive || !Active)
                return;

            Window.Draw(ship);
        }



        public Boolean Alive
        {
            get { return alive; }
        }

        public RectangleShape Ship
        {
            get { return ship; }
            set { ship = value; }
        }


        public Vector2f Position
        {
            get { return ship.Position; }
        }

        public Single ShortRangeDistance
        {
            get { return shortRangeDistance; }
        }

        public Single LongRangeDistance
        {
            get { return longRangeDistance; }
        }

        public Boolean Stopped
        {
            get { return stopped; }
        }


    }
}
