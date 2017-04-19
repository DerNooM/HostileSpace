using System;
using System.Text;
using SFML.System;
using SFML.Graphics;
using HostileSpace.Utils;
using HostileSpace.GUI;
using System.Security.Cryptography;
using HostileSpaceNetLib;
using HostileSpaceNetLib.Packets;

namespace HostileSpace
{
    class SpaceShip : GameObject
    {
        Sprite ship;
        Vector2f spriteOffset;

        Vector2f position = new Vector2f(0, 0);
        Vector2f destination = new Vector2f(0, 0);
        Vector2f direction = new Vector2f(0, 0);

        Single rotation = 0;

        FloatRect destinationRect = new FloatRect(0, 0, 1, 1);

        Single maxSpeed = 0.2f;
        Single turnRate = 0.002f;
        Single currentSpeed = 0;


        public SpaceShip(HostileSpace Game)
            : base(Game)
        {
            ship = new Sprite();

            ship.Texture = Game.ContentManager.GetTexture("Ship01");
            spriteOffset = new Vector2f(ship.Texture.Size.X / 2, ship.Texture.Size.Y / 2);
            ship.Origin = spriteOffset;
        }


        Single ShortestRotation(Single start, Single end)
        {
            Single diff = end - start;

            if (diff > 180.0f)
                diff -= 360.0f;
            else if (diff < -180.0f)
                diff += 360.0f;

            return diff;
        }


        private Single DegreeToRadian(Single angle)
        {
            return (Single)Math.PI * angle / 180.0f;
        }

        private Single RadianToDegree(Single angle)
        {
            return angle * (180.0f / (Single)Math.PI);
        }


        public override void Update(Time Elapsed)
        {
            destinationRect.Left = destination.X;
            destinationRect.Top = destination.Y;

            if (ship.GetGlobalBounds().Intersects(destinationRect))
            {
                currentSpeed = 0;
                return;
            }



            direction = destination - position;
            rotation = (float)Math.Atan2(direction.Y, direction.X);

            rotation = RadianToDegree(rotation);

            ship.Rotation -= (turnRate * Elapsed.AsMilliseconds()) * ShortestRotation(rotation, ship.Rotation);


            direction.X = (Single)Math.Sin(DegreeToRadian(ship.Rotation + 90)) * currentSpeed * Elapsed.AsMilliseconds();
            direction.Y = -(Single)Math.Cos(DegreeToRadian(ship.Rotation + 90)) * currentSpeed * Elapsed.AsMilliseconds();


            position += direction;
            ship.Position = position;
        }

        
        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(ship);
        }


        public Vector2f Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2f Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public Single Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        

    }
}
