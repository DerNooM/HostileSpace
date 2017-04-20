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
    class SpaceShip : GameComponent
    {
        Sprite ship;
        Vector2f spriteOffset;

        Vector2f position = new Vector2f(0, 0);
        Vector2f destination = new Vector2f(0, 0);
        Vector2f direction = new Vector2f(0, 0);

        Single rotation = 0;

        Single maxSpeed = 0.3f;
        Single turnRate = 0.002f;
        Single acceleration = 0;

        Healthbar shield;
        Healthbar armor;

        public SpaceShip(HostileSpace Game)
            : base(Game)
        {
            ship = new Sprite();

            ship.Texture = Game.ContentManager.GetTexture("Ship01");
            spriteOffset = new Vector2f(ship.Texture.Size.X / 2, ship.Texture.Size.Y / 2);
            ship.Origin = spriteOffset;

            shield = new Healthbar(Game, new Vector2f(0, 90));
            armor = new Healthbar(Game, new Vector2f(0, 70));
            armor.FillColor = Color.Blue;
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

        private static Single GetDistance(Vector2f A, Vector2f B)
        {
            return (Single)Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
        }

        public void SetData(UpdateShip.ShipData Data)
        {
            position = Data.Position;
            rotation = Data.Rotation;
            destination = Data.Destination;
        }

        public override void Update(Time Elapsed)
        {

            /*if (GetDistance(ship.Position, destination) < 50)
            {
                acceleration = 0;
                return;
            }

            if (GetDistance(ship.Position, destination) > 200)
            {
                if (acceleration < 1.0f)
                {
                    acceleration += 0.0005f * Elapsed.AsMilliseconds();
                }
            }
            else
            {
                if (acceleration > 0.2f)
                {
                    acceleration -= 0.0008f * Elapsed.AsMilliseconds();
                }
            }

            if(ship.Rotation >= 360)
            {
                ship.Rotation = 0;
            }
            if (ship.Rotation <= -360)
            {
                ship.Rotation = 0;
            }

            direction = destination - position;
            rotation = (float)Math.Atan2(direction.Y, direction.X);

            rotation = RadianToDegree(rotation);

            ship.Rotation -= (turnRate * Elapsed.AsMilliseconds()) * ShortestRotation(rotation, ship.Rotation);

            direction.Y = (Single)Math.Sin(DegreeToRadian(ship.Rotation)) * maxSpeed * acceleration * Elapsed.AsMilliseconds();
            direction.X = (Single)Math.Cos(DegreeToRadian(ship.Rotation)) * maxSpeed * acceleration * Elapsed.AsMilliseconds();

            position += direction;
            ship.Position = position;
            */

            ship.Position = position;
            ship.Rotation = rotation;


            shield.Position = ship.Position;
            shield.Rotation = ship.Rotation;
            shield.Update(Elapsed);

            armor.Position = ship.Position;
            armor.Rotation = ship.Rotation;
            armor.Update(Elapsed);
        }


        
        
        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(ship);
            shield.Draw(Elapsed);
            armor.Draw(Elapsed);
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
