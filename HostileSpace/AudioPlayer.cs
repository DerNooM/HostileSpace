using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Audio;

namespace HostileSpace
{
    class AudioPlayer
    {
        struct SoundObject
        {
            public SoundBuffer SoundBuffer;
            public Sound Sound;
        }

        Dictionary<String, SoundObject> sounds = new Dictionary<String, SoundObject>();

        public AudioPlayer()
        {
            SoundObject tmp = new SoundObject();
            tmp.SoundBuffer = new SoundBuffer("audio/gui/err.wav");
            tmp.Sound = new Sound(tmp.SoundBuffer);
            sounds.Add("GUI_ERROR", tmp);

            tmp = new SoundObject();
            tmp.SoundBuffer = new SoundBuffer("audio/gui/buttonclick.wav");
            tmp.Sound = new Sound(tmp.SoundBuffer);
            sounds.Add("GUI_CLICK", tmp);

        }


        public void PlaySound(String Name)
        {
            SoundObject tmp = sounds[Name];
            tmp.Sound.Play();
        }
        
    }
}
