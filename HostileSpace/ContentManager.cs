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
            fonts.Add("Arial", new Font("graphics/fonts/arial.ttf"));
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
