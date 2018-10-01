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
	class InRangeCheck
	{
		public void CheckRange(List<Towers> towers, List<Enemy> enemys)
		{
            foreach(Towers tower in towers)
            {
                foreach(Enemy enemy in enemys)
                {
                    if (Vector2.Distance(tower.position, enemy.position) <= tower.range)
                    {
						if (tower.Target == null && enemy.CurrentHealth > 0)
							tower.Target = enemy;

						else
							continue;
                    }
                }
            }
		}
	}
}
