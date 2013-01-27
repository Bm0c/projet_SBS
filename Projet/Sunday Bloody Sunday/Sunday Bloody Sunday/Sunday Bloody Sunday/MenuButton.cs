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
            Play, Option, Quit, Resume, Back, More, Less, French, English, Mute/*, NormalScreen, FullScreen*/
        };


        //FIELDS
        ButtonType myButton;
        string buttonMessage;
        Rectangle rectangle;
        Rectangle rectangle_mouseCursor;
        static public string langage = "English";
        int timer = 0;


        //CONSTRUCTOR
        public MenuButton(ButtonType myButtonType, Rectangle container)
        {
            switch (myButtonType)
            {
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

                case ButtonType.English:
                    this.myButton = ButtonType.Quit;
                    buttonMessage = "English";
                    break;

                case ButtonType.French:
                    this.myButton = ButtonType.Quit;
                    buttonMessage = "Français";
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
                    buttonMessage = "+";
                    break;

                case ButtonType.Less:
                    this.myButton = ButtonType.Quit;
                    buttonMessage = "-";
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

                /*case ButtonType.NormalScreen:
                    this.myButton = ButtonType.NormalScreen;
                    if (langage == "French")
                        buttonMessage = "Normale";
                    else
                        buttonMessage = "Normal";
                    break;

                case ButtonType.FullScreen:
                    this.myButton = ButtonType.FullScreen;
                    if (langage == "French")
                        buttonMessage = "Grande";
                    else
                        buttonMessage = "Full";
                    break;*/

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
            rectangle_mouseCursor = new Rectangle(mouse.X, mouse.Y, 0, 0);

            if (rectangle_mouseCursor.Intersects(rectangle) && mouse.LeftButton == ButtonState.Pressed)
                return true;
            else
                return false;
        }

        public void DrawButton(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Ressources.HUD, buttonMessage, new Vector2(rectangle.X, rectangle.Y), Color.White);

            if (rectangle_mouseCursor.Intersects(rectangle))
            {
                // Because of blood
                spriteBatch.DrawString(Ressources.HUD, buttonMessage, new Vector2(rectangle.X, rectangle.Y), Color.Yellow);
            }
        }
    }
}
