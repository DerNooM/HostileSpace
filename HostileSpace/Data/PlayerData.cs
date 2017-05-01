using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HostileSpace
{
    [Serializable]
    public class PlayerData
    {
        UInt32 credits = 0;
        int[] modules = new int[24];

        public PlayerData()
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

        public static PlayerData Load(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(PlayerData));
                return serializer.Deserialize(stream) as PlayerData;
            }
        }


        public UInt32 Credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public int[] Modules
        {
            get { return modules; }
            set { modules = value; }
        }

    }
}
