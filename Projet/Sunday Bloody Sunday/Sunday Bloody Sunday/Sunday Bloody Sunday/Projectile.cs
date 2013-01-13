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
    class Projectile
    {
        // FIELDS
        public Vector2 ProjectilePosition;
        public Vector2 ProjectileOrigin;
        public bool isVisible;
        public int Damage;
        int projectileMoveSpeed;
        string direction;
        public bool update;


        // CONSTRUCTOR
        public Projectile(Texture2D newTexture, int x, int y, int vitesse, string direction, int dommage)
        {
            Ressources.Projectile = newTexture;
            this.ProjectilePosition = new Vector2(x, y);
            this.Damage = dommage;
            this.projectileMoveSpeed = vitesse;
            isVisible = false;
            this.direction = direction;
            this.update = true;
        }


        // METHODS (useful for collision)
        // Get the width of the projectile
        public int Width
        {
            get { return Ressources.Projectile.Width; }
        }
        // Get the height of the projectile
        public int Height
        {
            get { return Ressources.Projectile.Height; }
        }

        public int futur_x()
        {
            if (this.direction == "right")
            {
                return (int)ProjectilePosition.X - 1;
            }
            else if (this.direction == "left")
            {
                return (int)ProjectilePosition.X + 1;
            }
            else
            {
                return (int)ProjectilePosition.X;
            }
            
        }

        public int futur_y()
        {
            if (this.direction == "up")
            {
                return (int)ProjectilePosition.Y - 1;
            }
            else if (this.direction == "down")
            {
                return (int)ProjectilePosition.Y + 1;
            }
            else
            {
                return (int)ProjectilePosition.Y;
            }

        }

        // UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {/*
            if (this.viewport == Aim.Left || this.viewport == Aim.Right)
            {
                spriteBatch.Draw(Ressources.Projectile, ProjectilePosition, null, Color.White, 0f, ProjectileOrigin, 1f, SpriteEffects.None, 0);
            }
            else if (this.viewport == Aim.Up || this.viewport == Aim.Down)
            {
                spriteBatch.Draw(Ressources.Projectile, ProjectilePosition, null, Color.White, 90.0f, ProjectileOrigin, 1f, SpriteEffects.None, 0);
            }
          * */
        }
    }
}
