using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Resources
{
    public class SpriteTexture
    {
        public Texture2D Texture { get; }
        public Rectangle Bounds { get; }

        public SpriteTexture(Texture2D texture, Rectangle bounds)
        {
            Texture = texture;
            Bounds = bounds;
        }
    }
}
