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
using System.Math;

namespace Sunday_Bloody_Sunday
{
    class Pathfinding
    {
        private List<Node> liste_ouverte; //Liste des éléments potentiellement utiles
        private List<Node> liste_fermée;  //Liste des éléments traités
        private bool[,] map;
        private int x1, y1, x2, y2;

        public Pathfinding(bool[,] map, int x_départ, int y_départ, int x_arrivée, int y_arrivée)
        {
            liste_ouverte = new List<Node>();
            liste_fermée = new List<Node>();
            this.map = map;
            x1 = x_départ;
            y1 = y_départ;
            x2 = x_arrivée;
            y2 = y_arrivée;
        }

        public string direction()
        {
            List<Node>liste_ouverte_copie;
            Node Current;
            //Ajout de la première Node, le point de départ
            liste_ouverte.Add(new Node(0, (int)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)), (int)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)), x1, x2));
            while (true)
            {
                Current = liste_ouverte.First();
                foreach (Node point in liste_ouverte) //Récupération du plus grand "poids"
                {
                    if (point.F < Current.F)
                    {
                        Current = point;
                    }
                }

                liste_ouverte_copie = new List<Node>();
                foreach (Node point in liste_ouverte) //On vire la Current de la liste ouverte
                {
                    if (!(point == Current))
                    {
                        liste_ouverte_copie.Add(point);
                    }
                }
                liste_ouverte = liste_ouverte_copie;

                liste_fermée.Add(Current);

            }
            return "";
        }
    }

    class Node
    {
        public int G, H, F, x, y; //Distance liée au point de départ, Distance du point d'arrivée, Somme des distances, coordonnées du parent

        public Node(int g, int h, int f, int x, int y)
        {
            G = g;
            H = h;
            F = f;
            this.x = x;
            this.y = y;
        }
    }
}
