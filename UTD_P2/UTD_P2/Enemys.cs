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
	public class Enemys
	{
		private float moveSpeed;
		public float life;
        public Vector2 position;
        private Texture2D texture;
        private float bounty;

        public Enemys(Texture2D texture, Vector2 position, float bounty, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.bounty = bounty;
            this.moveSpeed = speed;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height), Color.White);
        }
    }
}
