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
    class Projectile
    {
        private float speed, damage, damageRadius;

        private Texture2D texture;

        private Vector2 position;

        public Projectile(Texture2D texture, float speed, float damage, float damageRadius, Vector2 position)
        {
            this.texture = texture;
            this.speed = speed;
            this.damage = damage;
            this.damageRadius = damageRadius;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), Color.White);
        }
    }
}
