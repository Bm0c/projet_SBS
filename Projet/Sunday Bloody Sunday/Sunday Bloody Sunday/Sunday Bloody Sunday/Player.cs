using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sunday_Bloody_Sunday
{
    public enum Direction
    {
        Up, Down, Left, Right
    };

    class Player
    {
        // FIELDS
        Rectangle Hitbox;

        Direction Direction;
        SpriteEffects Effect;
        int frameLine;
        int frameColumn;
        bool Animation;
        int Timer;

        int speed = 2;
        int AnimationSpeed = 10;

        // CONSTRUCTOR
        public Player()
        {
            this.Hitbox = new Rectangle(450, 200, 25, 27);
            this.frameLine = 1;
            this.frameColumn = 2;
            this.Direction = Direction.Down;
            this.Effect = SpriteEffects.None;
            this.Animation = true;
            this.Timer = 0;
        }

        // METHODS
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

        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up))
            {
                this.Hitbox.Y -= this.speed;
                this.Direction = Direction.Up;
                this.Animate();
            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                this.Hitbox.Y += this.speed;
                this.Direction = Direction.Down;
                this.Animate();
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                this.Hitbox.X += this.speed;
                this.Direction = Direction.Right;
                this.Animate();
            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                this.Hitbox.X -= this.speed;
                this.Direction = Direction.Left;
                this.Animate();
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
            spriteBatch.Draw(Ressources.Pikachu, this.Hitbox, new Rectangle ((this.frameColumn -1) * 25, (this.frameLine -1) * 27, 25, 27), Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
        }
    }
}
