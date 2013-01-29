using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sunday_Bloody_Sunday
{
    class Sound
    {
        // FIELDS
        SoundEffect tire = Ressources.mTire;
        SoundEffect pika= Ressources.mPika;
        SoundEffect pika2 = Ressources.mPika2;
        SoundEffect introEffect = Ressources.mIntroEffect;


        // METHODS
        public void PlayTire()
        {
            try
            {
                tire.Play();
            }
            catch
            {
            }
        }

        public void PlayPika()
        {
            try
            {
                pika.Play();
            }
            catch
            {
            }
        }

        public void PlayPika2()
        {
            try
            {
                pika2.Play();
            }
            catch
            {
            }
        }
    }
}
