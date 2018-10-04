using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    /// <summary>
    /// Tower Base Class, defines all basic Tower behaviour
    /// </summary>
    public abstract class Towers
	{
        private Vector2 projSpawnPosition;
        protected float damage, price, reloadTime, timer, projectileSpeed, rotationAngle;
		public float range;

		protected bool readyToFire, canSlow, hasSplash = false;

		public Vector2 position, rotationCenter;
        protected Vector2 direction;

        protected Texture2D towerTexture, projectileTexture, explosionTexture;

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

        /// <summary>
        /// Called when ready to fire and has a target. Creates Projectiles and resets reload timer
        /// </summary>
        /// <param name="level"></param>
		public virtual void Fire(Level level)
		{
			if (target.CurrentHealth > 0)
			{
				timer = 0;
				proj = new Projectile(projectileTexture, explosionTexture, projectileSpeed, damage, hasSplash, position, target, canSlow, level);
                level.AddProjectile(proj);
                readyToFire = false;
			}
		}

        /// <summary>
        /// Checks if target is out of range, handles reload timer, rotates tower towards target and calls Fire function
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="level"></param>
		public virtual void Update(GameTime gameTime, Level level)
		{
            if (target != null)
                if (Vector2.Distance(position, target.projTargetPosition) > range)
                    target = null;

			if(!readyToFire)
			{
				timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
				if (timer >= reloadTime)
					readyToFire = true;
			}   

            if (target != null)
			{
                direction = target.projTargetPosition - position;
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
