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
        private float speed, damage, damageRadius, rotationAngle, speedModifier, speedModifierDuration;

        private Texture2D texture, explosionTexture;
        private Vector2 position, direction, rotationCenter, drawPosition, drawPositionExplo;

        public Enemys target;

        private Rectangle sourceRectangle;

		Level level;

        public bool hit;

        private bool canSlow;

        public Projectile(Texture2D texture, Texture2D explosionTexture, float speed, float damage, float damageRadius, Vector2 position, Enemys target, bool canSlow, Level level)
        {
            this.texture = texture;
			this.explosionTexture = explosionTexture;
			this.speed = speed;
            this.damage = damage;
            this.damageRadius = damageRadius;
            this.position = position;
            this.target = target;
            this.canSlow = canSlow;
			this.level = level;
            hit = false;
			speedModifier = 0.5f;
			speedModifierDuration = 2f;
            rotationCenter = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            direction = target.projTargetPosition - position;
            direction.Normalize();
            position += direction * speed;
            rotationAngle = (float)Math.Atan2(direction.Y, direction.X);
            if (Vector2.Distance(position, target.projTargetPosition) <= 10)
            {
                if (damageRadius > 0)
                    InitiateExplosion();
                target.CurrentHealth -= damage;
				if (canSlow)
				{
					target.SpeedModifier = speedModifier;
					target.ModifierDuration = speedModifierDuration;
				}
                hit = true;
            }
        }

        private void InitiateExplosion()
        {
			drawPositionExplo = position - new Vector2(explosionTexture.Width / 2, explosionTexture.Height / 2);
			Explosion newExplo = new Explosion(position, drawPositionExplo, explosionTexture, damage, canSlow, speedModifier, speedModifierDuration);
			level.AddExplosion(newExplo);
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            drawPosition = position;
			
			if (hit && damageRadius > 0)
				spriteBatch.Draw(explosionTexture, drawPositionExplo, Color.Orange);
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, drawPosition, sourceRectangle, Color.White, rotationAngle, rotationCenter, 1, SpriteEffects.None, 1);
        }
    }
}
