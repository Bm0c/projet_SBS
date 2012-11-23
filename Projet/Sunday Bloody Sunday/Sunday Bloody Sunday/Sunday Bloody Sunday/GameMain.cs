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
        Player MainPlayer;
        Map MainMap;
        Projectile MainProjectile;
        Particule MainParticule;

        // CONCSTRUCTOR
        public GameMain()
        {
            this.MainMap = new Map(new Player(), new PhysicsEngine());
            this.MainProjectile = new Projectile();
            this.MainParticule = new Particule();
        }

        // METHODS


        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            MainMap.Update(mouse, keyboard);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MainMap.Draw(spriteBatch);
            MainProjectile.Draw(spriteBatch);
            MainParticule.Draw(spriteBatch);
            MainMap.joueur.Draw(spriteBatch);
        }
    }
}
