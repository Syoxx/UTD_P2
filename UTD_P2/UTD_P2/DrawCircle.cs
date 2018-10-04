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
    /// Creates a circle as a texture2D to be drawn
    /// </summary>
	public static class DrawCircle
	{
		public static Texture2D createCircleText(int radius, Color ringColor, GraphicsDevice graphicsDevice)
		{
			Texture2D texture = new Texture2D(graphicsDevice, radius, radius);
			Color[] colorData = new Color[radius * radius];

			float diam = radius / 2f;
			float diamsq = diam * diam;

            //calculates the circle and sets the Color to red, if the position is on the circle edge, and transparent if not
			for (int x = 0; x < radius; x++)
			{
				for (int y = 0; y < radius; y++)
				{
					int index = x * radius + y;
					Vector2 pos = new Vector2(x - diam, y - diam);
					if (pos.LengthSquared() == diamsq || (pos.LengthSquared() < diamsq + radius && pos.LengthSquared() > diamsq - radius))
					{
						colorData[index] = ringColor;
					}
					else
					{
						colorData[index] = Color.Transparent;
					}
				}
			}

			texture.SetData(colorData);
			return texture;
		}
	}
}
