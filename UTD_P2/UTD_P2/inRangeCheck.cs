using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace UTD_P2
{
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
