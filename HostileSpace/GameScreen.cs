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
    class GameScreen : GameObject
    {
        MiniMap miniMap;


        public GameScreen(HostileSpace Game)
            : base(Game)
        {
            miniMap = new MiniMap(Game);
        }


        public override void Update(Time Elapsed)
        {
            
        }

        public override void Draw(Time Elapsed)
        {
            miniMap.Draw(Elapsed);
        }

    }
}
