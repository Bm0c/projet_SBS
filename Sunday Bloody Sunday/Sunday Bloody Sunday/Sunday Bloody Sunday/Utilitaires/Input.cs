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
    class Input
    {
        public string input = "";

        public Input()
        {
            input = "";
        }

        public void KeysToChar(Keys key, bool Shift, ref char c)
        {
            string keyString = key.ToString();
            if (keyString.Length == 1)
            {
                c = keyString[0];

                if (!Shift)
                    c += (char)('a' - 'A');
            }
            else
            {
                if (keyString == "Space")
                    c = ' ';
                else if (keyString == "Back")
                {
                    string buffer = "";
                    int i = 0;
                    while (i < input.Length - 1)
                    {
                        buffer += input[i];
                        i++;
                    }
                    input = buffer;
                }
                else if (keyString.Length == 1 && keyString[0] == 'D')
                    c = keyString[1];
                else if (keyString == "Decimal")
                {
                    c = '.';
                }
                else if (keyString.Length == 7 && keyString.Remove(6) == "NumPad")
                    c = keyString[6];

            }
        }

        public void Update(KeyboardState actuelle, KeyboardState ancien)
        {
            Keys[] clavier = actuelle.GetPressedKeys();
            foreach (Keys touche in clavier)
            {
                if (ancien.IsKeyUp(touche))
                {
                    char c = '&';
                    int lenght = input.Length;
                    KeysToChar(touche, actuelle.IsKeyDown(Keys.LeftShift) || actuelle.IsKeyDown(Keys.RightShift), ref c);
                    if (lenght == input.Length && c != '&')
                        input += c;
                }
            }
        }

        public void DrawButton(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Ressources.HUD, input, new Vector2(0, 0), Color.LightGray);
        }
    }
}
