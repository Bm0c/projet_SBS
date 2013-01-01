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
    public enum Aim
    {
        Up, Down, Left, Right
    };

    class Projectile
    {
        // FIELDS
        public Vector2 ProjectilePosition;
        public Vector2 Velocity;
        public Vector2 ProjectileOrigin;
        public bool isVisible;
        // The amount of damage the Projectile can inflict to an enemy
        public int Damage;
        // Direction of the Shot
        Aim viewport;
        // Speed of the Projectile
        int projectileMoveSpeed;


        // CONSTRUCTOR
        public Projectile(Texture2D newTexture)
        {
            Ressources.Projectile = newTexture;
            this.ProjectilePosition = new Vector2(Player.PlayerPosition.X, Player.PlayerPosition.Y);
            this.viewport = Aim.Right;
            this.Damage = 10;
            this.projectileMoveSpeed = 20;
            isVisible = false;
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


        // UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    this.viewport = Aim.Up;
                }

                else if (keyboard.IsKeyDown(Keys.Down))
                {
                    this.viewport = Aim.Down;
                }

                else if (keyboard.IsKeyDown(Keys.Right))
                {
                    this.viewport = Aim.Right;
                }

                else if (keyboard.IsKeyDown(Keys.Left))
                {
                    this.viewport = Aim.Left;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.viewport == Aim.Left || this.viewport == Aim.Right)
            {
                spriteBatch.Draw(Ressources.Projectile, ProjectilePosition, null, Color.White, 0f, ProjectileOrigin, 1f, SpriteEffects.None, 0);
            }
            else if (this.viewport == Aim.Up || this.viewport == Aim.Down)
            {
                spriteBatch.Draw(Ressources.Projectile, ProjectilePosition, null, Color.White, 90.0f, ProjectileOrigin, 1f, SpriteEffects.None, 0);
            }
        }
    }
}
