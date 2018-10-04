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
    /// <summary>
    /// Goes through a List of all Towers and Enemys and checks if a Enemy is in range of a tower.
    /// If it is, sets the target of the tower to the enemy, except the enemy died in this frame
    /// </summary>
    class InRangeCheck
    {
        public InRangeCheck()
        {

        }

        public void CheckRange(List<Towers> towers, List<Enemys> enemys)
        {
            foreach (Towers tower in towers)
            {
                foreach (Enemys enemy in enemys)
                {
                    if (Vector2.Distance(tower.position, enemy.Position) <= tower.range)
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
