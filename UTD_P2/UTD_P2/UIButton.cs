using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
    /// <summary>
    /// Implements the Button for the Build dialogue
    /// </summary>
    public class UIButton : Button
    {
        BuildButton buildButton;
        Texture2D singleShotTexture, singleShotUITexture, doubleShotTexture, doubleShotUITexture, slowTexture, slowUITexture,
            rocketLauncherTexture, rocketLauncherUITexture, towerBuild, rangeIndicator;
        private string singleShotPath = "Content/Assets/TD/Towers/singleShot.png";
        private string singleShotUIPath = "Content/Assets/TD/UI/Towers/SingleShotTower.png";
        private string doubleShotPath = "Content/Assets/TD/Towers/doubleShot.png";
        private string doubleShotUIPath = "Content/Assets/TD/UI/Towers/DoubleShotTower.png";
        private string slowPath = "Content/Assets/TD/Towers/slow.png";
        private string slowUIPath = "Content/Assets/TD/UI/Towers/SlowTower.png";
        private string rocketLauncherPath = "Content/Assets/TD/Towers/rocketLauncher.png";
        private string rocketLauncherUIPath = "Content/Assets/TD/UI/Towers/RocketLauncherTower.png";

        private bool affordable = false;

        TowerTypes towerType;

        KeyboardState previousKBState, currentKBState;

        private Player player;

        private Level level;

        private GraphicsDevice graphicsDevice;

		private Vector2 centerPositionTower, centerPositionCircle;

        public UIButton(int buttonX, int buttonY, BuildButton buildButton, GraphicsDevice graphicsDevice, Player player, Level level)
        {
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.buildButton = buildButton;
            this.player = player;
            this.level = level;
            this.graphicsDevice = graphicsDevice;
			centerPositionTower = new Vector2(buttonX, buttonY) + new Vector2(buildButton.Texture.Width / 2, buildButton.Texture.Height / 2);

            singleShotTexture = ContentConverter.Convert(singleShotPath, graphicsDevice);
            singleShotUITexture = ContentConverter.Convert(singleShotUIPath, graphicsDevice);
            doubleShotTexture = ContentConverter.Convert(doubleShotPath, graphicsDevice);
            doubleShotUITexture = ContentConverter.Convert(doubleShotUIPath, graphicsDevice);
            slowTexture = ContentConverter.Convert(slowPath, graphicsDevice);
            slowUITexture = ContentConverter.Convert(slowUIPath, graphicsDevice);
            rocketLauncherTexture = ContentConverter.Convert(rocketLauncherPath, graphicsDevice);
            rocketLauncherUITexture = ContentConverter.Convert(rocketLauncherUIPath, graphicsDevice);
            towerBuild = ContentConverter.Convert("Content/Assets/TD/UI/towerBuild.png", graphicsDevice);

            towerType = TowerTypes.Single;
            //texture = singleShotTexture;
        }

        /// <summary>
        /// defines all Tower types
        /// </summary>
        private enum TowerTypes
        {
            Single,
            Double,
            Slow,
            Rocket
        }

        /// <summary>
        /// sets the Texture that should be displayed according to the Tower Type, handles Keyboard input to change the displayed Tower
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            currentKBState = Keyboard.GetState();
            switch (towerType)
            {
                case TowerTypes.Single:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Double;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Rocket;

                    if (player.money >= 5)
                    {
                        affordable = true;
                        currentColor = Color.White;
                    }

                    else if (player.money < 5)
                    {
                        affordable = false;
                        currentColor = Color.Red;
                    }

					rangeIndicator = DrawCircle.createCircleText(200 * 2, Color.Red, graphicsDevice);
                    texture = singleShotUITexture;
                    break;

                case TowerTypes.Double:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Slow;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Single;

                    if (player.money >= 10)
                        {
                            affordable = true;
                            currentColor = Color.White;
                        }

                    else
                    {
                        affordable = false;
                        currentColor = Color.Red;
                    }

					rangeIndicator = DrawCircle.createCircleText(200 * 2, Color.Red, graphicsDevice);
					texture = doubleShotUITexture;
                    break;

                case TowerTypes.Slow:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Rocket;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Double;
                    if (player.money >= 15)
                        {
                            affordable = true;
                            currentColor = Color.White;
                        }
                
                    else
                        {
                            affordable = false;
                            currentColor = Color.Red;
                        }

					rangeIndicator = DrawCircle.createCircleText(300 * 2, Color.Red, graphicsDevice);
					texture = slowUITexture;
                    break;

                case TowerTypes.Rocket:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Single;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Slow;

                    if (player.money >= 20)
                    {
                        affordable = true;
                        currentColor = Color.White;
                    }

                    else if (player.money < 20)
                    {
                        affordable = false;
                        currentColor = Color.Red;
                    }

					rangeIndicator = DrawCircle.createCircleText(300 * 2, Color.Red, graphicsDevice);
					texture = rocketLauncherUITexture;
                    break;
            }

            previousKBState = currentKBState;
            buttonX = 960 - texture.Width / 2;
            buttonY = 540 - texture.Height / 2;
			centerPositionCircle = centerPositionTower - new Vector2(rangeIndicator.Width / 2, rangeIndicator.Height / 2);
            base.Update(gameTime);
        }

        /// <summary>
        /// If clicked, creates an object of the ordered Tower
        /// </summary>
        protected override void OnButtonClick()
        {
            if (affordable)
            {
                buildButton.Texture = towerBuild;
                buildButton.allowBuilding = false;
                switch (towerType)
                {
                    case TowerTypes.Single:
                        SingleShotTower newSingleShotTower = new SingleShotTower(singleShotTexture, buildButton.ButtonX, buildButton.ButtonY, player, graphicsDevice);
                        level.AddTower(newSingleShotTower, this);
                        break;
                    case TowerTypes.Double:
                        DoubleShotTower newDoubleShotTower = new DoubleShotTower(doubleShotTexture, buildButton.ButtonX, buildButton.ButtonY, player, graphicsDevice);
                        level.AddTower(newDoubleShotTower, this);
                        break;
                    case TowerTypes.Slow:
                        SlowTower newSlowTower = new SlowTower(slowTexture, buildButton.ButtonX, buildButton.ButtonY, player, graphicsDevice);
                        level.AddTower(newSlowTower, this);
                        break;
                    case TowerTypes.Rocket:
                        RocketLauncherTower newRocketLauncherTower = new RocketLauncherTower(rocketLauncherTexture, buildButton.ButtonX, buildButton.ButtonY, player, graphicsDevice);
                        level.AddTower(newRocketLauncherTower, this);
                        break;
                }
            }
            //change buildButton behaviour to disable building new towers
        }

        protected override void OnButtonClickMenu(MainMenu mainMenu)
        {
            throw new NotImplementedException();
        }

        protected override void OnButtonClickMenu(Game1 game)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
			if (rangeIndicator != null)
				spriteBatch.Draw(rangeIndicator, centerPositionCircle, Color.White);
            base.Draw(spriteBatch);
        }
    }
}
