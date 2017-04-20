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
    class Healthbar : GameComponent
    {
        RectangleShape over = new RectangleShape(new Vector2f(100, 10));
        RectangleShape fill = new RectangleShape(new Vector2f(100, 10));

        Vector2f position = new Vector2f(0, 0);
        Single rotation = 0.0f;

        UInt16 maxAmount = 100;
        UInt16 currentAmount = 50;

        Vector2f currentFillsize = new Vector2f(100, 10);

        public Healthbar(HostileSpace Game, Vector2f Offset)
            : base(Game)
        {
            fill.FillColor = Color.Green;
            fill.Origin = new Vector2f(Offset.X, Offset.Y);

            over.OutlineThickness = 2;
            over.OutlineColor = Color.Red;
            over.FillColor = Color.Transparent;
            over.Origin = new Vector2f(Offset.X, Offset.Y);
        }


        public override void Update(Time Elapsed)
        {
            fill.Rotation = rotation;
            fill.Position = position;

            over.Rotation = rotation;
            over.Position = position;

            currentFillsize.X = (100 / maxAmount) * currentAmount;
            fill.Size = currentFillsize;
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(fill);
            Game.RenderWindow.Draw(over);
        }


        public Vector2f Position
        {
            get { return position; }
            set { position = value; }
        }

        public Single Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Color FillColor
        {
            get { return fill.FillColor; }
            set { fill.FillColor = value; }
        }

        public UInt16 MaxAmount
        {
            get { return maxAmount; }
            set { maxAmount = value; }
        }

        public UInt16 CurrentAmount
        {
            get { return currentAmount; }
            set { currentAmount = value; }
        }


    }
}
