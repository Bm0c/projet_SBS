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
     public enum DirectionIA
     {
        Up, Down, Left, Right
     };

    class IA
    {
            // FIELDS
            Rectangle IATexture;
            DirectionIA Direction;
            SpriteEffects Effect;
            // Relative Position
            static public Vector2 IAPosition;
            int frameLine;
            int frameColumn;
            bool Animation;
            int Timer;
            int speed = 1;
            int AnimationSpeed = 10;
            string action;
            // State of the IA
            static public bool Active;
            // Amount of health
            static public int Health;


            // CONSTRUCTOR
            public IA()
            {
                this.IATexture = new Rectangle(100, 100, 23, 27);
                IA.IAPosition = new Vector2(IATexture.X, IATexture.Y);
                this.frameLine = 1;
                this.frameColumn = 2;
                this.Direction = DirectionIA.Down;
                this.Effect = SpriteEffects.None;
                this.Animation = true;
                this.Timer = 0;
                IA.Active = true;
                IA.Health = 100;
                this.action = "";
            }


            // METHODS
            // Get the width of the player
            public int Width
            {
                get { return IATexture.Width; }
            }

            // Get the height of the player
            public int Height
            {
                get { return IATexture.Height; }
            }

            // Animation of the IA
            public void Animate()
            {
                this.Timer++;
                if (this.Timer == this.AnimationSpeed)
                {
                    this.Timer = 0;
                    if (this.Animation)
                    {
                        this.frameColumn++;
                        if (this.frameColumn > 3)
                        {
                            this.frameColumn = 2;
                            this.Animation = false;
                        }
                    }
                    else
                    {
                        this.frameColumn--;
                        if (this.frameColumn < 1)
                        {
                            this.frameColumn = 2;
                            this.Animation = true;
                        }
                    }
                }
            }

            // Concerne l'action en cours de l'IA
            public string actionIA
            {
                get { return this.action; }
                set { this.action = value; }
            }

            // Renvois la futur position X de l'IA en cas d'un déplacement, à l'aide de l'action qui lui est attribuée
            public int futur_position_X_gauche()
            {
                if (actionIA == "left")
                    return (this.IATexture.X - this.speed + 1);
                else
                    return (this.IATexture.X + 1);
            }

            public int futur_position_X_droite()
            {
                if (actionIA == "right")
                    return (this.IATexture.X + this.speed + 16 - 1);
                else
                    return (this.IATexture.X + 16 - 1);
            }

            // Renvois la futur position Y de l'IA en cas d'un déplacement, à l'aide de l'action qui lui est attribuée
            public int futur_position_Y_haut()
            {
                if (actionIA == "up")
                    return (this.IATexture.Y - this.speed + 1 + 10);
                else
                    return (this.IATexture.Y + 1 + 10);
            }

            public int futur_position_Y_bas()
            {
                if (actionIA == "down")
                    return (this.IATexture.Y + this.speed - 1 + 19);
                else
                    return (this.IATexture.Y - 1 + 19);
            }

            // Met à jour l'IA en fontion de l'action qui lui est donné, pour l'instant, seul le déplacement est géré
            public void mise_a_jour(string a)
            {
                if (a == "up")
                {
                    this.IATexture.Y -= this.speed;
                    this.Direction = DirectionIA.Up;
                    this.Animate();
                }
                else if (a == "down")
                {
                    this.IATexture.Y += this.speed;
                    this.Direction = DirectionIA.Down;
                    this.Animate();
                }
                else if (a == "right")
                {
                    this.IATexture.X += this.speed;
                    this.Direction = DirectionIA.Right;
                    this.Animate();
                }
                else if (a == "left")
                {
                    this.IATexture.X -= this.speed;
                    this.Direction = DirectionIA.Left;
                    this.Animate();
                }

            }

            // UPDATE & DRAW
            public void Update(MouseState mouse, KeyboardState keyboard)
            {
                
                /* // Détermine les actions du joueur en fonction des retours claviers
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    this.action = "up";
                }
                else if (keyboard.IsKeyDown(Keys.Down))
                {
                    this.action = "down";
                }
                else if (keyboard.IsKeyDown(Keys.Right))
                {

                    this.action = "right";
                }
                else if (keyboard.IsKeyDown(Keys.Left))
                {

                    this.action = "left";
                }

                if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.Right))
                {
                    this.frameColumn = 2;
                    this.Timer = 0;
                } */

                switch (this.Direction)
                {
                    case DirectionIA.Up: this.frameLine = 2;
                        this.Effect = SpriteEffects.None;
                        break;
                    case DirectionIA.Down: this.frameLine = 1;
                        this.Effect = SpriteEffects.None;
                        break;
                    case DirectionIA.Left: this.frameLine = 3;
                        this.Effect = SpriteEffects.None;
                        break;
                    case DirectionIA.Right: this.frameLine = 3;
                        this.Effect = SpriteEffects.FlipHorizontally;
                        break;
                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(Ressources.IA, this.IATexture, new Rectangle((this.frameColumn - 1) * 23, (this.frameLine - 1) * 27, 23, 27), Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
            }
      }
}