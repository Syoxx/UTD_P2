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
    public class Projectile
    {
        private float speed, damage, damageRadius, rotationAngle;

        private Texture2D texture;

        private Vector2 position, direction, rotationCenter;

        public Enemys target;

        private Rectangle sourceRectangle;

        public Projectile(Texture2D texture, float speed, float damage, float damageRadius, Vector2 position, Enemys target)
        {
            this.texture = texture;
            this.speed = speed;
            this.damage = damage;
            this.damageRadius = damageRadius;
            this.position = position;
            this.target = target;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            direction = position - target.position;
            direction.Normalize();
            position += direction * speed;
            rotationAngle = (float)Math.Atan2(direction.Y, direction.X);
            if (Vector2.Distance(position, target.position) <= 2)
            {
                if (damageRadius > 0)
                    InitiateExplosion();
                target.life -= damage;
            }
        }

        private void InitiateExplosion()
        {
            //TODO: implement Circle for Explosion collision
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotationAngle, rotationCenter, 1, SpriteEffects.None, 1);
        }
    }
}
