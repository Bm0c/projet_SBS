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
    class DestructibleItems
    {
        //FIELDS
        //EXPLOSIVEBOX
        public Rectangle ExplosiveBoxTexture;
        public Rectangle Aire_explosiveBox;
        public bool isVisible;
        public bool Used;
        private string type;


        //CONSTRUCTOR
        public DestructibleItems(int x, int y, string type)
        {
            this.isVisible = true;
            this.Used = false;
            this.ExplosiveBoxTexture = new Rectangle(x, y, 16, 16);
            this.Aire_explosiveBox = new Rectangle(ExplosiveBoxTexture.X, ExplosiveBoxTexture.Y, ExplosiveBoxTexture.Width, ExplosiveBoxTexture.Height);
            this.type = type;
        }


        //METHODS


        //UPDATE & DRAW
        public void Update(List<Player> joueurs)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (type)
            {
                case ("explosion"):
                    spriteBatch.Draw(Ressources.mExplosiveBox, ExplosiveBoxTexture, Color.White);
                    break;
                default:
                    break;
            }
        }
    }
}
