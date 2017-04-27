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

            // gui
            AddTexture("Mouse", "files/graphics/gui/pointer.png");

            AddTexture("Button01", "files/graphics/gui/box01.png");
            AddTexture("Button02", "files/graphics/gui/box02.png");
            AddTexture("Checkbox", "files/graphics/gui/box03.png");

            AddTexture("Bigbox", "files/graphics/gui/box06.png");


            // character selection
            AddTexture("Char00", "files/graphics/heads/char00.png");
            AddTexture("Char01", "files/graphics/heads/male2.png");

            // playership
            AddTexture("Laser", "files/graphics/playership/laser.png");
            AddTexture("MissileLauncher", "files/graphics/playership/missile_launcher.png");

            AddTexture("ShieldGenerator", "files/graphics/playership/shield_generator.png");
            AddTexture("ShieldCapacitor", "files/graphics/playership/shield_capacitor.png");

            AddTexture("EnergyGenerator", "files/graphics/playership/energy_generator.png");
            AddTexture("EnergyCapacitor", "files/graphics/playership/capacitor.png");

            AddTexture("LightArmor", "files/graphics/playership/light_armor.png");
            AddTexture("HeavyArmor", "files/graphics/playership/heavy_armor.png");


            // ships
            AddTexture("Ship01", "files/graphics/ships/F5S4.png");


            // misc
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
