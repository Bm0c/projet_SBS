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
    public class PhysicsEngine
    {
        //Tableau des booléens, le 100*100 est purement arbitraire, il devrait corréspondre a la longueure/largeure de la map
        private bool[,] liste = new bool [100,100];

        public PhysicsEngine()
        {
            //Test pour la coordonnée (0,0)
            liste[0, 0] = true;

        }

        //Teste si la zone est franchissble (false) ou infranchissable (true) à l'aide du tableau de bool, si x <= 0 ou y <= 0, on est hors de la map
        public bool mur(int x, int y)
        {
           
            if ((x <= 0 ) || (y <= 0))
                return true;
            else
                return this.liste[x / 32, y / 32]; ;

        }

        

    }
}
