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
    class Pathfinding
    {
        private static List<Node> liste_ouverte;
        private static List<Node> liste_fermée;

        public static string pathfind(bool[,] map, Node départ, Node arrivee)
        {
            liste_ouverte = new List<Node>();
            liste_fermée  = new List<Node>();

            //TO FIX

            return "";
        }

        private static void suppr_liste_fermée(Node node)
        {
            liste_fermée.Remove(node);
        }

        private static void suppr_liste_ouverte(Node node)
        {
            liste_ouverte.Remove(node);
        }

        private static void passage_liste_fermée(Node node)
        {
            suppr_liste_ouverte(node);
            liste_fermée.Add(node);
        }

        private static void passage_liste_ouverte(Node node)
        {
            suppr_liste_fermée(node);
            liste_ouverte.Add(node);
        }

        private static Node getCurrent()
        {
            Node current = liste_ouverte.First();
            foreach (Node node in liste_ouverte)
            {
                if (current.F > node.F)
                {
                    current = node;
                }
            }

            return current;
        }

        //TO FIX
        private static List<Node> getVoisins(Node current, bool[,] map)
        {
            List<Node> voisin = new List<Node>();
            int x_sup = current.x + 1;
            int x_inf = current.x - 1;
            int y_sup = current.y + 1;
            int y_inf = current.y - 1;
            return voisin;
        }
    }

    class Node
    {
        public int G, H, F, x, y; //Distance liée au point de départ, Distance du point d'arrivée, Somme des distances, coordonnées de la node
        public bool traversable;
        public Node parent;

        public Node()
        {
            traversable = true;
            parent = this;
            G = 0;
            H = 0;
            F = 0;
        }
    }
}
