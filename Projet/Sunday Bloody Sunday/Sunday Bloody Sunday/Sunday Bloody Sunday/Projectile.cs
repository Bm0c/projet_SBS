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
    public enum DirectionProjectile
    {
        Up, Down, Left, Right
    };

    class Projectile
    {
        // FIELDS
        public Vector2 ProjectilePosition;
        public bool isVisible;
        public int Damage;
        public int projectileMoveSpeed;
        public bool update;
        public int init;
        public string direction;
        public bool est_update = false;


        // CONSTRUCTOR
        public Projectile(Texture2D newTexture, int x, int y, int vitesse, Direction direction, int dommage)
        {
            Ressources.Projectile = newTexture;
            this.ProjectilePosition = new Vector2(x, y);
            this.Damage = dommage;
            this.projectileMoveSpeed = vitesse;
            isVisible = true;
            switch (direction)
            {
                case Direction.Up:
                    this.direction = "up";
                    break;
                case Direction.Down: 
                    this.direction = "down";
                    break;
                case Direction.Left:
                    this.direction = "left";
                    break;
                case Direction.Right:
                    this.direction = "right";
                    break;
            }
            this.update = true;
            this.init = 0;
        }


        // METHODS
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

        public void update_coordonne()
        {
            if (this.direction == "right")
            {
                ProjectilePosition.X++;
            }
            else if (this.direction == "left")
            {
                ProjectilePosition.X--;
            }
            if (this.direction == "up")
            {
                ProjectilePosition.Y--;
            }
            else if (this.direction == "down")
            {
                ProjectilePosition.Y++;
            }
        }

        //Renvois le futur rectangle du projectile
        public Rectangle rectangle()
        {
            return new Rectangle(futur_x(), futur_y(), 6, 6);
        }

        // UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.isVisible)
            {
                spriteBatch.Draw(Ressources.Projectile, ProjectilePosition/*, null*/, Color.White/*, 0f, ProjectileOrigin, 1f, SpriteEffects.None, 0*/);
            }
        }
    }
}
