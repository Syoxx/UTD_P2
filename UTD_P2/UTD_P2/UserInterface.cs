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
    class UserInterface
    {
        private Texture2D number0, number1, number2, number3, number4, number5, number6, number7, number8, number9, currencySymbol,
            onesDisplay, tensDisplay, hundredsDisplay, thousandsDisplay;

        private Vector2 posOnes, posTens, posHundreds, posThousands;

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
        }

        public void Update(GameTime gameTime)
        {
            if (player.money < 10)
            {
                tensDisplay = hundredsDisplay = thousandsDisplay = number0;
            }

            if (player.money < 100)
            {
                hundredsDisplay = thousandsDisplay = number0;
            }

            if (player.money < 1000)
            {
                thousandsDisplay = number0;
            }

            if (player.money > 1000)
            {
                thousandsDisplay = number1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
