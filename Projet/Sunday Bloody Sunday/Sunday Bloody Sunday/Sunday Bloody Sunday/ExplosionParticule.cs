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
    class ExplosionParticule
    {
        //FIELDS
        // The image representing the collection of images used for animation
        Texture2D spriteStrip;
        // The scale used to display the sprite strip
        float scale;
        // The time since we last updated the frame
        int elapsedTime;
        // The time we display a frame until the next one
        int frameTime;
        // The number of frames that the animation contains
        int frameCount;
        // The index of the current frame we are displaying
        int currentFrame;
        // The color of the frame we will be displaying
        Color color;
        // The area of the image strip we want to display
        Rectangle sourceRect = new Rectangle();
        // The area where we want to display the image strip in the game
        Rectangle destinationRect = new Rectangle();
        // Width of a given frame
        public int FrameWidth;
        // Height of a given frame
        public int FrameHeight;
        // The state of the Animation
        public bool Active;
        // Determines if the animation will keep playing or deactivate after one run
        public bool Looping;
        // Width of a given frame
        public Vector2 Position;
        public Rectangle Aire_explosionBomb;


        //CONSTRUCTOR
        public void Initialize(Texture2D texture, Vector2 position,int frameWidth, int frameHeight, int frameCount, int frametime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frametime;
            this.scale = scale;
            this.Looping = looping;
            this.Position = position;
            this.spriteStrip = texture;
            this.elapsedTime = 0;
            this.currentFrame = 0;
            this.Active = true;
            // EXPLOSION AREAS FOR BOMBS
            this.Aire_explosionBomb = new Rectangle();
        }


        //UPDATE & DRAW
        public void Update(GameTime gameTime, List<Player> liste_joueurs, List<IA> liste_ia)
        {
            // Do not update the game if we are not active
            if (Active == false)
                return;

            // Update the elapsed time
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            // If the elapsed time is larger than the frame time
            // we need to switch frames
            if (elapsedTime > frameTime)
            {
                // Move to the next frame
                currentFrame++;


                // If the currentFrame is equal to frameCount reset currentFrame to zero
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    // If we are not looping deactivate the animation
                    if (Looping == false)
                        Active = false;
                }


                // Reset the elapsed time to zero
                elapsedTime = 0;
            }

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            sourceRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2,
            (int)Position.Y - (int)(FrameHeight * scale) / 2,
            (int)(FrameWidth * scale),
            (int)(FrameHeight * scale));


            // Player ou IA dans la zone d'explosion = DEAD
            foreach (Player joueur in liste_joueurs)
            {
                if ((joueur.PlayerTexture.Intersects(this.Aire_explosionBomb)))
                {
                    joueur.Health = 0;
                }
                else if ((joueur.PlayerTexture.Intersects(this.Aire_explosionBomb)))
                {
                    joueur.Health = 0;
                }
                else if ((joueur.PlayerTexture.Intersects(this.Aire_explosionBomb)))
                {
                    joueur.Health = 0;
                }
            }

            foreach (IA ia in liste_ia)
            {
                if ((ia.IATexture.Intersects(this.Aire_explosionBomb)))
                {
                    ia.Health = 0;
                }
                else if ((ia.IATexture.Intersects(this.Aire_explosionBomb)))
                {
                    ia.Health = 0;
                }
                else if ((ia.IATexture.Intersects(this.Aire_explosionBomb)))
                {
                    ia.Health = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(Ressources.ExplosionParticule, destinationRect, sourceRect, color);
            }
        }
    }
}

