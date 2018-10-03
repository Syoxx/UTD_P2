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
		private float damage, timer, exploDuration;
		private Color exploColor;
		public bool done;

		public Explosion(Vector2 pos, Vector2 drawPos, Texture2D texture, float damage, bool canSlow)
		{
			this.pos = pos;
			this.drawPos = drawPos;
			this.texture = texture;
			this.damage = damage;
			exploDuration = 1f;
			timer = 0;
			done = false;

			if (canSlow)
				exploColor = Color.Aquamarine;
			else
				exploColor = Color.Red;
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
