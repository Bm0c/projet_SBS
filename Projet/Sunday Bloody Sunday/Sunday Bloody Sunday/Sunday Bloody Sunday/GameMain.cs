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
    class GameMain
    {
        // FIELDS
        Map MainMap;
        Projectile MainProjectile;
        ExplosionParticule MainExplosionParticule;
        IA MainIA;
        HUD MainHUD;
        Sound MainSound;


        // CONCSTRUCTOR
        public GameMain()
        {
            this.MainMap = new Map(new Player(), new PhysicsEngine());
            this.MainProjectile = new Projectile();
            this.MainExplosionParticule = new ExplosionParticule();
            this.MainIA = new IA();
            this.MainHUD = new HUD();
            this.MainSound = new Sound();
        }


        // METHODS


        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            MainMap.Update(mouse, keyboard);
            MainProjectile.Update(keyboard);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            MainMap.Draw(spriteBatch);
            MainProjectile.Draw(spriteBatch);
            MainExplosionParticule.Draw(spriteBatch);
            MainIA.Draw(spriteBatch);
            MainHUD.Draw(spriteBatch, spriteFont);
        }
    }
}
