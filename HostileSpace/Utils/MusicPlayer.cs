using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Audio;
using HostileSpace.Utils;


namespace HostileSpace
{
    class MusicPlayer : GameComponent
    {
        Music music;

        String directory = "files/audio/music/";
        List<String> paths = new List<String>();
        int index = 0;

        Time timer = Time.Zero;


        public MusicPlayer(HostileSpace Game)
            : base(Game)
        {
            paths.Add("DST-RailJet-LongSeamlessLoop");

            music = new Music(directory + paths[index] + ".ogg");
            music.Volume = 30;
            music.Loop = true;
            //music.Play();

            //index = (index + 1) % paths.Count;
        }


        public override void Update(Time Elapsed)
        {
            if(Game.GameData.Settings[0].Audio)
            {
                if (music.Status == SoundStatus.Stopped)
                    music.Play();
            }
            else
            {
                if (music.Status == SoundStatus.Playing)
                    music.Stop();
            }
        }


        public String GetCurrentTitle
        {
            get { return paths[index]; }
        }


    }
}
