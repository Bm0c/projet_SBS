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
    class Ressources
    {
        // STATICS FIELDS
        public static Texture2D Map, valide, invalide;


        // LOAD CONTENTS
        public static void LoadContent(ContentManager content)
        {
<<<<<<< HEAD:Editeur/Editeur/Editeur/Ressources.cs
            map = Content.Load<Texture2D>("Map");
=======
            Map = content.Load<Texture2D>("Map");
            valide = content.Load<Texture2D>("Valide");
            invalide = content.Load<Texture2D>("Invalide");
>>>>>>> c620117bbfdb0add1bcdb96468ae299095878939:Editeur/Sunday Bloody Sunday/Sunday Bloody Sunday/Sunday Bloody Sunday/Ressources.cs
        }
    }
}
