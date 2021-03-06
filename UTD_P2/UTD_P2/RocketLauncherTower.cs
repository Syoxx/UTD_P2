﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    class RocketLauncherTower : Towers
    {
        /// <summary>
        /// Constructs a RocketLauncher Tower end sets all needed values
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="player"></param>
        /// <param name="graphicsDevice"></param>
        public RocketLauncherTower(Texture2D texture, float positionX, float positionY, Player player, GraphicsDevice graphicsDevice)
        {
            damage = 30;
            hasSplash = true;
            price = 20;
            range = 300;
            reloadTime = 3;
            position.X = positionX + texture.Width / 2;
            position.Y = positionY + texture.Height / 2;
            towerTexture = texture;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            player.money -= (int)price;
            this.player = player;
            projectileTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/missile.png", graphicsDevice);
			explosionTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/explosionRocket.png", graphicsDevice);
			projectileSpeed = 8;
        }

        public override void Fire(Level level)
        {
            base.Fire(level);
        }

        public override void Update(GameTime gameTime, Level level)
        {
            base.Update(gameTime, level);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
