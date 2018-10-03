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
	public class Explosion
	{
		private Vector2 pos, drawPos;
		private Texture2D texture;
		private float damage, timer, exploDuration, speedModifier, speedModifierDuration, explosionRadius;
		private Color exploColor;
		public bool done, canSlow;

		public Explosion(Vector2 pos, Vector2 drawPos, Texture2D texture, float damage, bool canSlow, float speedModifier, float speedModifierDuration, float explosionRadius)
		{
			this.pos = pos;
			this.drawPos = drawPos;
			this.texture = texture;
			this.damage = damage;
			this.canSlow = canSlow;
			this.speedModifier = speedModifier;
			this.speedModifierDuration = speedModifierDuration;
			this.explosionRadius = explosionRadius;
			exploDuration = 1f;
			timer = 0;
			done = false;
			exploColor = Color.Yellow;

			if (explosionRadius > 0)
				exploColor = Color.Red;

			if (canSlow)
				exploColor = Color.Aquamarine;
		}

		public void CheckIfInsideExplosion(Enemys enemy)
		{
			if (explosionRadius > 0)
			{
				if (enemy.Position.X < pos.X + texture.Width &&
						enemy.Position.X > pos.X &&
						enemy.Position.Y < pos.Y + texture.Height &&
						enemy.Position.Y > pos.Y)
				{
					enemy.CurrentHealth -= damage;

					if (canSlow)
					{
						enemy.SpeedModifier = speedModifier;
						enemy.ModifierDuration = speedModifierDuration;
					}
				}
			}
		}

		public void Update(GameTime gameTime)
		{
			timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (timer > exploDuration)
				done = true;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, drawPos, exploColor);
		}
	}
}
