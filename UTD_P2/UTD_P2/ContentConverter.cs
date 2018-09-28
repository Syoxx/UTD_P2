﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace UTD_P2
{
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