using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Stores the Players Life and Money
/// </summary>
namespace UTD_P2
{
    public class Player
    {
        public int money;
        public int life;


        public Player(GraphicsDevice graphicsDevice)
        {
			money = 30;
			life = 30;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
