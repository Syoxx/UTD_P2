using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UTD_P2
{
	public abstract class Towers
	{
        private Vector2 projSpawnPosition;
        protected float damage, damageRadius, price, reloadTime, timer, projectileSpeed, rotationAngle;
		public float range;

		protected bool readyToFire, canSlow = false;

		public Vector2 position, rotationCenter;
        protected Vector2 direction;

        protected Texture2D towerTexture, projectileTexture;

        protected Rectangle sourceRectangle;

        Projectile proj;

        protected Enemys target;

        protected Player player;

		public Enemys Target
		{
			get
			{
				return target;
			}

			set
			{
				target = value;
			}
		}

		public virtual void Fire(Level level)
		{
			if (target.CurrentHealth > 0)
			{
                projSpawnPosition = position + new Vector2(32, 32);
				timer = 0;
				proj = new Projectile(projectileTexture, projectileSpeed, damage, damageRadius, projSpawnPosition, target, canSlow);
                level.AddProjectile(proj);
			}
		}

		public virtual void Update(GameTime gameTime, Level level)
		{
            if (target != null)
                if (Vector2.Distance(position, target.Position) > range)
                    target = null;

			if(!readyToFire)
			{
				timer += gameTime.ElapsedGameTime.Milliseconds;
				if (timer >= reloadTime)
					readyToFire = true;
			}   

            if (target != null)
			{
                direction = target.Position - position;
                direction.Normalize();
                rotationAngle = (float)Math.Atan2(direction.Y, direction.X);
                if (readyToFire && target.CurrentHealth > 0)
					Fire(level);

				if (target.CurrentHealth <= 0)
					target = null;
			}
		}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(0, 0, towerTexture.Width, towerTexture.Height);
            spriteBatch.Draw(towerTexture, position, sourceRectangle, Color.White, rotationAngle, rotationCenter, 1, SpriteEffects.None, 1);
        }
	}
}
