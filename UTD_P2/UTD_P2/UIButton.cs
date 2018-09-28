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
    class UIButton : Button
    {
        public UIButton(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.name = name;
            this.texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void OnButtonClick()
        {
            throw new NotImplementedException();
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
