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
		private float life;
        public Vector2 position;
        private Texture2D texture;

        public Enemys(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }
	}
}
