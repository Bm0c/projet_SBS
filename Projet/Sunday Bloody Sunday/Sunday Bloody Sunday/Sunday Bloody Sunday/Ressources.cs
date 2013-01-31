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
        public static Texture2D Player1, Player2, Player3, Map, Projectile, ExplosionParticule, IA1, IA2, mHealthBox, mAmmoBox, mExplosiveBox, mTitleScreen, mGameOverScreen;
        // HUD
        public static SpriteFont HUD;
        // Sounds
        public static Song GamePlayMusic, MenuMusic;
        public static SoundEffect mTire, mPika, mPika2, mIntroEffect, mLoseEffect, mExplosionEffect;


        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {
            Map = content.Load<Texture2D>("Map");
            Player1 = content.Load<Texture2D>("Chara");
            Player2 = content.Load<Texture2D>("Chara2");
            Player3 = content.Load<Texture2D>("Chara3");
            Projectile = content.Load<Texture2D>("balle");
            ExplosionParticule = content.Load<Texture2D>("explosion");
            IA1 = content.Load<Texture2D>("pikachu");
            IA2 = content.Load<Texture2D>("pikachu_2");
            HUD = content.Load<SpriteFont>("gameFont");
            GamePlayMusic = content.Load<Song>("gameplay_music");
            MenuMusic = content.Load<Song>("elevator_music");
            mIntroEffect = content.Load<SoundEffect>("zombie_groan");
            mLoseEffect = content.Load<SoundEffect>("lose_effect");
            mExplosionEffect = content.Load<SoundEffect>("explosion_effect");
            mTire = content.Load<SoundEffect>("tire");
            mPika = content.Load<SoundEffect>("pikachu001");
            mPika2 = content.Load<SoundEffect>("pikachu002");
            mHealthBox = content.Load<Texture2D>("health_box");
            mAmmoBox = content.Load<Texture2D>("ammo_box");
            mExplosiveBox = content.Load<Texture2D>("explosive_box");
            mTitleScreen = content.Load<Texture2D>("Title");
            mGameOverScreen = content.Load<Texture2D>("GameOver");
        }
    }
}
