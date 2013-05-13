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
            MainMenu, PauseMenu, MenuPreferences, MenuGeneralSettings, GameOver, MapSelector, WinScreen, Credits, MultiOrNot, Deconnexion
        };


        //FIELDS
        MenuType type;
        MenuButton button_1;
        MenuButton button_2;
        MenuButton button_3;
        MenuButton button_4;
        MenuButton button_5;
        MenuButton button_6;
        MenuButton button_7;
        MenuButton button_8;
        MenuButton button_9;


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

                case MenuType.PauseMenu:
                    button_1 = new MenuButton(MenuButton.ButtonType.Resume, new Rectangle(Divers.WidthScreen / 2 - 50, 100, 100, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.Option, new Rectangle(Divers.WidthScreen / 2 - 50, 200, 100, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, 300, 100, 50));
                    break;

                case MenuType.MenuPreferences:
                    button_1 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 100, 50, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 100, 50, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 200, 50, 50));
                    button_4 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 200, 50, 50));
                    button_5 = new MenuButton(MenuButton.ButtonType.Mute, new Rectangle(Divers.WidthScreen / 2 + 200, 200, 70, 50));
                    button_6 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, 300, 100, 50));
                    break;

                case MenuType.MenuGeneralSettings:
                    button_1 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 70, 50, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 70, 50, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 50, 170, 50, 50));
                    button_4 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 100, 170, 50, 50));
                    button_5 = new MenuButton(MenuButton.ButtonType.Mute, new Rectangle(Divers.WidthScreen / 2 + 200, 170, 70, 50));
                    button_6 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, Divers.HeightScreen / 2 + 150, 100, 50));
                    button_7 = new MenuButton(MenuButton.ButtonType.On, new Rectangle(Divers.WidthScreen / 2 - 50, 270, 50, 50));
                    button_8 = new MenuButton(MenuButton.ButtonType.Off, new Rectangle(Divers.WidthScreen / 2 + 100, 270, 50, 50));
                    button_9 = new MenuButton(MenuButton.ButtonType.Credits, new Rectangle(Divers.WidthScreen / 2 + 200, Divers.HeightScreen / 2 + 150, 100, 50));
                    break;

                case MenuType.GameOver:
                    if (MenuButton.language == "French")
                        button_1 = new MenuButton(MenuButton.ButtonType.Restart, new Rectangle(Divers.WidthScreen / 2 - 100, 20, 200, 50));
                    else
                        button_1 = new MenuButton(MenuButton.ButtonType.Restart, new Rectangle(Divers.WidthScreen / 2 - 50, 20, 100, 50));
                    break;

                case MenuType.MapSelector:
                    button_1 = new MenuButton(MenuButton.ButtonType.Less, new Rectangle(Divers.WidthScreen / 2 - 300, Divers.HeightScreen / 2 - 30, 50, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.More, new Rectangle(Divers.WidthScreen / 2 + 300, Divers.HeightScreen / 2 - 30, 50, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.SelectLevel, new Rectangle(Divers.WidthScreen / 2 - 100, Divers.HeightScreen / 2 - 200, 230, 50));
                    button_4 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 30, Divers.HeightScreen / 2 + 150, 100, 50));
                    break;

                case MenuType.WinScreen:
                    if (MenuButton.language == "French")
                        button_1 = new MenuButton(MenuButton.ButtonType.Restart, new Rectangle(20, 20, 200, 50));
                    else
                        button_1 = new MenuButton(MenuButton.ButtonType.Restart, new Rectangle(20, 20, 100, 50));
                    break;

                case MenuType.Credits:
                    button_1 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, Divers.HeightScreen / 2 + 150, 100, 50));
                    break;

                case MenuType.MultiOrNot:
                    button_1 = new MenuButton(MenuButton.ButtonType.Solo, new Rectangle(Divers.WidthScreen / 2 - 50, 100, 100, 50));
                    button_2 = new MenuButton(MenuButton.ButtonType.J1, new Rectangle(Divers.WidthScreen / 2 - 50, 200, 100, 50));
                    button_3 = new MenuButton(MenuButton.ButtonType.J2, new Rectangle(Divers.WidthScreen / 2 + 100, 200, 100, 50));
                    button_4 = new MenuButton(MenuButton.ButtonType.Back, new Rectangle(Divers.WidthScreen / 2 - 50, 300, 100, 50));
                    break;

                case MenuType.Deconnexion:
                    button_1 = new MenuButton(MenuButton.ButtonType.Deconnexion, new Rectangle(Divers.WidthScreen / 2 - 100, Divers.HeightScreen / 2, 200, 50));
                    break;

                default:
                    break;
            }
        }


        // UPDATE & DRAW
        public int Update(MouseState mouse, KeyboardState keyboard)
        {
            bool b1 = button_1.Update(mouse);
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            bool b5 = false;
            bool b6 = false;
            bool b7 = false;
            bool b8 = false;
            bool b9 = false;

            if (button_2 != null)
                b2 = button_2.Update(mouse);
            if (button_3 != null)
                b3 = button_3.Update(mouse);
            if (button_4 != null)
                b4 = button_4.Update(mouse);
            if (button_5 != null)
                b5 = button_5.Update(mouse);
            if (button_6 != null)
                b6 = button_6.Update(mouse);
            if (button_7 != null)
                b7 = button_7.Update(mouse);
            if (button_8 != null)
                b8 = button_8.Update(mouse);
            if (button_9 != null)
                b9 = button_9.Update(mouse);

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
            if (b7)
                return 7;
            if (b8)
                return 8;
            if (b9)
                return 9;
            else
                return 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //button_1.DrawButton(spriteBatch);

            if (button_1 != null)
                button_1.DrawButton(spriteBatch);
            if (button_2 != null)
                button_2.DrawButton(spriteBatch);
            if (button_3 != null)
                button_3.DrawButton(spriteBatch);
            if (button_4 != null)
                button_4.DrawButton(spriteBatch);
            if (button_5 != null)
                button_5.DrawButton(spriteBatch);
            if (button_6 != null)
                button_6.DrawButton(spriteBatch);
            if (button_7 != null)
                button_7.DrawButton(spriteBatch);
            if (button_8 != null)
                button_8.DrawButton(spriteBatch);
            if (button_9 != null)
                button_9.DrawButton(spriteBatch);


            if (type == MenuType.MainMenu)
            {
                spriteBatch.DrawString(Ressources.HUD, "Copyright Dangerous Csharks", new Vector2(640, 460), Color.Red, 0f, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0f);
            }
            if (type == MenuType.MenuGeneralSettings)
            {
                string langue, son, resolution;
                if (MenuButton.language == "French")
                {
                    langue = "Langue";
                    son = "Musique";
                    resolution = "Plein Ecran";
                }
                else
                {
                    langue = "Language";
                    son = "Music";
                    resolution = "Full Screen";
                }
                spriteBatch.DrawString(Ressources.HUD, langue, new Vector2(Divers.WidthScreen / 2 - 250, 70), Color.White);
                spriteBatch.DrawString(Ressources.HUD, son, new Vector2(Divers.WidthScreen / 2 - 250, 170), Color.White);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString((int)(MediaPlayer.Volume * 10) * 10), new Vector2(Divers.WidthScreen / 2 + 10, 170), Color.White);
                spriteBatch.DrawString(Ressources.HUD, resolution, new Vector2(Divers.WidthScreen / 2 - 250, 270), Color.White);
            }
            if (type == MenuType.MenuPreferences)
            {
                string langue, son;
                if (MenuButton.language == "French")
                {
                    langue = "Langue";
                    son = "Musique";
                }
                else
                {
                    langue = "Language";
                    son = "Music";
                }
                spriteBatch.DrawString(Ressources.HUD, langue, new Vector2(Divers.WidthScreen / 2 - 250, 100), Color.White);
                spriteBatch.DrawString(Ressources.HUD, son, new Vector2(Divers.WidthScreen / 2 - 250, 200), Color.White);
                spriteBatch.DrawString(Ressources.HUD, Convert.ToString((int)(MediaPlayer.Volume * 10) * 10), new Vector2(Divers.WidthScreen / 2 + 10, 200), Color.White);
            }
            if (type == MenuType.Credits)
            {
                spriteBatch.DrawString(Ressources.HUD, "Alexis Guiho", new Vector2(Divers.WidthScreen / 2 - 90, 70), Color.White);
                spriteBatch.DrawString(Ressources.HUD, "David Baron", new Vector2(Divers.WidthScreen / 2 - 90, 150), Color.White);
                spriteBatch.DrawString(Ressources.HUD, "Andre Milon", new Vector2(Divers.WidthScreen / 2 - 90, 230), Color.White);
                spriteBatch.DrawString(Ressources.HUD, "Andry Razafindrazaka", new Vector2(Divers.WidthScreen / 2 - 90, 310), Color.White);
            }
        }
    }
}
