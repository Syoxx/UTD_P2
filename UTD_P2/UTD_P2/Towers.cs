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
	class Towers
	{
		protected float damage;
		protected float price;
		protected float range;
		protected float reloadTime;
		protected float timer;

		protected bool readyToFire;
		protected bool canSlow;

		protected Vector2 position;

		public void Update(GameTime gameTime)
		{
			if(!readyToFire)
			{
				timer += gameTime.ElapsedGameTime.Milliseconds;
				if (timer >= reloadTime)
					readyToFire = true;
			}

			else
			{
				inRangeCheck.checkRange(position, range);
			}
		}
	}
}
