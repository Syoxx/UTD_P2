﻿using System;
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
        public SingleShotTower(Texture2D texture, float positionX, float positionY)
        {
            damage = 10;
            damageRadius = 0;
            price = 5;
            range = 100;
            reloadTime = 3;
            position.X = positionX;
            position.Y = positionY;
            towerTexture = texture;
            towerTexture = texture;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public override void Fire()
        {
            base.Fire();
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
