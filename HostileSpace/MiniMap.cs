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
    class MiniMap : GameComponent
    {
        RectangleShape background;


        public MiniMap(HostileSpace Game)
            : base(Game)
        {
            background = new RectangleShape(new Vector2f(128, 128));
            background.FillColor = Colors.GuiA;
            background.OutlineColor = Color.Black;
            background.OutlineThickness = 4;
            

        }


        public override void Update(Time Elapsed)
        {
            
        }

        public override void Draw(Time Elapsed)
        {
            Game.RenderWindow.Draw(background);
        }





    }
}
