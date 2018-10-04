using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    public class BuildButton : Button
    {
        Vector2 uIButtonPos;
        UIButton uIButton;
        GraphicsDevice graphicsDevice;
        Player player;
        Level level;
        public bool allowBuilding;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        /// <summary>
        /// Button used for displaying where you can Build and Opens a Build dialogue in click
        /// </summary>
        /// <param name="name"></param>
        /// <param name="texture"></param>
        /// <param name="buttonX"></param>
        /// <param name="buttonY"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="player"></param>
        /// <param name="level"></param>
        public BuildButton(string name, Texture2D texture, int buttonX, int buttonY, GraphicsDevice graphicsDevice, Player player, Level level)
        {
            this.name = name;
            this.texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
            this.graphicsDevice = graphicsDevice;
            this.player = player;
            this.level = level;
            allowBuilding = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Creates the Building Dialogue
        /// </summary>
        protected override void OnButtonClick()
        {
            if (allowBuilding)
            {
                uIButton = new UIButton(buttonX, buttonY, this, graphicsDevice, player, level);
                level.SetUIButton(uIButton);
            }

            else
                Upgrade();

        }

        private void Upgrade()
        {
            
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
