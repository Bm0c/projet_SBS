using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sunday_Bloody_Sunday
{
    class Projectile
    {
        // FIELDS
        Rectangle ProjectileTexture;
        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;
        // State of the Projectile
        public bool Active;
        // The amount of damage the projectile can inflict to an enemy
        public int Damage;
        // Represents the viewable boundary of the game
        Viewport viewport;
        // Determines how fast the projectile moves
        float projectileMoveSpeed;


        // CONSTRUCTOR        
        public Projectile()
        {
            
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
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
