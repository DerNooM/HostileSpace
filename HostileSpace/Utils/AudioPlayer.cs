using System;
using System.Collections.Generic;
using SFML.Audio;


namespace HostileSpace
{
    class AudioPlayer : GameComponent
    {
        struct SoundObject
        {
            public SoundBuffer SoundBuffer;
            public Sound Sound;
        }

        Dictionary<String, SoundObject> sounds = new Dictionary<String, SoundObject>();


        public AudioPlayer(HostileSpace Game)
            : base(Game)
        {
            SoundObject tmp;

            tmp = new SoundObject();
            tmp.SoundBuffer = new SoundBuffer("files/audio/gui/buttonclick.wav");
            tmp.Sound = new Sound(tmp.SoundBuffer);
            sounds.Add("GUI_CLICK", tmp);

        }


        public void PlaySound(String Name)
        {
            if (!Game.Settings.Sound)
                return;

            SoundObject tmp = sounds[Name];
            tmp.Sound.Play();
        }
        

    }
}
