using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

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
        pri

        public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
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
            mainMenuBackground = PNGConverter("Content/Assets/TD/Sample.png");
            mainMenuStartButton = PNGConverter("Content/Assets/TD/PNG/Default/towerDefense_tile001.png");
            mainMenuQuitButton = PNGConverter("Content/Assets/TD/PNG/Default/towerDefense_tile002.png");
            // TODO: use this.Content to load your game content here
            mainMenu = new MainMenu(mainMenuBackground, mainMenuStartButton, mainMenuQuitButton);
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
                UpdateMainMenu();

            if (level.isActive)
                UpdateLevel();


			// TODO: Add your update logic here

			base.Update(gameTime);
		}

        private void UpdateLevel()
        {
            throw new NotImplementedException();
        }

        private void UpdateMainMenu()
        {
            throw new NotImplementedException();
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
            
			base.Draw(gameTime);
            spriteBatch.End();
		}
	}
}
