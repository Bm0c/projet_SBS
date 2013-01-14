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
    
    enum Screen
    {
        Title,
        Main,
        Inventory,
        Menu
    }

    enum MenuOptions
    {
        Resume,
        Inventory,
        ExitGame
    }

    class Menu : Microsoft.Xna.Framework.Game
    {
        //FIELDS
        Screen mCurrentScreen;
        MenuOptions mCurrentMenuOption;
        static public Texture2D mTitleScreen;
        static public Texture2D mMenu;
        static public Texture2D mMenuOptions;
        static public Texture2D mInventoryScreen;
        KeyboardState mPreviousKeyboardState;
        static public bool Pause;
        


        //CONSTRUCTOR
        public Menu()
        {
            Menu.Pause = false;
            this.mCurrentScreen = Screen.Title;
            mCurrentMenuOption = MenuOptions.Resume;
            mTitleScreen = Ressources.mTitleScreen;
            mMenu = Ressources.mMenu;
            mMenuOptions = Ressources.mMenuOptions;
            mInventoryScreen = Ressources.mInventoryScreen;
        }


        //METHODS


        //UPDATE & DRAW
        public void Update(KeyboardState keyboard)
        {

            KeyboardState aKeyboardState = Keyboard.GetState();
            switch (mCurrentScreen)
            {

                case Screen.Title:
                    {
                        // Enter key = launch the game
                        if (aKeyboardState.IsKeyDown(Keys.Enter) == true)
                        {
                            mCurrentScreen = Screen.Main;
                            
                        }
                        break;
                    }
                case Screen.Main:
                    {
                        // Escape key = pause the game
                        if (aKeyboardState.IsKeyDown(Keys.Escape) == true)
                        {
                            mCurrentScreen = Screen.Menu;
                        }
                        break;
                    }
                case Screen.Inventory:
                    {
                        // C key in the Inventory = close it
                        if (aKeyboardState.IsKeyDown(Keys.C) == true)
                        {
                            mCurrentScreen = Screen.Main;
                        }
                        break;
                    }
                case Screen.Menu:
                    {
                        // Move the currently highlighted menu option
                        if (aKeyboardState.IsKeyDown(Keys.Down) == true && mPreviousKeyboardState.IsKeyDown(Keys.Down) == false)
                        {
                            // Move selection down
                            switch (mCurrentMenuOption)
                            {
                                case MenuOptions.Resume:
                                    {
                                        mCurrentMenuOption = MenuOptions.Inventory;
                                        break;
                                    }
                                case MenuOptions.Inventory:
                                    {
                                        mCurrentMenuOption = MenuOptions.ExitGame;
                                        break;
                                    }
                            }

                        }

                        if (aKeyboardState.IsKeyDown(Keys.Up) == true && mPreviousKeyboardState.IsKeyDown(Keys.Up) == false)
                        {
                            // Move selection up
                            switch (mCurrentMenuOption)
                            {
                                case MenuOptions.Inventory:
                                    {
                                        mCurrentMenuOption = MenuOptions.Resume;
                                        break;
                                    }
                                case MenuOptions.ExitGame:
                                    {
                                        mCurrentMenuOption = MenuOptions.Inventory;
                                        break;
                                    }
                            }
                        }

                        // In the menu, X key = validate
                        if (aKeyboardState.IsKeyDown(Keys.X) == true)
                        {
                            switch (mCurrentMenuOption)
                            {
                                // Return to the Main game screen and close the menu
                                case MenuOptions.Resume:
                                    {
                                        mCurrentScreen = Screen.Main;
                                        break;
                                    }
                                // Open the Inventory screen wich doesn't exist...
                                case MenuOptions.Inventory:
                                    {
                                        mCurrentScreen = Screen.Inventory;
                                        break;
                                    }
                                // Exit the game
                                case MenuOptions.ExitGame:
                                    {
                                        this.Exit();
                                        break;
                                    }
                            }
                            // Reset the selected menu option to Resume
                            mCurrentMenuOption = MenuOptions.Resume;
                        }
                        break;
                    }
            }
            // Store the Keyboard state
            mPreviousKeyboardState = aKeyboardState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (mCurrentScreen)
            {
                case Screen.Title:
                    {
                        spriteBatch.Draw(mTitleScreen, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.White);
                        break;
                    }

                case Screen.Menu:
                    {
                        spriteBatch.Draw(mMenu, new Rectangle(this.Window.ClientBounds.Width / 2 - mMenu.Width / 2, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2, mMenu.Width, mMenu.Height), Color.White);

                        switch (mCurrentMenuOption)
                        {
                            case MenuOptions.Resume:
                                {
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 50, 250, 50), new Rectangle(0, 0, 250, 50), Color.Gold);
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 100, 250, 50), new Rectangle(0, 50, 250, 50), Color.White);
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 150, 250, 50), new Rectangle(0, 100, 250, 50), Color.White);
                                    break;
                                }

                            case MenuOptions.Inventory:
                                {
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 50, 250, 50), new Rectangle(0, 0, 250, 50), Color.White);
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 100, 250, 50), new Rectangle(0, 50, 250, 50), Color.Gold);
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 150, 250, 50), new Rectangle(0, 100, 250, 50), Color.White);
                                    break;
                                }

                            case MenuOptions.ExitGame:
                                {
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 50, 250, 50), new Rectangle(0, 0, 250, 50), Color.White);
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 100, 250, 50), new Rectangle(0, 50, 250, 50), Color.White);
                                    spriteBatch.Draw(mMenuOptions, new Rectangle(this.Window.ClientBounds.Width / 2 - 100, this.Window.ClientBounds.Height / 2 - mMenu.Height / 2 + 150, 250, 50), new Rectangle(0, 100, 250, 50), Color.Gold);
                                    break;
                                }
                        }
                        break;
                    }
                case Screen.Inventory:
                    {
                        spriteBatch.Draw(mInventoryScreen, new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height), Color.White);
                        break;
                    }
            }
        }
    }
}
