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
    class IA
    {
        public enum DirectionIA
        {
            Up, Down, Left, Right
        };

        // FIELDS
        Rectangle IntelTexture;
        DirectionIA Direction;
        Random rand;
        // Relative Position
        Vector2 PositionIntel;
        int speed;
        string action;
        // State of the player
        static public bool Active;
        // Amount of health points that IA has
        static public int Health;

        // CONSTRUCTOR
        public IA()
        {
            this.rand = new Random();
            this.IntelTexture = new Rectangle(rand.Next(0, 800), rand.Next(0, 480), 32, 50);
            this.PositionIntel = new Vector2(IntelTexture.X, IntelTexture.Y);
            this.speed = 1;
            this.action = "";
            IA.Active = true;
            IA.Health = 100;
        }


        // METHODS
        // Get the width of the enemy ship
        public int Width
        {
            get { return IntelTexture.Width; }
        }

        // Get the height of the enemy ship
        public int Height
        {
            get { return IntelTexture.Height; }
        }

        public void IAGenerator()
        {

        }


        // UPDATE & DRAW
        public void Update()
        {
            while (IntelTexture.X != Player.PlayerPosition.X && IntelTexture.Y != Player.PlayerPosition.Y)
            {
                if (IntelTexture.X < Player.PlayerPosition.X)
                    IntelTexture.X -= this.speed;
                else if (IntelTexture.X > Player.PlayerPosition.X)
                    IntelTexture.X += this.speed;
                else if (IntelTexture.Y < Player.PlayerPosition.Y)
                    IntelTexture.Y += this.speed;
                else
                    IntelTexture.Y -= this.speed;

                PositionIntel.X++;
                PositionIntel.Y++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Ressources.IA, this.IntelTexture, Color.White);
        }



    }
}
