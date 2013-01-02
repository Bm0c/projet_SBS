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
        //ExplosionParticule MainExplosionParticule;
        HUD MainHUD;
            // FIELDS Projectile
            Projectile MainProjectile;
            List<Projectile> projectiles = new List<Projectile>();
            public Vector2 spritePosition = new Vector2(Player.PlayerPosition.X, Player.PlayerPosition.Y); // Must attach the fireball to the Player !
            float rotation;
            Vector2 spriteVelocity;


        // CONCSTRUCTOR
        public GameMain()
        {
            this.MainMap = new Map(new Player(), new PhysicsEngine());
            this.MainProjectile = new Projectile(Ressources.Projectile);
            //this.MainExplosionParticule = new ExplosionParticule();
            this.MainHUD = new HUD();
        }


        // METHODS


        // UPDATE & "Projectile" & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            MainMap.Update(mouse, keyboard);
            
            if(keyboard.IsKeyDown(Keys.S))
            {
                Shoot();
                Player.Ammo--;

                if (Player.Ammo < 0)
                {
                    Player.Ammo = 0;
                }
            }
            UpdateProjectile();
        }

        public void UpdateProjectile()
        {
            foreach (Projectile projectile in projectiles)
            {
                projectile.ProjectilePosition += projectile.Velocity;
                if(Vector2.Distance(projectile.ProjectilePosition, spritePosition) > 800)
                {
                    projectile.isVisible = false;
                }
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (!projectiles[i].isVisible)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot()
        {
            MainProjectile.Velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * 5f + spriteVelocity;
            MainProjectile.ProjectilePosition = spritePosition + MainProjectile.Velocity / 5;
            MainProjectile.isVisible = true;

            if (projectiles.Count() < 20)
            {
                projectiles.Add(MainProjectile);
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            MainMap.Draw(spriteBatch);
                foreach (Projectile projectile in projectiles)
                {
                    projectile.Draw(spriteBatch);
                }
            //MainExplosionParticule.Draw(spriteBatch);
            MainHUD.Draw(spriteBatch, spriteFont);
        }
    }
}
