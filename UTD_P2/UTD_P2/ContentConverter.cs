﻿using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace UTD_P2
{
    /// <summary>
    /// Used to Convert non Monogame Files into Monogame files, so that they can be used as Textures
    /// </summary>
    public static class ContentConverter
    {
        public static Texture2D Convert(string path, GraphicsDevice graphicsDevice)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Texture2D returnTexture = Texture2D.FromStream(graphicsDevice, fileStream);
            fileStream.Dispose();
            return returnTexture;
        }
    }
}
