﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
    class UIButton : Button
    {
        BuildButton buildButton;
        Texture2D singleShotTexture, singleShotUITexture, doubleShotTexture, doubleShotUITexture, slowTexture, slowUITexture,
            rocketLauncherTexture, rocketLauncherUITexture, displayTexture;
        private string singleShotPath = "";
        private string singleShotUIPath = "";
        private string doubleShotPath = "";
        private string doubleShotUIPath = "";
        private string slowPath = "";
        private string slowUIPath = "";
        private string rocketLauncherPath = "";
        private string rocketLauncherUIPath = "";

        private bool affordable = false;

        TowerTypes towerType;

        KeyboardState previousKBState, currentKBState;

        private Player player;

        public UIButton(int buttonX, int buttonY, BuildButton buildButton, GraphicsDevice graphicsDevice, Player player)
        {
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.buildButton = buildButton;
            this.player = player;

            singleShotTexture = ContentConverter.Convert(singleShotPath, graphicsDevice);
            singleShotUITexture = ContentConverter.Convert(singleShotUIPath, graphicsDevice);
            doubleShotTexture = ContentConverter.Convert(doubleShotPath, graphicsDevice);
            doubleShotUITexture = ContentConverter.Convert(doubleShotUIPath, graphicsDevice);
            slowTexture = ContentConverter.Convert(slowPath, graphicsDevice);
            slowUITexture = ContentConverter.Convert(slowUIPath, graphicsDevice);
            rocketLauncherTexture = ContentConverter.Convert(rocketLauncherPath, graphicsDevice);
            rocketLauncherUITexture = ContentConverter.Convert(rocketLauncherUIPath, graphicsDevice);

            towerType = TowerTypes.Single;
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
                    else
                    {
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

                        displayTexture = singleShotUITexture;
                    }
                    break;
                case TowerTypes.Double:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Slow;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Single;
                    else
                    {
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

                        displayTexture = doubleShotUITexture;
                    }
                    break;
                case TowerTypes.Slow:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Rocket;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Double;
                    else
                    {
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

                        displayTexture = slowUITexture;
                    }
                    break;
                case TowerTypes.Rocket:
                    if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Right)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.D))
                        towerType = TowerTypes.Slow;
                    else if (InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.Left)
                        || InputManager.CheckInputKeyboard(previousKBState, currentKBState, Keys.A))
                        towerType = TowerTypes.Single;
                    else
                    {
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

                        displayTexture = rocketLauncherUITexture;
                    }
                    break;
            }

            previousKBState = currentKBState;
            base.Update(gameTime);
        }

        protected override void OnButtonClick()
        {
            switch (towerType)
            {
                case TowerTypes.Single:
                    SingleShotTower newSingleShotTower = new SingleShotTower(singleShotTexture, buildButton.ButtonX, buildButton.ButtonY);
                    //add to Tower List in Level class and subtract value from player money
                    break;
                case TowerTypes.Double:
                    DoubleShotTower newDoubleShotTower = new DoubleShotTower(doubleShotTexture, buildButton.ButtonX, buildButton.ButtonY);
                    //add to Tower List in Level class and substract value from player money
                    break;
                case TowerTypes.Slow:
                    SlowTower newSlowTower = new SlowTower(slowTexture, buildButton.ButtonX, buildButton.ButtonY);
                    //add to Tower List in Level class and substract value from player money
                    break;
                case TowerTypes.Rocket:
                    RocketLauncherTower newRocketLauncherTower = new RocketLauncherTower(rocketLauncherTexture, buildButton.ButtonX, buildButton.ButtonY);
                    //add to Tower List in Level class and substract value from player money
                    break;
            }
        }

        protected override void OnButtonClickMenu(MainMenu mainMenu)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}