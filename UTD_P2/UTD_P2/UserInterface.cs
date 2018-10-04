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
    /// <summary>
    /// Used to Display Life and Money
    /// </summary>
    class UserInterface
    {
        private Texture2D number0, number1, number2, number3, number4, number5, number6, number7, number8, number9, currencySymbol,
            onesDisplay, tensDisplay, hundredsDisplay, thousandsDisplay, onesDispayLives, tensDisplayLives, heartSymbol;

        private Vector2 posOnes, posTens, posHundreds, posThousands, posCurrency, posOnesLives, posTensLives, posHeart;

        private string rootPath = "Content/Assets/TD/UI/";

        Player player;

        public UserInterface(GraphicsDevice graphicsDevice, Player player)
        {
            this.player = player;

            number0 = ContentConverter.Convert(rootPath + "number0.png", graphicsDevice);
            number1 = ContentConverter.Convert(rootPath + "number1.png", graphicsDevice);
            number2 = ContentConverter.Convert(rootPath + "number2.png", graphicsDevice);
            number3 = ContentConverter.Convert(rootPath + "number3.png", graphicsDevice);
            number4 = ContentConverter.Convert(rootPath + "number4.png", graphicsDevice);
            number5 = ContentConverter.Convert(rootPath + "number5.png", graphicsDevice);
            number6 = ContentConverter.Convert(rootPath + "number6.png", graphicsDevice);
            number7 = ContentConverter.Convert(rootPath + "number7.png", graphicsDevice);
            number8 = ContentConverter.Convert(rootPath + "number8.png", graphicsDevice);
            number9 = ContentConverter.Convert(rootPath + "number9.png", graphicsDevice);
            currencySymbol = ContentConverter.Convert(rootPath + "currencySymbol.png", graphicsDevice);
            heartSymbol = ContentConverter.Convert(rootPath + "heart.png", graphicsDevice);
			onesDisplay = tensDisplay = hundredsDisplay = thousandsDisplay = number0;
            onesDispayLives = tensDisplayLives = number0;

			posThousands = new Vector2(number0.Width, 0);
			posHundreds = new Vector2(number0.Width / 2, 0) + posThousands;
			posTens = new Vector2(number0.Width / 2, 0) + posHundreds;
			posOnes = new Vector2(number0.Width / 2, 0) + posTens;
            posCurrency = new Vector2(number0.Width / 2, 0) + posOnes;

            posHeart = new Vector2(1920 - number0.Width, 0);
            posOnesLives = posHeart - new Vector2(number0.Width, 0);
            posTensLives = posOnesLives - new Vector2(number0.Width / 2, 0);
		}

        public void Update(GameTime gameTime)
        {
			CalcMoney(player.money);
            CalcLives(player.life);
        }

        private void CalcLives(int life)
        {
            CalcTensLive(life);
        }

        /// <summary>
        /// Calculates which Texture to Display based on the current Life, Zehner Stelle
        /// </summary>
        /// <param name="life"></param>
        private void CalcTensLive(int life)
        {
            if (life >= 30)
            {
                tensDisplayLives = number3;
                CalcOnesLive(life - 30);
            }

            else if (life >= 20)
            {
                tensDisplayLives = number2;
                CalcOnesLive(life - 20);
            }

            else if (life >= 10)
            {
                tensDisplayLives = number1;
                CalcOnesLive(life - 10);
            }

            else if (life < 10)
            {
                tensDisplayLives = number0;
                CalcOnesLive(life);
            }
        }

        /// <summary>
        /// Calculates which Texture to Display based on the current Life, Einser Stelle
        /// </summary>
        /// <param name="life"></param>
        private void CalcOnesLive(int life)
        {
            switch (life)
            {
                case 9:
                    onesDispayLives = number9;
                    break;
                case 8:
                    onesDispayLives = number8;
                    break;
                case 7:
                    onesDispayLives = number7;
                    break;
                case 6:
                    onesDispayLives = number6;
                    break;
                case 5:
                    onesDispayLives = number5;
                    break;
                case 4:
                    onesDispayLives = number4;
                    break;
                case 3:
                    onesDispayLives = number3;
                    break;
                case 2:
                    onesDispayLives = number2;
                    break;
                case 1:
                    onesDispayLives = number1;
                    break;
                case 0:
                    onesDispayLives = number0;
                    break;
            }
        }

        /// <summary>
        /// Calculates which Texture to Display based on the current Money
        /// </summary>
        /// <param name="curMoney"></param>
        private void CalcMoney(int curMoney)
		{
			if (curMoney < 10)
			{
				tensDisplay = hundredsDisplay = thousandsDisplay = number0;
				CalcOnes(curMoney);
			}

			if (curMoney >= 10 && curMoney < 100)
			{
				hundredsDisplay = thousandsDisplay = number0;
				CalcTens(curMoney);
			}

			if (curMoney >= 100 && curMoney < 1000)
			{
				thousandsDisplay = number0;
				CalcHundreds(curMoney);
			}

			if (curMoney >= 1000)
			{
				thousandsDisplay = number1;
				CalcHundreds(curMoney - 1000);
			}
		}

        /// <summary>
        /// Calculates which Texture to Display based on the current Money, hunderter Stelle
        /// </summary>
        /// <param name="curMoney"></param>
		private void CalcHundreds(int curMoney)
		{
			if (curMoney >= 900)
			{
				hundredsDisplay = number9;
				CalcTens(curMoney - 900);
			}

			else if (curMoney >= 800)
			{
				hundredsDisplay = number8;
				CalcTens(curMoney - 800);
			}

			else if (curMoney >= 700)
			{
				hundredsDisplay = number7;
				CalcTens(curMoney - 700);
			}

			else if (curMoney >= 600)
			{
				hundredsDisplay = number6;
				CalcTens(curMoney - 600);
			}

			else if (curMoney >= 500)
			{
				hundredsDisplay = number5;
				CalcTens(curMoney - 500);
			}

			else if (curMoney >= 400)
			{
				hundredsDisplay = number4;
				CalcTens(curMoney - 400);
			}

			else if (curMoney >= 300)
			{
				hundredsDisplay = number3;
				CalcTens(curMoney - 300);
			}

			else if (curMoney >= 200)
			{
				hundredsDisplay = number2;
				CalcTens(curMoney - 200);
			}

			else if (curMoney >= 100)
			{
				hundredsDisplay = number1;
				CalcTens(curMoney - 100);
			}

			else if (curMoney < 100)
			{
				hundredsDisplay = number0;
				CalcTens(curMoney);
			}
		}

        /// <summary>
        /// Calculates which Texture to Display based on the current Money, zehner Stelle
        /// </summary>
        /// <param name="curMoney"></param>
		private void CalcTens(int curMoney)
		{
			if (curMoney >= 90)
			{
				tensDisplay = number9;
				CalcOnes(curMoney - 90);
			}

			else if (curMoney >= 80)
			{
				tensDisplay = number8;
				CalcOnes(curMoney - 80);
			}

			else if (curMoney >= 70)
			{
				tensDisplay = number7;
				CalcOnes(curMoney - 70);
			}

			else if  (curMoney >= 60)
			{
				tensDisplay = number6;
				CalcOnes(curMoney - 60);
			}

			else if (curMoney >= 50)
			{
				tensDisplay = number5;
				CalcOnes(curMoney - 50);
			}

			else if (curMoney >= 40)
			{
				tensDisplay = number4;
				CalcOnes(curMoney - 40);
			}

			else if (curMoney >= 30)
			{
				tensDisplay = number3;
				CalcOnes(curMoney - 30);
			}

			else if (curMoney >= 20)
			{
				tensDisplay = number2;
				CalcOnes(curMoney - 20);
			}

			else if (curMoney >= 10)
			{
				tensDisplay = number1;
				CalcOnes(curMoney - 10);
			}

			else if (curMoney < 10)
			{
				tensDisplay = number0;
				CalcOnes(curMoney);
			}
		}

        /// <summary>
        /// Calculates which Texture to Display based on the current Money, einser Stelle
        /// </summary>
        /// <param name="curMoney"></param>
		private void CalcOnes(int curMoney)
		{
			switch (curMoney)
			{
				case 9:
					onesDisplay = number9;
					break;
				case 8:
					onesDisplay = number8;
					break;
				case 7:
					onesDisplay = number7;
					break;
				case 6:
					onesDisplay = number6;
					break;
				case 5:
					onesDisplay = number5;
					break;
				case 4:
					onesDisplay = number4;
					break;
				case 3:
					onesDisplay = number3;
					break;
				case 2:
					onesDisplay = number2;
					break;
				case 1:
					onesDisplay = number1;
					break;
				case 0:
					onesDisplay = number0;
					break;
			}
		}

        public void Draw(SpriteBatch spriteBatch)
        {
			spriteBatch.Draw(thousandsDisplay, posThousands, new Rectangle(0, 0, thousandsDisplay.Width, thousandsDisplay.Height), Color.White);
			spriteBatch.Draw(hundredsDisplay, posHundreds, new Rectangle(0, 0, hundredsDisplay.Width, hundredsDisplay.Height), Color.White);
			spriteBatch.Draw(tensDisplay, posTens, new Rectangle(0, 0, tensDisplay.Width, tensDisplay.Height), Color.White);
			spriteBatch.Draw(onesDisplay, posOnes, new Rectangle(0, 0, onesDisplay.Width, onesDisplay.Height), Color.White);
            spriteBatch.Draw(currencySymbol, posCurrency, new Rectangle(0, 0, currencySymbol.Width, currencySymbol.Height), Color.White);

            spriteBatch.Draw(heartSymbol, posHeart, new Rectangle(0, 0, heartSymbol.Width, heartSymbol.Height), Color.White);
            spriteBatch.Draw(tensDisplayLives, posTensLives, new Rectangle(0, 0, tensDisplayLives.Width, tensDisplayLives.Height), Color.White);
            spriteBatch.Draw(onesDispayLives, posOnesLives, new Rectangle(0, 0, onesDispayLives.Width, onesDispayLives.Height), Color.White);
		}
    }
}
