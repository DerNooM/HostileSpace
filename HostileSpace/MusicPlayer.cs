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

        String directory = "audio/music/";
        List<String> paths = new List<String>();
        int index = 0;

        Time timer = Time.Zero;


        public MusicPlayer(HostileSpace Game)
            : base(Game)
        {
            paths.Add("DST-RailJet");
            paths.Add("Gregoire Lourme - Commando Team");
            paths.Add("tgfcoder-FrozenJam");
            paths.Add("Iwan Gabovitch - Dark Ambience");

            music = new Music(directory + paths[index] + ".ogg");
            music.Volume = 30;
            music.Loop = true;
            music.Play();

            index = (index + 1) % paths.Count;
        }


        public override void Update(Time Elapsed)
        {
            timer += Elapsed;

            if (timer.AsSeconds() >= 2 * 60)
            {
                music.Loop = false;
                timer = Time.Zero;
            }
            if(music.Status == SoundStatus.Stopped)
            {
                music = new Music(directory + paths[index] + ".ogg");
                music.Volume = 30;
                music.Play();
                music.Loop = true;
                index = (index + 1) % paths.Count;

                timer = Time.Zero;
            }
        }


        public String GetCurrentTitle
        {
            get { return paths[index]; }
        }


    }
}
