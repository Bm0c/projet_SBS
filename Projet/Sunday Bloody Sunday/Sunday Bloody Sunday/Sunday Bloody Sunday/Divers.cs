using System;
using Microsoft.Xna.Framework;

namespace Sunday_Bloody_Sunday
{
    static class Divers
    {
        // Récupération des paramètres relatifs à la fenêtre de jeu
        static private int widthScreen = 800;
        static private int heightScreen = 480;

        static public int WidthScreen
        { get { return widthScreen; } }

        static public int HeightScreen
        { get { return heightScreen; } }
    }
}
