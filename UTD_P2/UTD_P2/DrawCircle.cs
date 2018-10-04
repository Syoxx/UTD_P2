using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UTD_P2
{
    public static class DrawCircle
	{
		public static Texture2D createCircleText(int radius, Color ringColor, GraphicsDevice graphicsDevice)
		{
			Texture2D texture = new Texture2D(graphicsDevice, radius, radius);
			Color[] colorData = new Color[radius * radius];

			float diam = radius / 2f;
			float diamsq = diam * diam;

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
