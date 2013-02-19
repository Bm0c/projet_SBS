using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sunday_Bloody_Sunday
{
    class Lecture
    {
        public static void ecrire(char[,] tableau, int longueur, int largeur)
        {
            StreamWriter ecriture = new StreamWriter("map.txt");
            int y = 0;
            while (y < longueur)
            {
               
                string ligne = "";
                int x = 0;
                while (x < largeur)
                {
                    ligne = ligne + tableau[x, y];
                    x++;
                }
                ecriture.WriteLine(ligne);
                y++;
            }
            ecriture.Close();
        }
    }
}
