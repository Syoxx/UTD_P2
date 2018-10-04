using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    public class Sprite
    {
        #region Variables

        protected Texture2D texture;

        protected Vector2 position;
        protected Vector2 velocity;

        protected Vector2 center;
        protected Vector2 origin;

        protected float rotation;

        #endregion

        #region Properties

        public Vector2 Center
        {
            get { return center; }
        }


        public Vector2 Position
        {
            get { return position; }
        }

        #endregion

        /// <summary>
        /// Set the position of the sprite to the center.
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="pos"></param>
        public Sprite(Texture2D tex, Vector2 pos)
        {
            texture = tex;

            position = pos;
            velocity = Vector2.Zero;
            
            center = new Vector2(position.X + 32, position.Y + 32);
            origin = new Vector2(32, 32);
        }

        public virtual void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + 32, position.Y + 32);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, center, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(texture, center, null, color, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
