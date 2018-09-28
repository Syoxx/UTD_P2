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
	class inRangeCheck
	{
		public void checkRange(List<Towers> towers, List<Enemys> enemys)
		{
            foreach(Towers tower in towers)
            {
                foreach(Enemys enemy in enemys)
                {
                    if (Vector2.Distance(tower.position, enemy.position) <= tower.range)
                    {
                        tower.Fire(enemy);
                    }
                }
            }
		}
	}
}
