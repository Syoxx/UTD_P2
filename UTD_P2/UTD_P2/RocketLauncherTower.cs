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
    class RocketLauncherTower : Towers
    {
        public RocketLauncherTower(Texture2D texture, float positionX, float positionY, Player player)
        {
            damage = 20;
            damageRadius = 10;
            price = 20;
            range = 100;
            reloadTime = 5;
            position.X = positionX + texture.Width / 2;
            position.Y = positionY + texture.Height / 2;
            towerTexture = texture;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
            player.money -= (int)price;
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
