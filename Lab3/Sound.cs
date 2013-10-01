using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMOD;
using FMODNet;

namespace Lab3
{
    class Sound
    {
        private FMODNet.SoundDevice device;
        private FMODNet.Sound       sound;
        private FMODNet.Channel     channel;

        private uint ms;
        private uint lenms;

        private bool playing;
        private bool paused;

        private int channelsplaying;

        Sound(String filename)
        {
            // Init sound device
            device = new FMODNet.SoundDevice();
            device.Initialize();
            // Load the sound
            sound = device.CreateSound(filename);
        }

        public void Play()
        {
            sound.Play();
        }

        public void Stop()
        {
            sound.Stop();
        }
    }
}
