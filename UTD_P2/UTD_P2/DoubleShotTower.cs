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
    class DoubleShotTower : Towers
    {
        public DoubleShotTower(Texture2D texture, float positionX, float positionY)
        {
            damage = 15;
            damageRadius = 0;
            price = 10;
            range = 100;
            reloadTime = 2;
            position.X = positionX;
            position.Y = positionY;
            towerTexture = texture;
        }
    }
}
