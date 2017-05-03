using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;


namespace HostileSpace
{
    class PlayerShip : SpaceShip
    {
        CircleShape shortRange;
        CircleShape longRange;

        RectangleShape destination;
        public PlayerShip(HostileSpace Game)
            : base(Game)
        {
            Ship = new RectangleShape(new Vector2f(291, 173));
            Ship.Texture = Game.ContentManager.GetTexture("Ship01");
            Ship.Origin = new Vector2f(Ship.Texture.Size.X / 2, Ship.Texture.Size.Y / 2);
            Ship.Scale = Ship.Scale / 2;
            Ship.Position = new Vector2f(Game.Window.Size.X / 2, Game.Window.Size.Y / 2);

            destination = new RectangleShape(new Vector2f(64, 64));
            destination.Texture = Game.ContentManager.GetTexture("DestinationMarker");
            destination.Scale = new Vector2f(0.5f, 0.5f);

            SetupShortRangeIndicator();
            SetupLongRangeIndicator();

            Game.Input.Mouse.RightClicked += Mouse_RightClicked;

        }

        private void Mouse_RightClicked(object sender, EventArgs e)
        {
            Vector2f tmp = Game.Window.MapPixelToCoords(SFML.Window.Mouse.GetPosition(Game.Window), Game.Camera);
            SetDestination(tmp);
            destination.Position = tmp;
        }

        public override void Update(Time Elapsed)
        {
            base.Update(Elapsed);
        }

        public override void Draw(RenderWindow Window)
        {
            base.Draw(Window);

            Game.Window.SetView(Game.Window.DefaultView);
            Window.Draw(shortRange);
            Window.Draw(longRange);
            Game.Window.SetView(Game.Camera);

            if (!Stopped)
                Window.Draw(destination);
        }

        public void SetupShortRangeIndicator()
        {
            shortRange = new CircleShape(ShortRangeDistance);
            shortRange.OutlineColor = new Color(255, 255, 255, 20);
            shortRange.OutlineThickness = 1;
            shortRange.FillColor = Color.Transparent;
            shortRange.Position = Position;
            shortRange.Origin = new Vector2f(shortRange.GetGlobalBounds().Width / 2, shortRange.GetGlobalBounds().Height / 2);
        }

        public void SetupLongRangeIndicator()
        {
            longRange = new CircleShape(LongRangeDistance);
            longRange.OutlineColor = new Color(255, 255, 255, 20);
            longRange.OutlineThickness = 1;
            longRange.FillColor = Color.Transparent;
            longRange.Position = Position;
            longRange.Origin = new Vector2f(longRange.GetGlobalBounds().Width / 2, longRange.GetGlobalBounds().Height / 2);
        }

    }
}
