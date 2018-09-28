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
    class MenuButton : Button
    {
        public MenuButton(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.name = name;
            this.texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }

        public override void Update(GameTime gameTime, MainMenu mainMenu)
        {
            base.Update(gameTime, mainMenu);
        }

        protected override void OnButtonClick()
        {
            throw new NotImplementedException();
        }

        protected override void OnButtonClickMenu(MainMenu mainMenu)
        {
            switch (name)
            {
                case "startGame":
                    mainMenu.StartGame();
                    break;
                case "quitGame":
                    mainMenu.ExitGame();
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
