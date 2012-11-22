using System;
using Microsoft.Xna.Framework;

namespace Sunday_Bloody_Sunday
{
    static class Divers
    {   
        // Récupération des paramètres relatif à la fenêtre de jeu
        static private int widthScreen = 512;
        static private int heightScreen = 512;

        static public int WidthScreen
        { get { return widthScreen; } }

        static public int HeightScreen
        { get { return heightScreen; } }

        static public Vector2 HerosSquareOne = new Vector2(0, 0);
    }
}