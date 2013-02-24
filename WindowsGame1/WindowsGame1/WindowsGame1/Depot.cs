/*
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
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        bool test = true;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            byte[] data;
            string message = "";/*
            if (Keyboard.GetState().IsKeyDown(Keys.Z))//Up
            {
                message = message + '1';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))//Down
            {
                message = message + '2';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Q))//Right
            {
                message = message + '3';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))//Left
            {
                message = message + '4';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))//Tir
            {
                message = message + '5';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.E))//Pose
            {
                message = message + '6';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.R))//Bombe
            {
                message = message + '7';
            }
            data = Encoding.Default.GetBytes(message);

            UdpClient udpClient = new UdpClient();
            udpClient.Send(data, data.Length, "127.0.0.1", 1337);
            udpClient.Close();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);


            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            byte[] data;
            string message = "";/*
            if (Keyboard.GetState().IsKeyDown(Keys.Z))//Up
            {
                message = message + '1';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))//Down
            {
                message = message + '2';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Q))//Right
            {
                message = message + '3';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))//Left
            {
                message = message + '4';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))//Tir
            {
                message = message + '5';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.E))//Pose
            {
                message = message + '6';
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.R))//Bombe
            {
                message = message + '7';
            }
            data = Encoding.Default.GetBytes(message);

            UdpClient udpClient = new UdpClient();
            udpClient.Send(data, data.Length, "127.0.0.1", 1337);
            udpClient.Close();

        }
    }
}
*/