using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    public class Level3
    {
        /// <summary>
        /// This array is going to be used to map out our level. Each one of these numbers is a texture.
        /// </summary>
        int[,] map = new int[,]
        {
            {0,0,1,0,0,0,0,0,},
            {0,0,1,1,0,0,0,0,},
            {0,0,0,1,1,0,0,0,},
            {0,0,0,0,1,0,0,0,},
            {0,0,0,1,1,0,0,0,},
            {0,0,1,1,0,0,0,0,},
            {0,0,1,0,0,0,0,0,},
            {0,0,1,1,1,1,1,1,},
        };

        /// <summary>
        /// Get the widht of our level by retreiving our array's row lenght.
        /// </summary>
        public int Width
        {
            get { return map.GetLength(1); }
        }
        /// <summary>
        /// Get the height of our level by retreiving our array's column lenght.
        /// </summary>
        public int Height
        {
            get { return map.GetLength(0); }
        }

        /// <summary>
        /// Create a list which contains the textures to load as map.
        /// </summary>
        private List<Texture2D> tileTextures = new List<Texture2D>();

        /// <summary>
        /// Add a texture to the tileTexture list.
        /// </summary>
        /// <param name="texture"></param>
        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }


        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];
                    batch.Draw(texture, new Rectangle(
                        x * 32, y * 32, 32, 32), Color.White);
                }
            }
        }
    }
}
