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
    class Map
    {
        // FIELDS
        Rectangle MapTexture;
        public Player joueur;
        string action_a_traite = "";
        PhysicsEngine map_physique;


        // CONSTRUCTOR
        public Map(Player j1, PhysicsEngine map_physique)
        {
            MapTexture = new Rectangle(0, 0, 800, 480);
            joueur = j1;
            this.map_physique = map_physique;
        }


        // METHODS
        // Get the width of the map
        public int Width
        {
            get { return MapTexture.Width; }
        }

        // Get the height of the map
        public int Height
        {
            get { return MapTexture.Height; }
        }

        

        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            this.joueur.Update( mouse, keyboard);

            if (!(map_physique.mur(this.joueur.futur_position_X(),this.joueur.futur_position_Y())))
            {
                this.action_a_traite = this.joueur.actionjoueur;
                this.joueur.mise_a_jour(action_a_traite);
            }
            this.joueur.actionjoueur = "";

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.Map, this.MapTexture, Color.CadetBlue);
        }
    }
}
