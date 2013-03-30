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
    class GameMain
    {
        // FIELDS
        public Map MainMap;
        HUD MainHUD;


        // CONCSTRUCTOR
        public GameMain()
        {/*
            this.MainMap = new Map(LecteurMap.lecture(chemin_map));*/
            this.MainHUD = new HUD();
        }


        // METHODS


        // UPDATE & DRAW
        public void Update(MouseState mouse, KeyboardState keyboard, GameTime gameTime, GraphicsDevice graphics)
        {
            MainMap.Update(mouse, keyboard, gameTime, graphics);
            MainHUD.Update(keyboard, MainMap.liste_joueurs);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MainMap.Draw(spriteBatch);
            MainHUD.Draw(spriteBatch);
        }
    }
}
