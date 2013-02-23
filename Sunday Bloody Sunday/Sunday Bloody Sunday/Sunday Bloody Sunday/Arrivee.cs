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
    class Arrivee
    {
        //FIELDS
        public Rectangle ArriveeTexture;
        public bool gagne = false;


        //CONSTRUCTOR
        public Arrivee(int x, int y)
        {
            this.ArriveeTexture = new Rectangle(x, y, 20, 20);
        }


        //METHODS


        //UPDATE & DRAW
        public void Update(List<Player> liste_joueurs)
        {
            foreach (Player joueur in liste_joueurs)
            {
                if (joueur.PlayerTexture.Intersects(ArriveeTexture))
                {
                    gagne = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.mCross, this.ArriveeTexture, Color.White);
        }
    }
}
