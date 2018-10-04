using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    class SlowTower : Towers
    {
        // Defines how fast an enemy will move when hit.
        private float speedModifier;
        // Defines how long this effect will last.
        private float modifierDuration;

        /// <summary>
        /// Constructs a Slow Tower end sets all needed values
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="player"></param>
        /// <param name="graphicsDevice"></param>
        public SlowTower(Texture2D texture, float positionX, float positionY, Player player, GraphicsDevice graphicsDevice)
        {
            damage = 5;
            hasSplash = true;
            price = 15;
            range = 300;
            reloadTime = 2;
            position.X = positionX + texture.Width / 2;
            position.Y = positionY + texture.Height / 2;
            towerTexture = texture;
            canSlow = true;

            speedModifier = 0.6f;
            modifierDuration = 2.0f;

            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            player.money -= (int)price;
            projectileTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/slowProj.png", graphicsDevice);
			explosionTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/explosionSlow.png", graphicsDevice);
			projectileSpeed = 20;
            this.player = player;
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
