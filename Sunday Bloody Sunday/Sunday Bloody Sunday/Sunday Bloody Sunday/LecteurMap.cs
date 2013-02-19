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
        static bool[,] liste;
        static List<Spawn> liste_spawn;
        static List<DestructibleItems> liste_barrel;
        static Spawn_Items liste_caisses;

        public static void lecture()
        {
            StreamReader lecture = new StreamReader("Content/maps/map.txt");
            string ligne = lecture.ReadLine();
            while (ligne != null)
            {
                if (ligne == "physique")
                {
                    lecture_physique(lecture);
                }
                else if (ligne == "spawn")
                {
                    lecture_spawn(lecture);
                }
                else if (ligne == "caisses")
                {
                    lecture_caisses(lecture);
                }
                else if (ligne == "barrels")
                {
                    lecture_barrel(lecture);
                }
                ligne = lecture.ReadLine();
            }
            lecture.Close();
        }

        public static void lecture_physique(StreamReader lecture)
        {

            string ligne = lecture.ReadLine();
            int largeur = System.Convert.ToInt32(ligne);
            ligne = lecture.ReadLine();
            int hauteur = System.Convert.ToInt32(ligne);
            liste = new bool[largeur, hauteur];
            ligne = lecture.ReadLine();
            int i = 0;
            while (ligne != null || ligne != "//")
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
                ligne = lecture.ReadLine();
                i++;
            }
        }

        public static void lecture_spawn(StreamReader lecture)
        {
            liste_spawn = new List<Spawn>();
            string ligne = lecture.ReadLine();
            while (ligne != null || ligne != "//")
            {

                List<IA> liste_ia = new List<IA>();
                while (ligne != "new")
                {
                    ligne = lecture.ReadLine();
                    int x = System.Convert.ToInt32(ligne);

                    ligne = lecture.ReadLine();
                    int y = System.Convert.ToInt32(ligne);

                    ligne = lecture.ReadLine();
                    int id_texture = System.Convert.ToInt32(ligne);

                    ligne = lecture.ReadLine();
                    int id_son = System.Convert.ToInt32(ligne);

                    ligne = lecture.ReadLine();
                    int pv_max = System.Convert.ToInt32(ligne);

                    ligne = lecture.ReadLine();
                    int dégats = System.Convert.ToInt32(ligne);

                    liste_ia.Add(new IA(x, y, id_texture, id_son, pv_max, dégats));

                    ligne = lecture.ReadLine();
                }

                liste_spawn.Add(new Spawn(liste_ia));

                ligne = lecture.ReadLine();


            }
        }

        public static void lecture_caisses(StreamReader lecture)
        {
            List<Vector2> liste_caisses_ = new List<Vector2>();
            string ligne = lecture.ReadLine();
            while (ligne != null || ligne != "//")
            {
                ligne = lecture.ReadLine();
                int x = System.Convert.ToInt32(ligne);

                ligne = lecture.ReadLine();
                int y = System.Convert.ToInt32(ligne);

                liste_caisses_.Add(new Vector2(x, y));

                ligne = lecture.ReadLine();
             }
            liste_caisses = new Spawn_Items(liste_caisses_);
        }

        public static void lecture_barrel(StreamReader lecture)
        {
            liste_barrel = new List<DestructibleItems>();
            string ligne = lecture.ReadLine();
            while (ligne != null || ligne != "//")
            {
                ligne = lecture.ReadLine();
                int x = System.Convert.ToInt32(ligne);

                ligne = lecture.ReadLine();
                int y = System.Convert.ToInt32(ligne);

                ligne = lecture.ReadLine();
                string type = ligne;

                liste_barrel.Add(new DestructibleItems(x,y,type));

                ligne = lecture.ReadLine();

            }
        }
    }
}
