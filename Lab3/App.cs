using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;

namespace Lab3
{
    class App
    {
        public Joystick joy = new Joystick();

        private const int numSounds = 3;
        public Sound[] sounds = Enumerable.Range(1, numSounds)
            .Select(i => new Sound(String.Format("sound{0}", i)))
            .ToArray();
    }
}
