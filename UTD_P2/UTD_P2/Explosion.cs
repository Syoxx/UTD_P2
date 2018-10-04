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
		private float damage, timer, exploDuration, speedModifier, speedModifierDuration;
		private Color exploColor;
		public bool done, canSlow, hasSplash;

        /// <summary>
        /// Used to Draw the Sprites of the Explosion and Hits. Damages and Slows Enemys caught in the Explosion if a Tower has
        /// Splash Damage or Slow
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="drawPos"></param>
        /// <param name="texture"></param>
        /// <param name="damage"></param>
        /// <param name="canSlow"></param>
        /// <param name="speedModifier"></param>
        /// <param name="speedModifierDuration"></param>
        /// <param name="hasSplash"></param>
		public Explosion(Vector2 pos, Vector2 drawPos, Texture2D texture, float damage, bool canSlow, float speedModifier, float speedModifierDuration, bool hasSplash)
		{
			this.pos = pos;
			this.drawPos = drawPos;
			this.texture = texture;
			this.damage = damage;
			this.canSlow = canSlow;
			this.speedModifier = speedModifier;
			this.speedModifierDuration = speedModifierDuration;
            this.hasSplash = hasSplash;

            exploDuration = .5f;
			timer = 0;
			done = false;
			exploColor = Color.Yellow;

			if (hasSplash)
				exploColor = Color.Red;

			if (canSlow)
				exploColor = Color.Aquamarine;
		}

        /// <summary>
        /// Checks if an Enemy is insider an Explosion
        /// </summary>
        /// <param name="enemy"></param>
		public void CheckIfInsideExplosion(Enemys enemy)
		{
			if (hasSplash)
			{
				if (enemy.Position.X < pos.X + texture.Width &&
						enemy.Position.X > pos.X - texture.Height &&
						enemy.Position.Y < pos.Y + texture.Height &&
						enemy.Position.Y > pos.Y - texture.Height)
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

		public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
		{
			spriteBatch.Draw(texture, drawPos, exploColor);
		}
	}
}
