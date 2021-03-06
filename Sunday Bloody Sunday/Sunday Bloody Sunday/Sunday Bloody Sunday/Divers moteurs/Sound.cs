﻿using System;
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
        SoundEffect sentryReady = Ressources.mSentryReady;
        SoundEffect sentryShoot = Ressources.mSentryShoot;
        SoundEffect rainEffect = Ressources.mRainEffect;
        SoundEffect planeEffect = Ressources.mPlaneEffect;
        SoundEffect spectrum = Ressources.mSpectrum;
        SoundEffect carabaffe1 = Ressources.mCarabaffe;
        SoundEffect tortank1 = Ressources.mTortank;
        SoundEffect eclair = Ressources.mSoneclair;
        int cooldownson = 0;
        public List<SoundEffect> listson = new List<SoundEffect>();


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

        public void Playpoke(int x)
        {
            listson.Add(pika);
            listson.Add(pika);
            //listson.Add(pika2);
            //listson.Add(raichu2);
            listson.Add(carabaffe1);
            listson.Add(spectrum);
            listson.Add(raichu);
            listson.Add(tortank1);
            if (/*cooldownson > 10*/true)
            {
                if (x >= 0)
                    listson[x].Play();
                cooldownson = 0;
            }
            else
            {
                cooldownson = cooldownson + 6;
            }

        }

        public void Playeclair()
        {
            try
            {
                eclair.Play();
            }
            catch
            {
            }
        }

        /*public void PlayPika(int id)
        {

            Random random = new Random();
            int randomNumber = random.Next(0, 5);

            if (id == 0)
            {
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
            else if (id == 1)
            {
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
        }
        */
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

        public void PlaySentryReady()
        {
            try
            {
                sentryReady.Play();
            }
            catch
            {
            }
        }

        public void PlaySentryShoot()
        {
            try
            {
                sentryShoot.Play();
            }
            catch
            {
            }
        }

        public void PlayRainEffect()
        {
            try
            {
                rainEffect.Play();
            }
            catch
            {
            }
        }

        public void PlayPlaneEffect()
        {
            try
            {
                planeEffect.Play();
            }
            catch
            {
            }
        }
    }
}
