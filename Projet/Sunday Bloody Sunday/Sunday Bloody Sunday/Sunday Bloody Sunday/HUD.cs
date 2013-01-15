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
    class HUD
    {
        // FIELDS
        int health;
        int munition = 0;


        // CONSTRUCTOR
        public HUD()
        {
            this.health = Player.Health;
        }


        // METHODS


        // UPDATE & DRAW
        public void Update(KeyboardState keyboard, List<Player> joueurs)
        {
            this.munition = 0;

            foreach (Player joueur in joueurs)
            {
                if (joueur.Ammo <=0)
                {
                    joueur.Ammo = 100;
                }
                this.munition = this.munition + joueur.Ammo;
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(Ressources.HUD, "Health: " + Player.Health, new Vector2(650, 400), Color.White);
            spriteBatch.DrawString(Ressources.HUD, "Ammo: " + munition, new Vector2(650, 440), Color.White);
        }
    }
}
