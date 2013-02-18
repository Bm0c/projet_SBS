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
        SpriteFont spriteFont;
        GameMain Main;

        //Enum of the Screen States
        public enum Screen
        {
            menu_principal, menu_jeu, menu_option, menu_parametre, jeu, game_over, selecteur_map
        };
        //Init Screen State + Menu
        public static Screen ecran = Screen.menu_principal;
        Menu menuMain = new Menu(Menu.MenuType.MainMenu);
        int button_timer = 0;

        // Prochainement dans Sound.cs
        Song GamePlayMusic;
        Song MenuMusic;
        SoundEffect introEffect, loseEffect;

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

            // Chargement musique
            GamePlayMusic = Ressources.GamePlayMusic;
            MenuMusic = Ressources.MenuMusic;
            // Chargement effet
            introEffect = Ressources.mIntroEffect;
            loseEffect = Ressources.mLoseEffect;
            introEffect.Play();
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
            if (button_timer < 20)
            {
                button_timer++;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (ecran == Screen.jeu)
                {
                    ecran = Screen.menu_jeu;
                    menuMain = new Menu(Menu.MenuType.PauseMenu);
                    PlayMusic(MenuMusic);
                }
                else if (ecran == Screen.menu_principal)
                {
                    Exit();
                }
            }

            if (ecran == Screen.menu_principal)
            {
                int action = 0;

                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 1)
                {
                    ecran = Screen.selecteur_map;
                    menuMain = new Menu(Menu.MenuType.MapSelector);
                    button_timer = 0;
                }
                if (action == 2)
                {
                    ecran = Screen.menu_parametre;
                    menuMain = new Menu(Menu.MenuType.MenuGeneralSettings);
                    button_timer = 0;
                }
                if (action == 3)
                {
                    Exit();
                }
            }

            else if (ecran == Screen.selecteur_map)
            {
                int action = 0;

                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 3)
                {
                    Main = new GameMain();
                    ecran = Screen.jeu;
                    PlayMusic(GamePlayMusic);
                    button_timer = 0;
                }
            }

            else if (ecran == Screen.menu_jeu)
            {
                int action = 0;

                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 1)
                {
                    ecran = Screen.jeu;
                    button_timer = 0;
                    PlayMusic(GamePlayMusic);
                }
                if (action == 2)
                {
                    ecran = Screen.menu_option;
                    menuMain = new Menu(Menu.MenuType.MenuPreferences);
                    button_timer = 0;
                }
                if (action == 3)
                {
                    ecran = Screen.menu_principal;
                    menuMain = new Menu(Menu.MenuType.MainMenu);
                    button_timer = 0;
                    StopMusic(MenuMusic);
                    introEffect.Play();
                }
            }

            else if (ecran == Screen.menu_option)
            {
                int action = 0;

                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 1)
                {
                    MenuButton.langage = "French";
                    menuMain = new Menu(Menu.MenuType.MenuPreferences);
                    button_timer = 0;
                }
                if (action == 2)
                {
                    MenuButton.langage = "English";
                    menuMain = new Menu(Menu.MenuType.MenuPreferences);
                    button_timer = 0;
                }
                if (action == 3)
                {
                    MediaPlayer.Volume -= 0.1f;
                    button_timer = 0;
                }
                if (action == 4)
                {
                    MediaPlayer.Volume += 0.1f;
                    button_timer = 0;
                }
                if (action == 5)
                {
                    MediaPlayer.Volume = 0;
                    button_timer = 0;
                }
                if (action == 6)
                {
                    ecran = Screen.menu_jeu;
                    menuMain = new Menu(Menu.MenuType.PauseMenu);
                    button_timer = 0;
                }
            }

            else if (ecran == Screen.menu_parametre)
            {
                int action = 0;

                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 1)
                {
                    MenuButton.langage = "French";
                    menuMain = new Menu(Menu.MenuType.MenuGeneralSettings);
                    button_timer = 0;
                }
                if (action == 2)
                {
                    MenuButton.langage = "English";
                    menuMain = new Menu(Menu.MenuType.MenuGeneralSettings);
                    button_timer = 0;
                }
                if (action == 3)
                {
                    MediaPlayer.Volume -= 0.1f;
                    button_timer = 0;
                }
                if (action == 4)
                {
                    MediaPlayer.Volume += 0.1f;
                    button_timer = 0;
                }
                if (action == 5)
                {
                    MediaPlayer.Volume = 0;
                    button_timer = 0;
                }
                if (action == 6)
                {
                    ecran = Screen.menu_principal;
                    menuMain = new Menu(Menu.MenuType.MainMenu);
                    introEffect.Play();
                    button_timer = 0;
                }
            }
            else if (ecran == Screen.jeu)
            {
                Main.Update(Mouse.GetState(), Keyboard.GetState(), gameTime);

                if (Main.MainMap.game_over)
                {
                    ecran = Screen.game_over;
                    menuMain = new Menu(Menu.MenuType.GameOver);
                    StopMusic(GamePlayMusic);
                    loseEffect.Play();
                }
            }

            else if (ecran == Screen.game_over)
            {
                int action = 0;

                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 1)
                {
                    Main = new GameMain();
                    ecran = Screen.jeu;
                    PlayMusic(GamePlayMusic);
                    button_timer = 0;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

                if (ecran == Screen.menu_principal)
                {
                    spriteBatch.Draw(Ressources.mTitleScreen, new Rectangle(0, 0, 800, 480), Color.White);
                    menuMain.Draw(spriteBatch);
                }
                if (ecran == Screen.selecteur_map)
                {
                    spriteBatch.Draw(Ressources.ThumbnailsMap01, new Rectangle(Divers.WidthScreen / 2 - 200, Divers.HeightScreen / 2 - 120, 400, 240), Color.CadetBlue);
                    menuMain.Draw(spriteBatch);
                }
                if (ecran == Screen.menu_jeu)
                {
                    Main.Draw(spriteBatch, spriteFont);
                    menuMain.Draw(spriteBatch);
                }
                if (ecran == Screen.menu_option)
                {
                    Main.Draw(spriteBatch, spriteFont);
                    menuMain.Draw(spriteBatch);
                }
                if (ecran == Screen.menu_parametre)
                {
                    GraphicsDevice.Clear(Color.Black);
                    menuMain.Draw(spriteBatch);
                }
                if (ecran == Screen.jeu)
                {
                    Main.Draw(spriteBatch, spriteFont);
                }
                if (ecran == Screen.game_over)
                {
                    spriteBatch.Draw(Ressources.mGameOverScreen, new Rectangle(0, 0, 800, 480), Color.White);
                    menuMain.Draw(spriteBatch);
                }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
