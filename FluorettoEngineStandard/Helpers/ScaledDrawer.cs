using FluorettoEngine.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Helpers
{
    public class ScaledDrawer
    {
        public float Scale { get; private set; }

        Vector2 scaleVector;

        SpriteBatch batch;

        public ScaledDrawer(float scale, SpriteBatch batch)
        {
            Scale = scale;
            scaleVector = new Vector2(scale, scale);

            this.batch = batch;
        }

        public void Draw(SpriteTexture texture, Vector2 position)
        {
            batch.Draw(
                texture.Texture,
                Vector2.Multiply(position, Scale),
                texture.Bounds,
                Color.White,
                0f,
                Vector2.Zero,
                scaleVector,
                SpriteEffects.None,
                0);
        }

        public void Draw(SpriteTexture texture, Vector2 position, Vector2 scaleMultiplier)
        {
            batch.Draw(
                texture.Texture,
                Vector2.Multiply(position, Scale),
                texture.Bounds,
                Color.White,
                0f,
                Vector2.Zero,
                Vector2.Multiply(scaleMultiplier, Scale),
                SpriteEffects.None,
                0);
        }

        public void Draw(SpriteTexture texture, Vector2 position, float opacity)
        {
            Color color = Color.White * opacity;

            batch.Draw(
                texture.Texture,
                Vector2.Multiply(position, Scale),
                texture.Bounds,
                color,
                0f,
                Vector2.Zero,
                scaleVector,
                SpriteEffects.None,
                0);
        }

        public void DrawString(SpriteFont font, string value, Vector2 position)
        {
            batch.DrawString(
                font,
                value,
                Vector2.Multiply(position, Scale),
                Color.White,
                0f,
                Vector2.Zero,
                Scale,
                SpriteEffects.None,
                0);
        }

        public void DrawString(SpriteFont font, string value, Vector2 position, Color color)
        {
            batch.DrawString(
                font,
                value,
                Vector2.Multiply(position, Scale),
                color,
                0f,
                Vector2.Zero,
                Scale,
                SpriteEffects.None,
                0);
        }

        public void DrawString(SpriteFont font, string value, Vector2 position, Color color, Alignment alignment)
        {
            batch.DrawString(
                font,
                value,
                Vector2.Multiply(position, Scale),
                color,
                0f,
                GetTextOrigin(alignment, font, value),
                Scale,
                SpriteEffects.None,
                0);
        }


        public void DrawString(SpriteFont font, string value, Vector2 position, Vector2 scaleMultiplier)
        {
            batch.DrawString(
                font,
                value,
                Vector2.Multiply(position, Scale),
                Color.White,
                0f,
                Vector2.Zero,
                Vector2.Multiply(scaleMultiplier, Scale),
                SpriteEffects.None,
                0);
        }

        public void DrawString(SpriteFont font, string value, Vector2 position, Color color, Vector2 scaleMultiplier)
        {
            batch.DrawString(
                font,
                value,
                Vector2.Multiply(position, Scale),
                color,
                0f,
                Vector2.Zero,
                Vector2.Multiply(scaleMultiplier, Scale),
                SpriteEffects.None,
                0);
        }

        public void DrawString(SpriteFont font, string value, Vector2 position, Color color, Vector2 scaleMultiplier, Alignment alignment)
        {
            batch.DrawString(
                font,
                value,
                Vector2.Multiply(position, Scale),
                color,
                0f,
                GetTextOrigin(alignment, font, value),
                Vector2.Multiply(scaleMultiplier, Scale),
                SpriteEffects.None,
                0);
        }

        private Vector2 GetTextOrigin(Alignment alignment, SpriteFont font, string text)
        {
            float targetX = 0;
            float targetY = 0;

            var measure = font.MeasureString(text);

            if (alignment.HasFlag(Alignment.Middle))
            {
                targetY += measure.Y / 2;
            }

            if (alignment.HasFlag(Alignment.Bottom))
            {
                targetY += measure.Y;
            }

            if (alignment.HasFlag(Alignment.Center))
            {
                targetX += measure.X / 2;
            }

            if (alignment.HasFlag(Alignment.Right))
            {
                targetX += measure.X;
            }

            return new Vector2(targetX, targetY);
        }
    }
}
