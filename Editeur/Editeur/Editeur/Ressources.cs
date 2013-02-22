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

namespace Editeur
{
    class Ressources
    {
        public static Texture2D map;

        public static void LoadContent(ContentManager Content)
        {
            map = Content.Load<Texture2D>("Map");
        }
    }
}
