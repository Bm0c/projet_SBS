using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sunday_Bloody_Sunday
{
    class Map
    {
        // FIELDS
        Rectangle terrain;

        // CONSTRUCTOR
        public Map()
        {
            terrain = new Rectangle(0, 0, 800, 480);
        }

        // METHODS
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.map01, this.terrain, Color.White);
        }
    }
}
