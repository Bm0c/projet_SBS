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
    class Items
    {
        // FIELDS
            //HEALTHBOX
            public Rectangle HealthBoxTexture;
            public bool isVisible;
            public bool Used;
            public int healPoints;
            public Rectangle Aire_heal;
            //AMMOBOX
            public Rectangle AmmoBoxTexture;
            public int ammoNumber;
            public Rectangle Aire_ammo;


        // CONSTRUCTOR
        public Items(int x, int y)
        {
            this.HealthBoxTexture = new Rectangle(x, y, 16, 16);
            this.isVisible = true;
            this.Used = false;
            this.healPoints = 10;
            this.AmmoBoxTexture = new Rectangle(x, y, 16, 16);
            this.ammoNumber = 10;
            this.Aire_heal = new Rectangle(HealthBoxTexture.X, HealthBoxTexture.Y, HealthBoxTexture.Width, HealthBoxTexture.Height);
            this.Aire_ammo = new Rectangle(AmmoBoxTexture.X, AmmoBoxTexture.Y, AmmoBoxTexture.Width, AmmoBoxTexture.Height);
        }


        // METHODS


        // UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.mHealthBox, HealthBoxTexture, Color.White);
            spriteBatch.Draw(Ressources.mAmmoBox, AmmoBoxTexture, Color.White);
        }
    }
}
