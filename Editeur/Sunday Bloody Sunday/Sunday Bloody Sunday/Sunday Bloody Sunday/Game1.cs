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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseState mouse;
        Editeur editeur;
        
        //Enum of the Screen States
        //Init Screen State + Menu

        // Prochainement dans Sound.cs

        // Début fichier généré par XNA
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Préférences
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Ressources.LoadContent(Content);
            int largeur = 0;
            int hauteur = 0;
            Lecture.lire(ref largeur, ref hauteur);
            editeur = new Editeur(Ressources.Map, Ressources.valide,Ressources.invalide,hauteur,largeur);
        }

        // Prochainement dans Sound.cs
        public void PlayMusic(Song song)
        {
            try
            {
                // Joue la musique
                MediaPlayer.Play(song);
                // Active la répétition de la musique
                MediaPlayer.IsRepeating = true;
            }
            catch { }
        }

        public void StopMusic(Song song)
        {
            try
            {
                // Stop la musique
                MediaPlayer.Stop();
            }
            catch { }
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            editeur.Update(Mouse.GetState(),Keyboard.GetState());
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            editeur.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
