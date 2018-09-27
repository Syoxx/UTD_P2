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
		protected float damage;
        protected float damageRadius;
		protected float price;
		public float range;
		protected float reloadTime;
		protected float timer;
        protected float projectileSpeed;

		protected bool readyToFire;
		protected bool canSlow;

		public Vector2 position;

        protected Texture2D towerTexture, projectileTexture;

        public virtual void Fire(Enemys target)
        {
            Projectile proj = new Projectile(projectileTexture, projectileSpeed, damage, damageRadius, position);
        }

		public virtual void Update(GameTime gameTime)
		{
			if(!readyToFire)
			{
				timer += gameTime.ElapsedGameTime.Milliseconds;
				if (timer >= reloadTime)
					readyToFire = true;
			}
		}

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(towerTexture, new Rectangle((int)position.X, (int)position.Y, towerTexture.Width, towerTexture.Height), Color.White);
        }
	}
}
