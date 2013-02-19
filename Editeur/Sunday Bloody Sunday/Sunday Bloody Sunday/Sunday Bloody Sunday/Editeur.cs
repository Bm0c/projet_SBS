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
    class Editeur
    {
        Texture2D map;
        Texture2D valide;
        Texture2D invalide;
        Char[,] tableau;
        int largeur;
        int longueur;
        //On suppose les tiles en 16*16
        public  Editeur(Texture2D map, Texture2D valide, Texture2D invalide, int largeur, int longueur)
        {
            this.map = map;
            this.tableau = new char[longueur, largeur];
            int x = 0;
            this.largeur = largeur;
            this.longueur = longueur;
            while (x < longueur)
            {
                int y = 0;
                while (y < largeur)
                {
                    tableau[x, y] = '2';
                    y++;
                }
                x++;
            }
            this.valide = valide;
            this.invalide = invalide;
        }

        public void Update(MouseState souris,KeyboardState clavier)
        {
            if (souris.LeftButton == ButtonState.Pressed)
            {
                try
                {
                    tableau[souris.X / 16, souris.Y / 16] = '0';
                }
                catch
                {
                }
            }
            else if (souris.RightButton == ButtonState.Pressed)
            {
                try
                {
                    tableau[souris.X / 16, souris.Y / 16] = '1';
                }
                catch
                {
                }
            }
            if (clavier.IsKeyDown(Keys.Enter))
            {
                Lecture.ecrire(tableau, largeur, longueur);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(map, new Vector2(0, 0), Color.White);

            int x = 0;
            while (x < longueur)
            {
                int y = 0;
                while (y < largeur)
                {
                    if (tableau[x, y] == '0')
                    {
                        spriteBatch.Draw(valide, new Vector2(x*16, y*16), Color.White);
                    }
                    else if (tableau[x, y] == '1')
                    {
                        spriteBatch.Draw(invalide, new Vector2(x * 16, y * 16), Color.White);
                    }
                    y++;
                }
                x++;
            }
        }
    }
}
