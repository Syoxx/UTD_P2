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

        public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
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

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
            mainMenuBackground = ContentConverter.Convert("Content/Assets/MenuButtons/Background.jpg", GraphicsDevice);
            mainMenuStartButton = ContentConverter.Convert("Content/Assets/MenuButtons/MenuStart.png", GraphicsDevice);
            mainMenuQuitButton = ContentConverter.Convert("Content/Assets/MenuButtons/MenuQuit.png", GraphicsDevice);
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
            
			base.Draw(gameTime);
            spriteBatch.End();
		}
	}
}
