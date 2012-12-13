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
        int health, munition;


        // CONSTRUCTOR
        public HUD()
        {
            this.health = Player.Health;
            this.munition = Player.Ammo;
        }


        // METHODS


        // UPDATE & DRAW
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(Ressources.HUD, "Health: " + Player.Health, new Vector2(650, 400), Color.White);
            spriteBatch.DrawString(Ressources.HUD, "Ammo: " + Player.Ammo, new Vector2(650, 440), Color.White);
        }
    }
}
