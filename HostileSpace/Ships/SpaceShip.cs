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
        CircleShape shortRange;
        CircleShape longRange;

        ShipModule[] modules = new ShipModule[24];

        Int32 shield = 0;
        Int32 energy = 0;
        Int32 armor = 0;

        Single shortRangeDistance = 200;
        Single longRangeDistance = 350;


        SpaceShip target = null;

        Boolean alive = true;

        public SpaceShip(HostileSpace Game)
            : base(Game)
        {
            for (int i = 0; i < 24; i++)
                modules[i] = null;
        }


        Time tmp = Time.FromMilliseconds(1000);

        public override void Update(Time Elapsed)
        {
            if (!alive)
                return;

            /*
            tmp -= Elapsed;

            if(tmp.AsMilliseconds() < 0)
            {
                tmp += Time.FromMilliseconds(1000);
                Console.WriteLine("1 sec");
            }
            */
            for (int i = 0; i < 24; i++)
            {
                if (modules[i] != null)
                {

                    if (modules[i].Type == ModuleTypes.SmallLaser)
                    {

                        HandleSmallLAser(Elapsed, modules[i]);
                    }



                }
            }
        }
        

        void HandleSmallLAser(Time Elapsed, ShipModule Module)
        {
            Module.CurrentCooldown -= Elapsed;

            
            if (Module.CurrentCooldown < Time.Zero)
            {
                Module.CurrentCooldown += Module.MaxCooldown;

                if (target != null)
                {
                    if(!target.Alive)
                    {
                        target = null;
                        return;
                    }
                    if (MathHelper.GetDistance(target.Ship.Position, ship.Position) <= shortRangeDistance)
                    {
                        
                        
                        FireSmallLaser();
                    }


                }
            }
        }

        public void AddModule(ShipModule Module)
        {
            for(int i = 0; i < 24; i++)
            {
                if (modules[i] == null)
                {
                    modules[i] = Module;
                    return;
                }
            }
        }

        void FireSmallLaser()
        {
            Console.WriteLine(DateTime.Now +  " small laser fired");
        }

        public void TakeDamage(UInt16 Ammount)
        {
            if (shield > 0)
            {
                shield -= Ammount;

                if (shield < 0)
                    shield = 0;
            }
            else
            {
                armor -= Ammount;

                if (armor <= 0)
                {
                    armor = 0;
                    Explode();
                }
            }
        }

        void Explode()
        {
            alive = false;

        }

        public void SetTarget(SpaceShip Target)
        {
            target = Target;
        }

        public override void Draw(RenderWindow Window)
        {
            Window.Draw(ship);
            Window.Draw(shortRange);
            Window.Draw(longRange);
        }

        public void SetupShortRangeIndicator()
        {
            shortRange = new CircleShape(shortRangeDistance);
            shortRange.OutlineColor = new Color(255, 255, 255, 20);
            shortRange.OutlineThickness = 1;
            shortRange.FillColor = Color.Transparent;
            shortRange.Position = ship.Position;
            shortRange.Origin = new Vector2f(shortRange.GetGlobalBounds().Width / 2, shortRange.GetGlobalBounds().Height / 2);
        }

        public void SetupLongRangeIndicator()
        {
            longRange = new CircleShape(longRangeDistance);
            longRange.OutlineColor = new Color(255, 255, 255, 20);
            longRange.OutlineThickness = 1;
            longRange.FillColor = Color.Transparent;
            longRange.Position = ship.Position;
            longRange.Origin = new Vector2f(longRange.GetGlobalBounds().Width / 2, longRange.GetGlobalBounds().Height / 2);
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



    }
}
