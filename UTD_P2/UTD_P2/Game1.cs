using Microsoft.Xna.Framework;
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
        private PauseMenu pauseMenu;
        public bool gamePaused;
        private KeyboardState currentState, oldState;
        
        bool isLevelActive = false;

        private Level level;

        private Enemy enemy1;
        



        public Game1()
		{
			graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            //graphics.IsFullScreen = true;

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

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

            mainMenuBackground = ContentConverter.Convert("Content/Assets/Menu/Background.jpg", GraphicsDevice);
            mainMenuStartButton = ContentConverter.Convert("Content/Assets/Menu/PlayButton.png", GraphicsDevice);
            mainMenuQuitButton = ContentConverter.Convert("Content/Assets/Menu/QuitButton.png", GraphicsDevice);

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
            currentState = Keyboard.GetState();

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            if (mainMenu != null)
            {
                if (mainMenu.isActive)
                    UpdateMainMenu(gameTime);
            }
            
            if (level != null)
            {
                if (!gamePaused && level.isActive)
                    UpdateLevel(gameTime);

            }
                if (InputManager.CheckInputKeyboard(oldState, currentState, Keys.Escape) && !gamePaused && level.isActive)
                    gamePaused = true;

                else if (InputManager.CheckInputKeyboard(oldState, currentState, Keys.Escape) && gamePaused && level.isActive)
                    gamePaused = false;

                if (gamePaused)
                    UpdatePauseMenu(gameTime);
            }

            oldState = currentState;
			base.Update(gameTime);
        }

        private void UpdatePauseMenu(GameTime gameTime)
        {
            if (pauseMenu == null)
                pauseMenu = new PauseMenu(this, GraphicsDevice);

            else
                pauseMenu.Update(gameTime);
        }

        private void UpdateLevel(GameTime gameTime)
        {
            level.Update(gameTime);
        }

        /// <summary>
        /// Updates main menu
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateMainMenu(GameTime gameTime)
        {
            mainMenu.Update(gameTime, this);
        }

        /// <summary>
        /// Quit the application
        /// </summary>
        public void Quit()
        {
            this.Exit();
        }

        /// <summary>
        /// Load level and their contents
        /// </summary>
        /// <param name="i"></param>
        public void LoadLevel(int i)
        {
            if(i == 1)
            {
                level = new Level(Level.MapState.map1, GraphicsDevice);
            }
            else if(i == 2)
            {
                level = new Level(Level.MapState.map2, GraphicsDevice);
            }
            else if(i == 3)
            {
                level = new Level(Level.MapState.map3, GraphicsDevice);
            }
        }

        public void SetMainMenuActive(bool isActive)
        {
            if (isActive)
            {
                level.isActive = false;
                level = null;
                gamePaused = false;
                mainMenu.isActive = true;
            }
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
            if (mainMenu != null)
            {
                if (mainMenu.isActive)
                    mainMenu.Draw(gameTime, spriteBatch);
            }

            if (level != null)
            {
                if (level.isActive)
                {
                    level.Draw(spriteBatch);
                }

                if (gamePaused)
                    pauseMenu.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
