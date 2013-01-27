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
    class Items
    {
        // FIELDS
        Texture2D HealBoxTexture;
        Rectangle HealthBoxContainer;
        Vector2 HealthBoxPosition;
        Vector2 HealthOrigin;
        float rotation;
        public bool isVisible;
        public bool Used;


        // CONSTRUCTOR
        public Items(int x, int y, Texture2D texture)
        {
            this.HealBoxTexture = Ressources.HealthBox;
            this.HealthBoxContainer = new Rectangle(100, 100, 16, 16);
            this.HealthBoxPosition = new Vector2(HealthBoxContainer.X, HealthBoxContainer.Y);
            this.HealthOrigin = new Vector2(HealthBoxContainer.X / 2, HealthBoxContainer.Y / 2);
            this.rotation = 42f;
            this.isVisible = true;                
            this.Used = false;
        }


        // METHODS
        // Get the width of the HealthBox
        public int WidthHealthBox
        {
            get { return HealthBoxContainer.Width; }
        }
        // Get the height of the HealthBox
        public int HeightHealthBox
        {
            get { return HealthBoxContainer.Height; }
        }


        // UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.HealBoxTexture, this.HealthBoxPosition, /*null, */Color.White/*, rotation, HealthOrigin, 1.0f, SpriteEffects.None, 0*/);
        }
    }
}
