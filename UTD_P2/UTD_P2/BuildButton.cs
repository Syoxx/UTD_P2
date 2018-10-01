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
    class BuildButton : Button
    {
        Vector2 uIButtonPos;
        UIButton uIButton;
        GraphicsDevice graphicsDevice;
        Player player;
        Level level;

        public BuildButton(string name, Texture2D texture, int buttonX, int buttonY, GraphicsDevice graphicsDevice, Player player, Level level)
        {
            this.name = name;
            this.texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.graphicsDevice = graphicsDevice;
            this.player = player;
            this.level = level;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void OnButtonClick()
        {
            uIButton = new UIButton((int)uIButtonPos.X, (int)uIButtonPos.Y, this, graphicsDevice, player, level);
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
