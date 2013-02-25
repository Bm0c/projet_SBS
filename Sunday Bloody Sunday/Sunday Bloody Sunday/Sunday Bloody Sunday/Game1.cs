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
        //FIELDS
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameMain Main;
        string path_map;

        //Enum of the Screen States
        public enum Screen
        {
            menu_principal, menu_pause, menu_preferences, menu_parametres, jeu, game_over, selecteur_map, win
        };

        //Init Screen State + Menu
        public static Screen ecran = Screen.menu_principal;
        Menu menuMain = new Menu(Menu.MenuType.MainMenu);
        int button_timer = 0;

        // Prochainement dans Sound.cs
        Song GamePlayMusic;
        Song MenuMusic;
        SoundEffect introEffect, loseEffect, winEffect;

        // Compteur Sélection Map
        int compteur_thumbnails = 1;
        int compteur_delai = 30;


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
            winEffect = Ressources.mWinEffect;
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
                    ecran = Screen.menu_pause;
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
                    ecran = Screen.menu_parametres;
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
                compteur_delai++;
                if (compteur_delai > 20)
                {
                    compteur_delai = 20;
                }
                if (button_timer == 20)
                {
                    action = menuMain.Update(Mouse.GetState(), Keyboard.GetState());
                }
                if (action == 1 && compteur_delai >= 20)
                {
                    compteur_delai = 0;
                    compteur_thumbnails -= 1;
                    if (compteur_thumbnails < 0)
                    {
                        compteur_thumbnails = 0;
                    }
                }
                if (action == 2 && compteur_delai >= 20)
                {
                    compteur_delai = 0;
                    compteur_thumbnails += 1;
                    if (compteur_thumbnails > 3)
                    {
                        compteur_thumbnails = 3;
                    }
                }
                if (action == 3)
                {
                    if (compteur_thumbnails == 0)
                    {
                        Main = new GameMain();
                        Main.MainMap = new Map(LecteurMap.lecture("map01.txt"));
                        path_map = "map01.txt";
                    }
                    else if (compteur_thumbnails == 1)
                    {
                        Main = new GameMain();
                        Main.MainMap = new Map(LecteurMap.lecture("map02.txt"));
                        path_map = "map02.txt";
                    }
                    else if (compteur_thumbnails == 2)
                    {
                        Main = new GameMain();
                        Main.MainMap = new Map(LecteurMap.lecture("map03.txt"));
                        path_map = "map03.txt";
                    }
                    else if (compteur_thumbnails == 3)
                    {
                        Main = new GameMain();
                        Main.MainMap = new Map(LecteurMap.lecture("map04.txt"));
                        path_map = "map04.txt";
                    }
                    ecran = Screen.jeu;
                    PlayMusic(GamePlayMusic);
                    button_timer = 0;
                }
                if (action == 4)
                {
                    ecran = Screen.menu_principal;
                    menuMain = new Menu(Menu.MenuType.MainMenu);
                    button_timer = 0;
                }
            }

            else if (ecran == Screen.menu_pause)
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
                    ecran = Screen.menu_preferences;
                    menuMain = new Menu(Menu.MenuType.MenuPreferences);
                    button_timer = 0;
                }
                if (action == 3)
                {
                    ecran = Screen.menu_principal;
                    menuMain = new Menu(Menu.MenuType.MainMenu);
                    button_timer = 0;
                    StopMusic(MenuMusic);
                }
            }

            else if (ecran == Screen.menu_preferences)
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
                    ecran = Screen.menu_pause;
                    menuMain = new Menu(Menu.MenuType.PauseMenu);
                    button_timer = 0;
                }
            }

            else if (ecran == Screen.menu_parametres)
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
                    button_timer = 0;
                }
                if (action == 7 && graphics.IsFullScreen == false)
                {
                    graphics.ToggleFullScreen();
                    button_timer = 0;
                }
                if (action == 8 && graphics.IsFullScreen == true)
                {
                    graphics.ToggleFullScreen();
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
                if (Main.MainMap.fin.gagne)
                {
                    ecran = Screen.win;
                    menuMain = new Menu(Menu.MenuType.WinScreen);
                    StopMusic(GamePlayMusic);
                    winEffect.Play();
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

                    ecran = Screen.selecteur_map;
                    menuMain = new Menu(Menu.MenuType.MapSelector);
                    button_timer = 0;
                }
            }

            else if (ecran == Screen.win)
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
                if (compteur_thumbnails == 0)
                {
                    spriteBatch.Draw(Ressources.ThumbnailsMap01, new Rectangle(Divers.WidthScreen / 2 - 200, Divers.HeightScreen / 2 - 120, 400, 240), Color.CadetBlue);
                    menuMain.Draw(spriteBatch);
                }
                else if (compteur_thumbnails == 1)
                {
                    spriteBatch.Draw(Ressources.ThumbnailsMap02, new Rectangle(Divers.WidthScreen / 2 - 200, Divers.HeightScreen / 2 - 120, 400, 240), Color.CadetBlue);
                    menuMain.Draw(spriteBatch);
                }
                else if (compteur_thumbnails == 2)
                {
                    spriteBatch.Draw(Ressources.ThumbnailsMap03, new Rectangle(Divers.WidthScreen / 2 - 200, Divers.HeightScreen / 2 - 120, 400, 240), Color.White);
                    menuMain.Draw(spriteBatch);
                }

                else if (compteur_thumbnails == 3)
                {
                    spriteBatch.Draw(Ressources.ThumbnailsMap03, new Rectangle(Divers.WidthScreen / 2 - 200, Divers.HeightScreen / 2 - 120, 400, 240), Color.White);
                    menuMain.Draw(spriteBatch);
                }
            }
            if (ecran == Screen.menu_pause)
            {
                Main.Draw(spriteBatch);
                menuMain.Draw(spriteBatch);
            }
            if (ecran == Screen.menu_preferences)
            {
                Main.Draw(spriteBatch);
                menuMain.Draw(spriteBatch);
            }
            if (ecran == Screen.menu_parametres)
            {
                GraphicsDevice.Clear(Color.Black);
                menuMain.Draw(spriteBatch);
            }
            if (ecran == Screen.jeu)
            {
                Main.Draw(spriteBatch);
            }
            if (ecran == Screen.game_over)
            {
                spriteBatch.Draw(Ressources.mGameOverScreen, new Rectangle(0, 0, 800, 480), Color.White);
                menuMain.Draw(spriteBatch);
            }
            if (ecran == Screen.win)
            {
                spriteBatch.Draw(Ressources.mWinSreen, new Rectangle(0, 0, 800, 480), Color.White);
                menuMain.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
