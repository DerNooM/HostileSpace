using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HostileSpace
{
    [Serializable]
    public class Settings
    {
        UInt32 resX = 0;
        UInt32 resY = 0;

        Boolean audio = true;
        Boolean sound = true;

        public Settings()
        {

        }


        public void Save(string FileName)
        {
            using (var writer = new System.IO.StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                writer.Flush();
            }
        }

        public static Settings Load(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(Settings));
                return serializer.Deserialize(stream) as Settings;
            }
        }


        public UInt32 ResolutionX
        {
            get { return resX; }
            set { resX = value; }
        }

        public UInt32 ResolutionY
        {
            get { return resY; }
            set { resY = value; }
        }

        public Boolean Audio
        {
            get { return audio; }
            set { audio = value; }
        }

        public Boolean Sound
        {
            get { return sound; }
            set { sound = value; }
        }


    }
}
