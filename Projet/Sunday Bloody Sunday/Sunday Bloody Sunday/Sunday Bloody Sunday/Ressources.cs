using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sunday_Bloody_Sunday
{
    class Ressources
    {
        // STATICS FIELDS
        public static Texture2D Pikachu, map01;

        
        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {
            map01 = content.Load<Texture2D>("map01");
            Pikachu = content.Load<Texture2D>("pikachu");
        }
    }
}
