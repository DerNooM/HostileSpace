using System;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;

namespace HostileSpace
{
    class ContentManager
    {
        Dictionary<String, Font> fonts = new Dictionary<String, Font>();
        Dictionary<String, Texture> textures = new Dictionary<String, Texture>();


        public ContentManager()
        {
            fonts.Add("Arial", new Font("files/graphics/fonts/arial.ttf"));

            // background
            AddTexture("SmallStar01", "files/graphics/background/star_small01.png");
            AddTexture("SmallStar02", "files/graphics/background/star_small02.png");

            AddTexture("MediumStar01", "files/graphics/background/star_med01.png");
            AddTexture("MediumStar02", "files/graphics/background/star_med02.png");

            AddTexture("BigStar01", "files/graphics/background/star_big01.png");
            AddTexture("BigStar02", "files/graphics/background/star_big02.png");

            AddTexture("BlueNebula", "files/graphics/background/blue_nebula.png");
            AddTexture("BrownNebula", "files/graphics/background/brown_nebula.png");
            AddTexture("GrayNebula", "files/graphics/background/gray_nebula.png");
            AddTexture("PurpleNebula", "files/graphics/background/purple_nebula.png");

            // gui
            AddTexture("Mouse", "files/graphics/gui/pointer.png");

            AddTexture("Button01", "files/graphics/gui/box01.png");
            AddTexture("Button02", "files/graphics/gui/box02.png");
            AddTexture("Checkbox", "files/graphics/gui/box03.png");

            AddTexture("Bigbox", "files/graphics/gui/box06.png");


            // ship modules
            AddTexture("SmallLaser", "files/graphics/modules/laser.png");
            AddTexture("LargeLaser", "files/graphics/modules/large_laser.png");

            AddTexture("MissileLauncher", "files/graphics/modules/missile_launcher.png");
            AddTexture("TorpedoLauncher", "files/graphics/modules/torpedo_launcher.png");

            AddTexture("ShieldCapacitor", "files/graphics/modules/shield_generator.png");
            AddTexture("ShieldGenerator", "files/graphics/modules/shield_capacitor.png");

            AddTexture("EnergyCapacitor", "files/graphics/modules/energy_generator.png");
            AddTexture("EnergyGenerator", "files/graphics/modules/capacitor.png");

            AddTexture("LightArmor", "files/graphics/modules/light_armor.png");
            AddTexture("HeavyArmor", "files/graphics/modules/heavy_armor.png");

            AddTexture("ArmorRepairer", "files/graphics/modules/armor_repair.png");
            AddTexture("LargeArmorRepairer", "files/graphics/modules/large_armor_repair.png");

            // ships
            AddTexture("Ship01", "files/graphics/ships/F5S4.png");


            // misc
            AddTexture("DestinationMarker", "files/graphics/ships/destination.png");
        }

        void AddTexture(String Name, String Path)
        {
            textures.Add(Name, new Texture(Path));
            textures[Name].Smooth = true;
        }

        public Font GetFont(String Name)
        {
            return fonts[Name];
        }
        
        public Texture GetTexture(String Name)
        {
            return textures[Name];
        }
        
        
    }
}
