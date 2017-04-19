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

        SpaceShip shipA;
        SpaceShip shipB;

        View view = new View();


        Sprite background;
        float zoom = 1;

        public GameScreen(HostileSpace Game)
            : base(Game)
        {
            miniMap = new MiniMap(Game);
            shipA = new SpaceShip(Game);
            shipA.Position = new Vector2f(100, 200);
            shipA.Destination = shipA.Position;

            Game.MouseState.LeftPressed += MouseState_LeftPressed;

            shipB = new SpaceShip(Game);
            shipB.Position = new Vector2f(500,500);

            view = Game.RenderWindow.DefaultView;
            view.Zoom(1.5f);
            background = new Sprite(Game.ContentManager.GetTexture("Background01"));

            Game.RenderWindow.MouseWheelMoved += RenderWindow_MouseWheelMoved;
        }

        private void RenderWindow_MouseWheelMoved(object sender, SFML.Window.MouseWheelEventArgs e)
        {
            if(e.Delta == 1)
            {
                if (zoom < 1.5f)
                {
                    zoom += 0.1f;
                    view.Zoom(1.1f);
                }
            }
            if (e.Delta == -1)
            {
                if (zoom > 0.5f)
                {
                    zoom -= 0.1f;
                    view.Zoom(0.9f);
                }
            }
        }

        private void MouseState_LeftPressed(object sender, EventArgs e)
        {
            shipA.Destination = Game.RenderWindow.MapPixelToCoords((Vector2i)Game.MouseState.PositionVector, view);
        }

        Vector2f tmp = new Vector2f(0, 0.2f);
        public override void Update(Time Elapsed)
        {

            //shipA.Position -= tmp;

            //shipA.Destination = Game.RenderWindow.MapPixelToCoords((Vector2i)Game.MouseState.PositionVector, view);
            //shipA.Destination = Game.MouseState.PositionVector;


            shipB.Update(Elapsed);
            shipA.Update(Elapsed);
        }

        public override void Draw(Time Elapsed)
        {
            
            miniMap.Draw(Elapsed);

            view.Center = shipA.Position;
            Game.RenderWindow.SetView(view);

            Game.RenderWindow.Draw(background);

            shipA.Draw(Elapsed);
            shipB.Draw(Elapsed);

            Game.RenderWindow.SetView(Game.RenderWindow.DefaultView);
        }

    }
}
