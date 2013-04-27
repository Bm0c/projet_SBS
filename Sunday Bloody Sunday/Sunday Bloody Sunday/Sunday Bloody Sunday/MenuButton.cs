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
            SelectLevel, Play, Option, Quit, Resume, Back, More, Less, Mute, Restart, On, Off, Credits, Solo, J1, J2, Deconnexion
        };


        //FIELDS
        ButtonType myButton;
        string buttonMessage;
        Rectangle rectangle;
        Rectangle mouseCursor_container;
        static public string language = "French";


        //CONSTRUCTOR
        public MenuButton(ButtonType myButtonType, Rectangle container)
        {
            switch (myButtonType)
            {
                case ButtonType.SelectLevel:
                    this.myButton = ButtonType.SelectLevel;
                    if (language == "French")
                        buttonMessage = "Choisir ce niveau";
                    else
                        buttonMessage = "Choose this level";
                    break;

                case ButtonType.Play:
                    this.myButton = ButtonType.Play;
                    if (language == "French")
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
                    if (language == "French")
                        buttonMessage = "Quitter";
                    else
                        buttonMessage = "Quit";
                    break;

                case ButtonType.Back:
                    this.myButton = ButtonType.Quit;
                    if (language == "French")
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
                    if (language == "French")
                        buttonMessage = "Muet";
                    else
                        buttonMessage = "Mute";
                    break;

                case ButtonType.Resume:
                    this.myButton = ButtonType.Resume;
                    if (language == "French")
                        buttonMessage = "Reprendre";
                    else
                        buttonMessage = "Resume";
                    break;

                case ButtonType.Restart:
                    this.myButton = ButtonType.Restart;
                    if (language == "French")
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

                case ButtonType.Credits:
                    this.myButton = ButtonType.Credits;
                    buttonMessage = "Credits";
                    break;

                case ButtonType.Solo:
                    this.myButton = ButtonType.Solo;
                    buttonMessage = "Solo";
                    break;

                case ButtonType.J1:
                    this.myButton = ButtonType.J1;
                    buttonMessage = "Multi1";
                    break;

                case ButtonType.J2:
                    this.myButton = ButtonType.J2;
                    buttonMessage = "Multi2";
                    break;

                case ButtonType.Deconnexion:
                    this.myButton = ButtonType.Deconnexion;
                    buttonMessage = "Deconnexion";
                    break;

                default:
                    this.myButton = ButtonType.Play;
                    buttonMessage = "";
                    break;
            }
            this.myButton = myButtonType;
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
