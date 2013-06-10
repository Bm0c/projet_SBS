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
    class Ressources
    {
        // STATICS FIELDS
        public static Texture2D Player1, Player2, Player3,
                                Map, Map02, Map03,Map04,Map05,
                                Map_transparent,Map02_transparent,Map03_transparent,
                                ThumbnailsMap01, ThumbnailsMap02, ThumbnailsMap03, ThumbnailsMap03_bonus,ThumbnailsMap04,ThumbnailsMap05,
                                Projectile,
                                BloodParticule, ExplosionParticule,
                                IA1, IA1attack, IA1_dead, IA2, IA5attack, IA3, IA3attack, IA4, IA4attack, IA5, IA6, IA6attack, IA7,
                                mHealthBox, mAmmoBox,
                                mExplosiveBox, mBomb,
                                mTitleScreen, mGameOverScreen, mWinSreen, mPlayScreen,
                                mCross, mBossEntry,
                                mRain, mPlane, mTarget, mattackeclair;
        
        // HUD
        public static SpriteFont HUD;
        // Sounds
        public static Song GamePlayMusic, MenuMusic, HightVoltage, BlackIce;
        public static SoundEffect mSentryReady, mSentryShoot,
                                  mRainEffect, mPlaneEffect,
                                  mTire, mPika, mPika2, mRaichu, mRaichu2, 
                                  mIntroEffect, mLoseEffect, mWinEffect,
                                  mExplosionEffect, mPop, mBloodEffect,
                                  mTortank, mCarabaffe, mSpectrum, mSoneclair;


        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {
            Map = content.Load<Texture2D>("Map");
            Map02 = content.Load<Texture2D>("Map02");
            Map03 = content.Load<Texture2D>("Map03");
            Map04 = content.Load<Texture2D>("Map04");
            Map05 = content.Load<Texture2D>("Map05");
            Map_transparent = content.Load<Texture2D>("Map_Transparent");
            Map02_transparent = content.Load<Texture2D>("Map02_surcouche");
            Map03_transparent = content.Load<Texture2D>("Map03_surcouche");
            ThumbnailsMap01 = content.Load<Texture2D>("thumbnails_map_01");
            ThumbnailsMap02 = content.Load<Texture2D>("thumbnails_map_02");
            ThumbnailsMap03 = content.Load<Texture2D>("thumbnails_map_03");
            ThumbnailsMap03_bonus = content.Load<Texture2D>("thumbnails_map_03_bonus");
            ThumbnailsMap04 = content.Load<Texture2D>("thumbnails_map_04");
            ThumbnailsMap05 = content.Load<Texture2D>("thumbnails_map_05");
            Player1 = content.Load<Texture2D>("Chara");
            Player2 = content.Load<Texture2D>("Chara2");
            Player3 = content.Load<Texture2D>("Chara3");
            Projectile = content.Load<Texture2D>("balle");
            ExplosionParticule = content.Load<Texture2D>("explosion");
            BloodParticule = content.Load<Texture2D>("blood");
            IA1 = content.Load<Texture2D>("pikachu");
            IA1attack = content.Load<Texture2D>("pikaattack");
            IA2 = content.Load<Texture2D>("pikachu_2");
            IA3 = content.Load<Texture2D>("Carabaffe_");
            IA3attack = content.Load<Texture2D>("carabaffeattack2");
            IA4 = content.Load<Texture2D>("Spectrum");
            IA4attack = content.Load<Texture2D>("spectrumattack2");
            IA5 = content.Load<Texture2D>("Raichu2");
            IA5attack = content.Load<Texture2D>("raichuattack");
            mattackeclair = content.Load<Texture2D>("attackeclair2");
            IA6 = content.Load<Texture2D>("Tortank");
            IA6attack = content.Load<Texture2D>("tortankattack");
            IA7 = content.Load<Texture2D>("Elector");
            HUD = content.Load<SpriteFont>("gameFont");
            GamePlayMusic = content.Load<Song>("gameplay_music");
            MenuMusic = content.Load<Song>("elevator_music");
            mIntroEffect = content.Load<SoundEffect>("zombie_groan");
            mLoseEffect = content.Load<SoundEffect>("lose_effect");
            mWinEffect = content.Load<SoundEffect>("win_effect");
            mExplosionEffect = content.Load<SoundEffect>("explosion_effect");
            mBloodEffect = content.Load<SoundEffect>("blood_effect");
            mPop = content.Load<SoundEffect>("pop");
            mTire = content.Load<SoundEffect>("tire");
            mPika = content.Load<SoundEffect>("pikachu001");
            mPika2 = content.Load<SoundEffect>("pikachu002");
            mRaichu = content.Load<SoundEffect>("raichuSon"); 
            mCarabaffe = content.Load<SoundEffect>("carabaffeson");
            mTortank = content.Load<SoundEffect>("tortankson");
            mSpectrum = content.Load<SoundEffect>("spectrumson");
            mRaichu2 = content.Load<SoundEffect>("raichuSon2");
            mSoneclair = content.Load<SoundEffect>("soneclair");
            mHealthBox = content.Load<Texture2D>("health_box");
            mAmmoBox = content.Load<Texture2D>("ammo_box");
            mExplosiveBox = content.Load<Texture2D>("explosive_box");
            mBomb = content.Load<Texture2D>("bomb");
            mTitleScreen = content.Load<Texture2D>("Title");
            mGameOverScreen = content.Load<Texture2D>("GameOver");
            mWinSreen = content.Load<Texture2D>("WinScreen");
            mPlayScreen = content.Load<Texture2D>("melodelf");
            mCross = content.Load<Texture2D>("cross");
            mBossEntry = content.Load<Texture2D>("boss_entry");
            mRain = content.Load<Texture2D>("rain");
            mPlane = content.Load<Texture2D>("plane");
            mTarget = content.Load<Texture2D>("target");
            mSentryReady = content.Load<SoundEffect>("place_sentry");
            mSentryShoot = content.Load<SoundEffect>("sentry_shoot");
            mRainEffect = content.Load<SoundEffect>("rainEffect");
            mPlaneEffect = content.Load<SoundEffect>("plane_running");

            HightVoltage = content.Load<Song>("HightVoltage");
            BlackIce = content.Load<Song>("Black Ice");
        }
    }
}
