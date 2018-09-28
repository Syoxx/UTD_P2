﻿using System;
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
		protected float damage, damageRadius, price, reloadTime, timer, projectileSpeed, rotationAngle;
		public float range;

		protected bool readyToFire, canSlow = false;

		public Vector2 position, rotationCenter;
        protected Vector2 direction;

        protected Texture2D towerTexture, projectileTexture;

        protected Rectangle sourceRectangle;

        Projectile proj;

        public Enemys rotationTarget;

        public virtual void Fire(Enemys target)
        {
            if (target.life > 0)
            proj = new Projectile(projectileTexture, projectileSpeed, damage, damageRadius, position, target);
        }

		public virtual void Update(GameTime gameTime)
		{
            direction = position - rotationTarget.position;
            direction.Normalize();
            rotationAngle = (float)Math.Atan2(direction.Y, direction.X);
			if(!readyToFire)
			{
				timer += gameTime.ElapsedGameTime.Milliseconds;
				if (timer >= reloadTime)
					readyToFire = true;
			}
		}

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(0, 0, towerTexture.Width, towerTexture.Height);
            spriteBatch.Draw(towerTexture, position, sourceRectangle, Color.White, rotationAngle, rotationCenter, 1, SpriteEffects.None, 1);
        }
	}
}
