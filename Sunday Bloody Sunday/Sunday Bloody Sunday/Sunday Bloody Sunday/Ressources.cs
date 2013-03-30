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
        public static Texture2D Player1, Player2, Player3, Map, Map02, Map03, ThumbnailsMap01, ThumbnailsMap02, ThumbnailsMap03, ThumbnailsMap04, Projectile, BloodParticule, ExplosionParticule, IA1, IA2, IA3, IA4, IA5, IA6, mHealthBox, mAmmoBox, mExplosiveBox, mBomb, mTitleScreen, mGameOverScreen, mWinSreen, mCross, mRain;
        // HUD
        public static SpriteFont HUD;
        // Sounds
        public static Song GamePlayMusic, MenuMusic;
        public static SoundEffect mTire, mPika, mPika2, mRaichu, mRaichu2, mIntroEffect, mLoseEffect, mWinEffect, mExplosionEffect, mPop, mBloodEffect;

        
        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {
            Map = content.Load<Texture2D>("Map");
            Map02 = content.Load<Texture2D>("Map02");
            Map03 = content.Load<Texture2D>("Map03");
            ThumbnailsMap01 = content.Load<Texture2D>("thumbnails_map_01");
            ThumbnailsMap02 = content.Load<Texture2D>("thumbnails_map_02");
            ThumbnailsMap03 = content.Load<Texture2D>("thumbnails_map_03");
            ThumbnailsMap04 = content.Load<Texture2D>("thumbnails_map_04");
            Player1 = content.Load<Texture2D>("Chara");
            Player2 = content.Load<Texture2D>("Chara2");
            Player3 = content.Load<Texture2D>("Chara3");
            Projectile = content.Load<Texture2D>("balle");
            ExplosionParticule = content.Load<Texture2D>("explosion");
            BloodParticule = content.Load<Texture2D>("blood");
            IA1 = content.Load<Texture2D>("pikachu");
            IA2 = content.Load<Texture2D>("pikachu_2");
            IA3 = content.Load<Texture2D>("Carabaffe_");
            IA4 = content.Load<Texture2D>("Spectrum");
            IA5 = content.Load<Texture2D>("Raichu");
            IA6 = content.Load<Texture2D>("Tortank");
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
            mRaichu2 = content.Load<SoundEffect>("raichuSon2");
            mHealthBox = content.Load<Texture2D>("health_box");
            mAmmoBox = content.Load<Texture2D>("ammo_box");
            mExplosiveBox = content.Load<Texture2D>("explosive_box");
            mBomb = content.Load<Texture2D>("bomb");
            mTitleScreen = content.Load<Texture2D>("Title");
            mGameOverScreen = content.Load<Texture2D>("GameOver");
            mWinSreen = content.Load<Texture2D>("WinScreen");
            mCross = content.Load<Texture2D>("cross");
            mRain = content.Load<Texture2D>("rain");
        }
    }
}
