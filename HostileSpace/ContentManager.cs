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
            textures.Add("SmallStar01", new Texture("files/graphics/background/star_small01.png"));
            textures.Add("SmallStar02", new Texture("files/graphics/background/star_small02.png"));

            textures.Add("MediumStar01", new Texture("files/graphics/background/star_med01.png"));
            textures.Add("MediumStar02", new Texture("files/graphics/background/star_med02.png"));

            textures.Add("BigStar01", new Texture("files/graphics/background/star_big01.png"));
            textures.Add("BigStar02", new Texture("files/graphics/background/star_big02.png"));

            // character selection
            textures.Add("Char00", new Texture("files/graphics/heads/char00.png"));
            textures.Add("Char01", new Texture("files/graphics/heads/male2.png"));

            // ships
            textures.Add("Ship01", new Texture("files/graphics/ships/F5S4.png"));

            // misc
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
