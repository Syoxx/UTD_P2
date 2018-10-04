using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    class DoubleShotTower : Towers
    {
        public DoubleShotTower(Texture2D texture, float positionX, float positionY, Player player, GraphicsDevice graphicsDevice)
        {
            damage = 15;
            hasSplash = false;
            price = 10;
            range = 200;
            reloadTime = 1;
            position.X = positionX + texture.Width / 2;
            position.Y = positionY + texture.Height / 2;
            towerTexture = texture;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            player.money -= (int)price;
            projectileTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/bullet.png", graphicsDevice);
			explosionTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/explosionNormal.png", graphicsDevice);
			this.player = player;
			projectileSpeed = 20;
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
