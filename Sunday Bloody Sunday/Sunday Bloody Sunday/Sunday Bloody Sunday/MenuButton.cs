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
    class MenuButton
    {
        public enum ButtonType
        {
            SelectLevel, Play, Option, Quit, Resume, Back, More, Less, Mute, Restart, On, Off
        };


        //FIELDS
        ButtonType myButton;
        string buttonMessage;
        Rectangle rectangle;
        Rectangle mouseCursor_container;
        static public string langage = "English";


        //CONSTRUCTOR
        public MenuButton(ButtonType myButtonType, Rectangle container)
        {
            switch (myButtonType)
            {
                case ButtonType.SelectLevel:
                    this.myButton = ButtonType.SelectLevel;
                    if (langage == "French")
                        buttonMessage = "Choisir ce niveau";
                    else
                        buttonMessage = "Choose this level";
                    break;

                case ButtonType.Play:
                    this.myButton = ButtonType.Play;
                    if (langage == "French")
                        buttonMessage = "Jouer";
                    else
                        buttonMessage = "Play";
                    break;

                case ButtonType.Option:
                    this.myButton = ButtonType.Option;
                    buttonMessage = "Options";
                    break;

                case ButtonType.Quit:
                    this.myButton = ButtonType.Quit;
                    if (langage == "French")
                        buttonMessage = "Quitter";
                    else
                        buttonMessage = "Quit";
                    break;

                case ButtonType.Back:
                    this.myButton = ButtonType.Quit;
                    if (langage == "French")
                        buttonMessage = "Retour";
                    else
                        buttonMessage = "Back";
                    break;

                case ButtonType.More:
                    this.myButton = ButtonType.Quit;
                    buttonMessage = ">";
                    break;

                case ButtonType.Less:
                    this.myButton = ButtonType.Quit;
                    buttonMessage = "<";
                    break;

                case ButtonType.Mute:
                    this.myButton = ButtonType.Quit;
                    if (langage == "French")
                        buttonMessage = "Muet";
                    else
                        buttonMessage = "Mute";
                    break;

                case ButtonType.Resume:
                    this.myButton = ButtonType.Resume;
                    if (langage == "French")
                        buttonMessage = "Reprendre";
                    else
                        buttonMessage = "Resume";
                    break;

                case ButtonType.Restart:
                    this.myButton = ButtonType.Restart;
                    if (langage == "French")
                        buttonMessage = "Recommencer";
                    else
                        buttonMessage = "Restart";
                    break;

                case ButtonType.On:
                    this.myButton = ButtonType.On;
                    buttonMessage = "On";
                    break;

                case ButtonType.Off:
                    this.myButton = ButtonType.Off;
                    buttonMessage = "Off";
                    break;

                default:
                    this.myButton = ButtonType.Play;
                    buttonMessage = "";
                    break;
            }
            this.rectangle = container;
        }


        // UPDATE & DRAW
        public bool Update(MouseState mouse)
        {
            mouseCursor_container = new Rectangle(mouse.X, mouse.Y, 0, 0);

            if (mouseCursor_container.Intersects(rectangle) && mouse.LeftButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public void DrawButton(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Ressources.HUD, buttonMessage, new Vector2(rectangle.X, rectangle.Y), Color.White);

            if (mouseCursor_container.Intersects(rectangle))
            {
                spriteBatch.DrawString(Ressources.HUD, buttonMessage, new Vector2(rectangle.X, rectangle.Y), Color.Yellow);
            }
        }
    }
}
