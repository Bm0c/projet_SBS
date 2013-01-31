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
            private string type;

        // CONSTRUCTOR
        public Items(int x, int y, string type)
        {
            this.HealthBoxTexture = new Rectangle(x, y, 16, 16);
            this.isVisible = true;
            this.Used = false;
            this.healPoints = 10;
            this.AmmoBoxTexture = new Rectangle(x, y, 16, 16);
            this.ammoNumber = 10;
            this.Aire_heal = new Rectangle(HealthBoxTexture.X, HealthBoxTexture.Y, HealthBoxTexture.Width, HealthBoxTexture.Height);
            this.Aire_ammo = new Rectangle(AmmoBoxTexture.X, AmmoBoxTexture.Y, AmmoBoxTexture.Width, AmmoBoxTexture.Height);
            this.type = type;

        }


        // METHODS

        private void utilisation(Player joueur)
        {
            if (type == "health")
            {
                joueur.Health = joueur.Health + this.healPoints;
            }
            else if (type == "ammo")
            {
                joueur.Ammo = joueur.Ammo + this.ammoNumber;
            }
            else
            {
            }
        }

        // UPDATE & DRAW
        public void Update(List<Player> joueurs)
        {
            foreach (Player joueur in joueurs)
            {
                if ((joueur.PlayerTexture.Intersects(this.HealthBoxTexture)) && isVisible)
                {
                    utilisation(joueur);
                    isVisible = false;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (type)
            {
                case ("health"):
                    spriteBatch.Draw(Ressources.mHealthBox, HealthBoxTexture, Color.White);
                    break;
                case ("ammo"):
                    spriteBatch.Draw(Ressources.mAmmoBox, AmmoBoxTexture, Color.White);
                    break;/*
                case ("explosion"):
                    spriteBatch.Draw(Ressources.mExplosiveBox, ExplosiveBoxTexture, Color.White);
                    break;*/
                default:
                    break;
            }

        }
    }
}
