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
using System.IO;

namespace Sunday_Bloody_Sunday
{
    public class PhysicsEngine
    {
        // Tableau des booléens, le 100*100 est purement arbitraire, il devrait correspondre à la longueure/largeure de la map
        private bool[,] liste = new bool[100, 100];

        public PhysicsEngine()
        {
            // liste[x,y]


            {   // Début de travail sur le lecteur de fichier, don't toutch !

                StreamReader monStreamReader = new StreamReader(("C:/Users/Alexis/SBS/Projet/Maps/map.txt"));
                string ligne = monStreamReader.ReadLine();

                int i = 0;
                while (ligne != null)
                { // Début de travaille sur le lecteur de fichier, don't toutch !
                    int i1 = 0;
                    foreach ( char bool_ in ligne)                                          
                    {
                        if (ligne[i1] == '0') // la zone est franchissable
                        {
                            liste[i1, i] = false;
                        }
                        else // la zone est infranchissable
                        {
                            liste[i1, i] = true;
                        }

                        i1++;
                    }
                    ligne = monStreamReader.ReadLine();
                    i++;
                }
                // Fermeture du StreamReader (attention très important) 
                monStreamReader.Close();
            }
        }

        // Teste si la zone est franchissable (false) ou infranchissable (true) à l'aide du tableau de bool, si x <= 0 ou y <= 0, on est hors de la map
        public bool mur(int x, int y)
        {
            if ((x <= 0) || (y <= 0)||(x >= 800) ||(y >=480))
                return true;
            else
                return this.liste[x / 16, y / 16]; 
        }
    }
}
