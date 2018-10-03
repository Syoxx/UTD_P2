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
    class SingleShotTower : Towers
    {
        public SingleShotTower(Texture2D texture, float positionX, float positionY, Player player, GraphicsDevice graphicsDevice)
        {
            damage = 10;
            damageRadius = 0;
            price = 5;
            range = 200;
            reloadTime = 2;
            position.X = positionX + texture.Width / 2;
            position.Y = positionY + texture.Height / 2;
            towerTexture = texture;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            player.money -= (int)price;
            projectileTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/bullet.png", graphicsDevice);
			explosionTexture = ContentConverter.Convert("Content/Assets/TD/Projectiles/explosionNormal.png", graphicsDevice);
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
