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
    class Menu
    {
        public enum MenuType
        {
            MainMenu, InGameMenu, MenuOptions, MenuSettings
        };


        //FIELDS
        MenuType type;
        MenuButton button_1;
        MenuButton button_2;
        MenuButton button_3;
        MenuButton button_4;
        MenuButton button_5;
        MenuButton button_6;


        //CONSTRUCTOR
        public Menu(MenuType type)
        {
            this.type = type;

            switch (type)
            {
                case MenuType.MainMenu:
                    button_1 = new MenuButton(MenuButton.ButtonType.Play, new Rectangle(50, 150, 100, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.Option, new Rectangle(50, 250, 100, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Quit, new Rectangle(50, 350, 100, 50));
                    break;

                case MenuType.InGameMenu:
                    button_1 = new MenuButton(MenuButton.ButtonType.Resume, new Rectangle(Divers.WidthScreen / 2 - 50, 100, 100, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.Option, new Rectangle(Divers.WidthScreen / 2 - 50, 200, 100, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, 300, 100, 50));
                    break;

                case MenuType.MenuOptions:
                    button_1 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 100, 50, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 100, 50, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 200, 50, 50));
                    button_4 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 200, 50, 50));
                    button_5 = new MenuButton(MenuButton.ButtonType.Mute, new Rectangle(Divers.WidthScreen / 2 + 200, 200, 100, 50));
                    button_6 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, 300, 100, 50));
                    break;

                case MenuType.MenuSettings:
                    button_1 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 100, 50, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 100, 50, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 200, 50, 50));
                    button_4 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 200, 50, 50));
                    button_5 = new MenuButton(MenuButton.ButtonType.Mute, new Rectangle(Divers.WidthScreen / 2 + 200, 200, 100, 50));
                    button_6 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, 300, 100, 50));
                    break;

                default:
                    break;
            }
        }


        // UPDATE & DRAW
        public int Update(MouseState mouse, KeyboardState keyboard)
        {
            bool b1 = button_1.Update(mouse);
            bool b2 = button_2.Update(mouse);
            bool b3 = button_3.Update(mouse);
            bool b4 = false;
            bool b5 = false;
            bool b6 = false;

            if (button_4 != null)
                b4 = button_4.Update(mouse);
            if (button_5 != null)
                b5 = button_5.Update(mouse);
            if (button_6 != null)
                b6 = button_6.Update(mouse);

            if (b1)
                return 1;
            if (b2)
                return 2;
            if (b3)
                return 3;
            if (b4)
                return 4;
            if (b5)
                return 5;
            if (b6)
                return 6;
            else
                return 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            button_1.DrawButton(spriteBatch);
            button_2.DrawButton(spriteBatch);
            button_3.DrawButton(spriteBatch);

            if (button_4 != null)
                button_4.DrawButton(spriteBatch);
            if (button_5 != null)
                button_5.DrawButton(spriteBatch);
            if (button_6 != null)
                button_6.DrawButton(spriteBatch);

            if (type == MenuType.MenuSettings)
            {
                string langue;
                string son;
                if (MenuButton.langage == "French")
                {
                    langue = "Langue";
                    son = "Musique";
                }
                else
                {
                    langue = "Language";
                    son = "Music";
                }
                spriteBatch.DrawString(Ressources.HUD, langue, new Vector2(Divers.WidthScreen / 2 - 350, 80), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
                spriteBatch.DrawString(Ressources.HUD, son, new Vector2(Divers.WidthScreen / 2 - 350, 180), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString((int)(MediaPlayer.Volume * 10) * 10), new Vector2(Divers.WidthScreen / 2 - 20, 180), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            }
            if (type == MenuType.MenuOptions)
            {
                string langue;
                string son;
                if (MenuButton.langage == "French")
                {
                    langue = "Langue";
                    son = "Musique";
                }
                else
                {
                    langue = "Language";
                    son = "Music";
                }
                spriteBatch.DrawString(Ressources.HUD, langue, new Vector2(Divers.WidthScreen / 2 - 350, 80), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
                spriteBatch.DrawString(Ressources.HUD, son, new Vector2(Divers.WidthScreen/2 - 350, 180), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString((int)(MediaPlayer.Volume * 10) * 10), new Vector2(Divers.WidthScreen / 2 - 20, 180), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            }
        }
    }
}
