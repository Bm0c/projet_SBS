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
    class LecteurMap
    {
        public static void lecture()
        {
            StreamReader lecutre = new StreamReader("Content/maps/map.txt");
            string ligne = monStreamReader.ReadLine();

            int i = 0;
            while (ligne != null)
            { // Début de travaille sur le lecteur de fichier, don't toutch !
                int i1 = 0;
                foreach (char bool_ in ligne)
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
}
