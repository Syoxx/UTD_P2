using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace UTD_P2
{
    /// <summary>
    /// EnemyController checkt in der Update wenn das Leben der Enemys <=0 ist, wenn ja -> Destroy (null setzen) und dem Player Coins gutschreiben
    /// Timer wird gestartet wenn Enemys <= 0 ist.
    /// Wenn Timer = 0, Enemys nach Anzahl spawnen.
    /// 
    /// EnemyWaypoints nach Map (Lvl) -> switch abfrage nach lvl string
    /// </summary>
    class EnemyController
    {

    }
}
