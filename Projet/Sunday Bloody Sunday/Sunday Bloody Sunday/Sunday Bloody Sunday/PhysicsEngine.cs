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

        private bool[,] liste = new bool [100,100];

        public PhysicsEngine()
        {

            liste[0, 0] = true;

        }

        public bool mur(int x, int y)
        {

            if ((x <= 0 ) || (y <= 0))
                return true;
            else
                return this.liste[x / 32, y / 32]; ;

        }
        public bool[,] liste_bool
        {
            get { return this.liste; }
        }

    }
}
