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
        SoundEffect pika = Ressources.mPika;
        SoundEffect pika2 = Ressources.mPika2;
        SoundEffect raichu = Ressources.mRaichu;
        SoundEffect raichu2 = Ressources.mRaichu2;
        SoundEffect explosionEffect = Ressources.mExplosionEffect;
        SoundEffect pop = Ressources.mPop;
        SoundEffect bloodEffect = Ressources.mBloodEffect;
        bool qui_crie = true;


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

            Random random = new Random();
            int randomNumber = random.Next(0, 4);
            if (randomNumber < 2)
            {
                try
                {
                    pika.Play();

                }
                catch
                {
                }
            }
            else
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

        public void PlayRaichu()
        {

            Random random = new Random();
            int randomNumber = random.Next(0, 4);
            if (randomNumber < 2)
            {
                try
                {
                    raichu.Play();
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    raichu2.Play();
                }
                catch
                {
                }
            }
        }




        public void PlayExplosionEffect()
        {
            try
            {
                explosionEffect.Play();
            }
            catch
            {
            }
        }


        public void PlayBloodEffect()
        {
            try
            {
                bloodEffect.Play();
            }
            catch
            {
            }
        }

        public void PlayPop()
        {
            try
            {
                pop.Play();
            }
            catch
            {
            }
        }
    }
}
