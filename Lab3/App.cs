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
        public Joystick joy;
        public Sound[]  sounds;
        
        App()
        {
            joy = new Joystick();

            sounds = Enumerable.Range(0, 3)
                .Select(i => new Sound(String.Format("sound{0}", i)))
                .ToArray();
        }
    }
}
