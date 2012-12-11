using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sunday_Bloody_Sunday
{
    public enum Aim
    {
        Up, Down, Left, Right
    };

    class Projectile
    {
        // FIELDS
        Rectangle ProjectileTexture;
        // State of the Projectile
        public bool Active;
        // Relative Position
        Vector2 ProjectilePosition;
        // The amount of damage the projectile can inflict to an enemy
        public int Damage;
        // Direction of the shot
        Aim viewport;
        // Speed of the Projectile
        int projectileMoveSpeed;
        // Orientation of the Projectile
        float rotation = 90.0f;


        // CONSTRUCTOR        
        public Projectile()
        {
            ProjectileTexture = new Rectangle(450, 200, 46, 16);
            ProjectilePosition = new Vector2(ProjectileTexture.X, ProjectileTexture.Y);
            this.viewport = Aim.Left;
            Active = false;
            Damage = 2;
            projectileMoveSpeed = 20;
        }

        // METHODS
        // Get the width of the projectile ship
        public int Width
        {
            get { return ProjectileTexture.Width; }
        }
        // Get the height of the projectile ship
        public int Height
        {
            get { return ProjectileTexture.Height; }
        }


        // UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    this.viewport = Aim.Up;



                    Active = true;
                    // Projectile move Up
                    ProjectileTexture.Y -= projectileMoveSpeed;
                    // Deactivate the bullet if it goes out of screen
                    // ...

                }

                else if (keyboard.IsKeyDown(Keys.Down))
                {
                    this.viewport = Aim.Down;


                    Active = true;
                    // Projectile move Down
                    ProjectileTexture.Y += projectileMoveSpeed;
                    // Deactivate the bullet if it goes out of screen
                    // ...

                }

                else if (keyboard.IsKeyDown(Keys.Right))
                {
                    this.viewport = Aim.Right;



                    Active = true;
                    // Projectile move to the Right
                    ProjectileTexture.X += projectileMoveSpeed;
                    // Deactivate the bullet if it goes out of screen
                    // ...

                }

                else if (keyboard.IsKeyDown(Keys.Left))
                {
                    this.viewport = Aim.Left;


                    Active = true;
                    // Projectile move to the Left
                    ProjectileTexture.X -= projectileMoveSpeed;
                    // Deactivate the bullet if it goes out of screen
                    // ...

                }
            }
            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right))
            {
                Active = false;
                // Projectile is not visible !
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.viewport == Aim.Left || this.viewport == Aim.Right)
            {
                spriteBatch.Draw(Ressources.Projectile, this.ProjectileTexture, Color.White);
            }

            else if (this.viewport == Aim.Up || this.viewport == Aim.Down)
            {
                spriteBatch.Draw(Ressources.Projectile,                      // Texture (Image)
                                 this.ProjectilePosition,                    // Position de l'image
                                 null,                                       // Zone de l'image à afficher
                                 Color.White,                                // Teinte
                                 MathHelper.ToRadians(rotation),             // Rotation (en rad)
                                 new Vector2(ProjectileTexture.Width / 2, ProjectileTexture.Height / 2),  // Origine
                                 1.0f,                                       // Echelle
                                 SpriteEffects.None,                         // Effet
                                 0);                                         // Profondeur
            }
        }
    }
}
