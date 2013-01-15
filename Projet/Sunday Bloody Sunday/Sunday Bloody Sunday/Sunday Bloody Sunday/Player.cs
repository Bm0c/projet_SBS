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
        public Rectangle PlayerTexture;
        public Direction Direction;
        SpriteEffects Effect;
        // Relative Position
        static public Vector2 PlayerPosition;
        int frameLine;
        int frameColumn;
        bool Animation;
        int Timer;
        int speed = 2;
        int AnimationSpeed = 10;
        string action;
        // State of the player
        static public bool Active;
        // Amount of health
        static public int Health;
        // Amount of munition that player has
        public int Ammo;
        // The amount of damage the Player can inflict to the IA
        static public int Damage;

        public Keys Haut;
        public Keys Bas;
        public Keys Gauche;
        public Keys Droite;
        public Keys Tire;

        public int refroiddissement = 0;

        Texture2D texture;

        public bool est_afficher = false;


        // CONSTRUCTOR
        public Player(Keys Haut, Keys Bas, Keys Gauche, Keys Droite, Keys Tire, Texture2D texture)
        {
            this.PlayerTexture = new Rectangle(Divers.WidthScreen / 2, Divers.HeightScreen / 2, 16, 19);
            Player.PlayerPosition = new Vector2(PlayerTexture.X, PlayerTexture.Y);
            this.frameLine = 1;
            this.frameColumn = 2;
            this.Direction = Direction.Down;
            this.Effect = SpriteEffects.None;
            this.Animation = true;
            this.Timer = 0;
            Player.Active = true;
            Player.Health = 100;
            this.Ammo = 100;
            Player.Damage = 10;
            this.action = "";

            this.Haut = Haut;
            this.Bas = Bas;
            this.Gauche = Gauche;
            this.Droite = Droite;
            this.Tire = Tire;

            this.texture = texture;


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

        public Vector2 centre()
        {
            Vector2 vector = new Vector2(PlayerTexture.X + Width / 2 - 3, PlayerTexture.Y + Height - 10);
            return vector;
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

        // Concerne l'action en cours du joueurs, permet d'y accéder et de la modifier
        public string actionjoueur
        {
            get { return this.action; }
            set { this.action = value; }

        }

        // Renvois la futur position X du joueur en cas d'un déplacement, à l'aide de l'action qui lui est attribuée
        public int futur_position_X_gauche()
        {
            if (actionjoueur == "left")
                return (this.PlayerTexture.X - this.speed + 1);
            else
                return (this.PlayerTexture.X + 1);
        }

        public int futur_position_X_droite()
        {
            if (actionjoueur == "right")
                return (this.PlayerTexture.X + this.speed + 16 - 1);
            else
                return (this.PlayerTexture.X + 16 - 1);
        }

        // Renvois la futur position Y du joueur en cas d'un déplacement, à l'aide de l'action qui lui est attribuée
        public int futur_position_Y_haut()
        {
            if (actionjoueur == "up")
                return (this.PlayerTexture.Y - this.speed + 1 + 10);
            else
                return (this.PlayerTexture.Y + 1 + 10);
        }

        public int futur_position_Y_bas()
        {
            if (actionjoueur == "down")
                return (this.PlayerTexture.Y + this.speed - 1 + 19);
            else
                return (this.PlayerTexture.Y - 1 + 19);
        }

        public void maj_direction(string a)
        {
            if (a == "up")
            {
                this.Direction = Direction.Up;
                this.Animate();
            }
            else if (a == "down")
            {
                this.Direction = Direction.Down;
                this.Animate();
            }
            else if (a == "right")
            {
                this.Direction = Direction.Right;
                this.Animate();
            }
            else if (a == "left")
            {
                this.Direction = Direction.Left;
                this.Animate();
            }
        }


        // Met à jour le héros en fontion de l'action qui lui est donné, pour l'instant, seul le déplacement est géré
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

        //Renvois le futur rectangle du joueur
        public Rectangle rectangle()
        {
            return new Rectangle(futur_position_X_gauche(), futur_position_Y_haut(), futur_position_X_droite() - futur_position_X_gauche(), futur_position_Y_bas() - futur_position_Y_haut());
        }

        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            // Détermine les actions du joueur en fonction des retours claviers
            if (keyboard.IsKeyDown(Haut))
            {
                this.action = "up";
            }
            else if (keyboard.IsKeyDown(Bas))
            {
                this.action = "down";
            }
            else if (keyboard.IsKeyDown(Droite))
            {

                this.action = "right";
            }
            else if (keyboard.IsKeyDown(Gauche))
            {

                this.action = "left";
            }

            if (keyboard.IsKeyUp(Haut) && keyboard.IsKeyUp(Bas) && keyboard.IsKeyUp(Gauche) && keyboard.IsKeyUp(Droite))
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
            spriteBatch.Draw(this.texture, this.PlayerTexture, new Rectangle((this.frameColumn - 1) * 16, (this.frameLine - 1) * 19, 16, 19), Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
        }
    }
}
