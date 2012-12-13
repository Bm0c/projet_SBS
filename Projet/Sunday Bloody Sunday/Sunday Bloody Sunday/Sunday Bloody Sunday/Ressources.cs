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
        public static Texture2D Player, Map, Projectile, ExplosionParticule, IA;
        public static SpriteFont HUD;
        public static Song GamePlayMusic;

        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {

            Projectile = content.Load<Texture2D>("laser");
            IA = content.Load<Texture2D>("zombie01");
            Map = content.Load<Texture2D>("Map");
            Player = content.Load<Texture2D>("Chara");
            IA = content.Load<Texture2D>("zombie01");
            ExplosionParticule = content.Load<Texture2D>("explosion");
            HUD = content.Load<SpriteFont>("gameFont");
            GamePlayMusic = content.Load<Song>("GamePlayMusic");
            
        }
    }
}
