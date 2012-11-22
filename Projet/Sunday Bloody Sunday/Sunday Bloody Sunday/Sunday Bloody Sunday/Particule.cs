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
    class Particule
    {
        // FIELDS
        Rectangle ExplosionTexture;

        // CONSTRUCTOR
        public Particule()
        {
            
        }

        // METHODS
        // Get the width of the projectile ship
        public int Width
        {
            get { return ExplosionTexture.Width; }
        }
        // Get the height of the projectile ship
        public int Height
        {
            get { return ExplosionTexture.Height; }
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
