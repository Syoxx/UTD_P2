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
        public RocketLauncherTower(Texture2D texture, float positionX, float positionY)
        {
            damage = 20;
            damageRadius = 10;
            price = 20;
            range = 100;
            reloadTime = 5;
            position.X = positionX;
            position.Y = positionY;
            towerTexture = texture;
        }

        public override void Fire(Enemys target)
        {
            base.Fire(target);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
