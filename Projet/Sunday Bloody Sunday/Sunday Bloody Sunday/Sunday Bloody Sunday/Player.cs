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
    public enum Direction
    {
        Up, Down, Left, Right
    };

    class Player
    {
        // FIELDS
        Rectangle PlayerTexture;
        Direction Direction;
        SpriteEffects Effect;
        int frameLine;
        int frameColumn;
        bool Animation;
        int Timer;
        int speed = 2;
        int AnimationSpeed = 10;
        string action;

        // State of the player
        static public bool Active;
        // Amount of health points that player has
        static public int Health;

        // CONSTRUCTOR
        public Player()
        {
            this.PlayerTexture = new Rectangle(450, 200, 25, 27);
            this.frameLine = 1;
            this.frameColumn = 2;
            this.Direction = Direction.Down;
            this.Effect = SpriteEffects.None;
            this.Animation = true;
            this.Timer = 0;
            Player.Active = true;
            Player.Health = 100;
            this.action = "";
        }

        // METHODS
        // Get the width of the player
        public int Width
        {
            get { return PlayerTexture.Width; }
        }

        // Get the height of the player
        public int Height
        {
            get { return PlayerTexture.Height; }
        }

        // Animation of the Player
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

        public string actionjoueur
        {
            get { return this.action; }
            set { this.action = value; }

        }

        public int futur_position_X()
        {

            if (this.actionjoueur == "right")
            {
                return (this.PlayerTexture.X + this.speed);

            }
            else if (this.actionjoueur == "left")
            {
                return (this.PlayerTexture.X - this.speed);

            }
            else
            {
                return (this.PlayerTexture.X);
            }
        }


        public int futur_position_Y()
        {
            if (this.actionjoueur == "up")
            {
                return (this.PlayerTexture.Y - this.speed);

            }
            else if (this.actionjoueur == "down")
            {
                return (this.PlayerTexture.Y + this.speed);
            }
            else
            {
                return (this.PlayerTexture.Y);
            }
        }

        public void mise_a_jour(string a)
        {
            if (a == "up")
            {
                this.PlayerTexture.Y -= this.speed;
                this.Direction = Direction.Up;
                this.Animate();
            }
            else if (a == "down")
            {
                this.PlayerTexture.Y += this.speed;
                this.Direction = Direction.Down;
                this.Animate();
            }
            else if (a == "right")
            {
                this.PlayerTexture.X += this.speed;
                this.Direction = Direction.Right;
                this.Animate();
            }
            else if (a == "left")
            {
                this.PlayerTexture.X -= this.speed;
                this.Direction = Direction.Left;
                this.Animate();
            }

        }

        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
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
            }

            switch (this.Direction)
            {
                case Direction.Up: this.frameLine = 2;
                    this.Effect = SpriteEffects.None;
                    break;
                case Direction.Down: this.frameLine = 1;
                    this.Effect = SpriteEffects.None;
                    break;
                case Direction.Left: this.frameLine = 3;
                    this.Effect = SpriteEffects.None;
                    break;
                case Direction.Right: this.frameLine = 3;
                    this.Effect = SpriteEffects.FlipHorizontally;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.Player, this.PlayerTexture, new Rectangle((this.frameColumn - 1) * 25, (this.frameLine - 1) * 27, 25, 27), Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
        }
    }
}
