using FluorettoEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine
{
    public class DrawContext
    {
        public GameTime Time { get; }
        public SpriteBatch Batch { get; }
        public ScaledDrawer ScaledDrawer { get; }

        public DrawContext(GameTime time, SpriteBatch spriteBatch, float scale, float naturalAssetScale)
        {
            Time = time;
            Batch = spriteBatch;
            ScaledDrawer = new ScaledDrawer(scale, naturalAssetScale, Batch);
        }
    }
}
