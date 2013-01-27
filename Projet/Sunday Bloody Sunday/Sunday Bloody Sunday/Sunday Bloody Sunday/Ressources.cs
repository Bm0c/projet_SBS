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
using System.IO;

namespace Sunday_Bloody_Sunday
{
    class Ressources
    {
        // STATICS FIELDS
        public static Texture2D Player1, Player2, Player3, Map, Projectile, /*ExplosionParticule,*/ IA1, IA2;
        // HUD
        public static SpriteFont HUD;
        // Sound
        public static Song GamePlayMusic, MenuMusic;
        public static SoundEffect mTire, mPika, mPika2, Effect;
        // GameTitle
        public static Texture2D mTitleScreen;


        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {
            Map = content.Load<Texture2D>("map");
            Player1 = content.Load<Texture2D>("Chara");
            Player2 = content.Load<Texture2D>("Chara2");
            Player3 = content.Load<Texture2D>("Chara3");
            Projectile = content.Load<Texture2D>("balle");
            IA1 = content.Load<Texture2D>("pikachu");
            IA2 = content.Load<Texture2D>("pikachu_2");
            HUD = content.Load<SpriteFont>("gameFont");
            mTitleScreen = content.Load<Texture2D>("Title");
            //ExplosionParticule = content.Load<Texture2D>("explosion");
            GamePlayMusic = content.Load<Song>("GamePlayMusic");
            MenuMusic = content.Load<Song>("elevator_music");
            Effect = content.Load<SoundEffect>("zombie_groan");
            mTire = content.Load<SoundEffect>("tire");
            mPika = content.Load<SoundEffect>("pikachu001");
            mPika2 = content.Load<SoundEffect>("pikachu002");
        }
    }
}
