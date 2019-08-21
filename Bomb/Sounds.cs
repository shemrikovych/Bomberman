using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Bomb
{
    static class Sounds
    {
        public static SoundPlayer sound = new SoundPlayer("game.wav");
        static bool SoundEnabled = false;
        public static void SoundOn()
        {
            SoundEnabled = true;

        }
        public static void SoundOff()
        {
            SoundEnabled = false;

        }
        public static void Play()
        {
            if (SoundEnabled == true)
            {
                sound.PlayLooping();
            }

        }
        public static void Stop()
        {
            if(SoundEnabled == false)
            {
                sound.Stop();
            }
        }



    }
}
