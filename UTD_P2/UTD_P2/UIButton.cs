using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
    public class UIButton : Button
    {
        BuildButton buildButton;
        Texture2D singleShotTexture, singleShotUITexture, doubleShotTexture, doubleShotUITexture, slowTexture, slowUITexture,
            rocketLauncherTexture, rocketLauncherUITexture;
        private string singleShotPath = "Content/Assets/TD/Towers/singleShot.png";
        private string singleShotUIPath = "Content/Assets/TD/UI/Towers/singleShot.png";
        private string doubleShotPath = "Content/Assets/TD/Towers/doubleShot.png";
        private string doubleShotUIPath = "Content/Assets/TD/UI/Towers/doubleShot.png";
        private string slowPath = "Content/Assets/TD/Towers/slow.png";
        private string slowUIPath = "Content/Assets/TD/UI/Towers/slow.png";
        private string rocketLauncherPath = "Content/Assets/TD/Towers/rocketLauncher.png";
        private string rocketLauncherUIPath = "Content/Assets/TD/UI/Towers/rocketLauncher.png";

        private bool affordable = false;

        TowerTypes towerType;

        KeyboardState previousKBState, currentKBState;

        private Player player;

        private Level level;

        public UIButton(int buttonX, int buttonY, BuildButton buildButton, GraphicsDevice graphicsDevice, Player player, Level level)
        {
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.buildButton = buildButton;
            this.player = player;
            this.level = level;

            singleShotTexture = ContentConverter.Convert(singleShotPath, graphicsDevice);
            singleShotUITexture = ContentConverter.Convert(singleShotUIPath, graphicsDevice);
            doubleShotTexture = ContentConverter.Convert(doubleShotPath, graphicsDevice);
            doubleShotUITexture = ContentConverter.Convert(doubleShotUIPath, graphicsDevice);
            slowTexture = ContentConverter.Convert(slowPath, graphicsDevice);
            slowUITexture = ContentConverter.Convert(slowUIPath, graphicsDevice);
            rocketLauncherTexture = ContentConverter.Convert(rocketLauncherPath, graphicsDevice);
            rocketLauncherUITexture = ContentConverter.Convert(rocketLauncherUIPath, graphicsDevice);

            towerType = TowerTypes.Single;
            //texture = singleShotTexture;
        }

        private enum TowerTypes
        {
            Single,
            Double,
            Slow,
            Rocket
        }

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

                    if (player.money > 5)
                    {
                        affordable = true;
                        currentColor = Color.White;
                    }

                    else
                    {
                        affordable = false;
                        currentColor = Color.Red;
                    }

 
                    texture = singleShotUITexture;
                    break;

                case TowerTypes.Double:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Slow;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Single;

                    if (player.money > 10)
                        {
                            affordable = true;
                            currentColor = Color.White;
                        }

                    else
                    {
                        affordable = false;
                        currentColor = Color.Red;
                    }

                    texture = doubleShotUITexture;
                    break;

                case TowerTypes.Slow:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Rocket;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Double;
                    if (player.money > 15)
                        {
                            affordable = true;
                            currentColor = Color.White;
                        }
                
                    else
                        {
                            affordable = false;
                            currentColor = Color.Red;
                        }

                    texture = slowUITexture;
                    break;

                case TowerTypes.Rocket:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Single;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Slow;

                    if (player.money > 20)
                    {
                        affordable = true;
                        currentColor = Color.White;
                    }

                    else
                    {
                        affordable = false;
                        currentColor = Color.Red;
                    }

                    texture = rocketLauncherUITexture;
                    break;
            }

            previousKBState = currentKBState;
            buttonX = 960 - texture.Width / 2;
            buttonY = 540 - texture.Height / 2;
            base.Update(gameTime);
        }

        protected override void OnButtonClick()
        {
            switch (towerType)
            {
                case TowerTypes.Single:
                    SingleShotTower newSingleShotTower = new SingleShotTower(singleShotTexture, buildButton.ButtonX, buildButton.ButtonY, player);
                    level.AddTower(newSingleShotTower, this);
                    break;
                case TowerTypes.Double:
                    DoubleShotTower newDoubleShotTower = new DoubleShotTower(doubleShotTexture, buildButton.ButtonX, buildButton.ButtonY, player);
                    level.AddTower(newDoubleShotTower, this);
                    break;
                case TowerTypes.Slow:
                    SlowTower newSlowTower = new SlowTower(slowTexture, buildButton.ButtonX, buildButton.ButtonY, player);
                    level.AddTower(newSlowTower, this);
                    break;
                case TowerTypes.Rocket:
                    RocketLauncherTower newRocketLauncherTower = new RocketLauncherTower(rocketLauncherTexture, buildButton.ButtonX, buildButton.ButtonY, player);
                    level.AddTower(newRocketLauncherTower, this);
                    break;
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
            base.Draw(spriteBatch);
        }
    }
}
