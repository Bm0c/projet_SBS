using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Sunday_Bloody_Sunday
{
    class Animationattack
    {
        // FIELDS
        public Rectangle Hitbox;
        public bool Animation;
        int FrameLine;
        int FrameColumn;
        int Timer;
        int AnimationSpeed = 6;

        // CONSTRUCTOR
        public Animationattack(int x, int y)
        {
            this.Hitbox = new Rectangle(x, y, 40, 59);
            Animation = true;
            this.FrameLine = 1;
            this.FrameColumn = 2;
            this.Animation = true;
            this.Timer = 0;

        }
        public void Animate()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameColumn++;
                if (this.FrameColumn > 4)
                {
                    Animation = false;
                }


            }

        }

        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (Animation)
            {
                Animate();
            }

        }

        public void Draw(SpriteBatch spriteBatch, Rectangle MapTexture)
        {
            if (Animation)
            {
                spriteBatch.Draw(Ressources.mattackeclair, new Rectangle(MapTexture.X + Hitbox.X, MapTexture.Y + Hitbox.Y, 40, 59), new Rectangle((this.FrameColumn - 1) * 138, (this.FrameLine - 1) * 183, 138, 183), Color.White);

            }
        }
    }
}
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Sunday_Bloody_Sunday
{
    class Animationattack
    {
        // FIELDS
        Rectangle Hitbox;
        bool Animation;
        int FrameLine;
        int FrameColumn;
        int Timer;
        int AnimationSpeed = 6;
        int CoolDownVitesse = 0;
        int DurerAnim = 0;
        bool stopanim = true;

        // CONSTRUCTOR
        public Animationattack()
        {
            this.Hitbox = new Rectangle(42, 42, 40, 59);
            this.FrameLine = 1;
            this.FrameColumn = 2;
            this.Animation = true;
            this.Timer = 0;

        }
        public void Animate()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                if (this.Animation)
                {
                    this.Timer = 0;
                    this.FrameColumn++;
                    if (this.FrameColumn > 4)
                    {
                        this.FrameColumn = 1;
                    }
                }

            }

        }

        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.R))
            {
                stopanim = false;
            }
            if (stopanim == false)
            {
                DurerAnim = DurerAnim + 1;
            }
            if (DurerAnim == 40)
            {
                DurerAnim = 0;
                stopanim = true;
            }

            if (DurerAnim > 1 && CoolDownVitesse <= 30)
            {
                
                Animation = true;
                this.Hitbox.X = Mouse.GetState().X -20;
                this.Hitbox.Y = Mouse.GetState().Y -20 ;
                DurerAnim =0;

                if (CoolDownVitesse == 0)
                {
                    this.Animate();
                    //Ressources.mExplosionEffect.Play();
                    CoolDownVitesse = 1;
                    FrameColumn = 1;
                    FrameLine = 1;

                }
            }
                if (this.Animation == true)
                {
                    this.Animate();
                }



                CoolDownVitesse = CoolDownVitesse + 1;

                if (CoolDownVitesse == 150)
                {
                    CoolDownVitesse = 0;

                }
           
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            if (Animation == true)
            {
                spriteBatch.Draw(Ressources.mattackeclair, this.Hitbox,
                   new Rectangle((this.FrameColumn - 1) *138, (this.FrameLine - 1) * 183, 138, 183), Color.White);

                Animation = false;

            }

        }
    }
}

*/