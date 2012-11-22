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
    static class PhysicsEngine
    {
        static public bool IsHerosCollidingWall_UpDown(Player MainPlayer, List<Rectangle> listWall)
        {
            // detection des collisions vers le haut/bas
            return false; //TODO
        }

        static public bool IsHerosCollidingWall_RightLeft(Player MainPlayer, List<Rectangle> listWall)
        {
            // detection des collisions vers la gauche/droite
            return false; //TODO
        }
    }
}
