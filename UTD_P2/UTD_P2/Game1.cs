﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UTD_P2
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

        private Texture2D mainMenuBackground;
        private Texture2D mainMenuStartButton;
        private Texture2D mainMenuQuitButton;
        private MainMenu mainMenu;

        Level1 level1 = new Level1();
        Level2 level2 = new Level2();
        Level3 level3 = new Level3();

        private Texture2D lvlBackground;
        private Texture2D lvlTile1;
        private Texture2D lvlTile2;
        private Texture2D lvlTile3;
        private Texture2D lvlTile4;

        private Texture2D lvlOneWalls;
        private Texture2D lvlTwoWalls;
        private Texture2D lvlThreeWalls;

        public Game1()
		{
			graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;

            this.IsMouseVisible = true;
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

        private Texture2D PNGConverter(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Texture2D returnTexture = Texture2D.FromStream(GraphicsDevice, fileStream);
            fileStream.Dispose();
            return returnTexture;
        }

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

            mainMenuBackground = PNGConverter("Content/Assets/MenuButtons/Background.jpg");
            mainMenuStartButton = PNGConverter("Content/Assets/MenuButtons/MenuStart.png");
            mainMenuQuitButton = PNGConverter("Content/Assets/MenuButtons/MenuQuit.png");

            mainMenu = new MainMenu(mainMenuBackground, mainMenuStartButton, mainMenuQuitButton);


            // Level content loader

            // Implement pngconverter of level tiles here
            lvlBackground = PNGConverter("Content/Assets/TD/blablabla.png");
            lvlTile1 = PNGConverter("Content/Assets/TD/blablabla1.png");
            lvlTile2 = PNGConverter("Content/Assets/TD/blablabla2.png");
            lvlTile3 = PNGConverter("Content/Assets/TD/blablabla3.png");
            lvlTile4 = PNGConverter("Content/Assets/TD/blablabla4.png");

            lvlOneWalls = PNGConverter("Content/Assets/TD/blablabla50.png");
            lvlTwoWalls = PNGConverter("Content/Assets/TD/blablabla60.png");
            lvlThreeWalls = PNGConverter("Content/Assets/TD/blablabla70.png");

            // Example
            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");

            level1.AddTexture(grass);
            level1.AddTexture(path);



            // TODO: use this.Content to load your game content here
           
        }

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
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
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

            if (mainMenu.isActive)
                UpdateMainMenu(gameTime);

            //if (level.isActive)
            //    UpdateLevel(gameTime);


			// TODO: Add your update logic here

			base.Update(gameTime);
		}

        private void UpdateLevel(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        private void UpdateMainMenu(GameTime gameTime)
        {
            mainMenu.Update(gameTime, this);
        }

        public void Quit()
        {
            this.Exit();
        }

        public void LoadLevel(int i)
        {
            //loadLevel with i
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            mainMenu.Draw(gameTime, spriteBatch);
            level1.Draw(spriteBatch);
           
            spriteBatch.End();

            base.Draw(gameTime);
        }
	}
}
