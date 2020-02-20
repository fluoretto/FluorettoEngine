using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Helpers
{
    public class ScaleHelper
    {
        public int Scale { get; }
        GraphicsDeviceManager graphics;

        public ScaleHelper(int scale, GraphicsDeviceManager graphics)
        {
            this.Scale = scale;
            this.graphics = graphics;
        }

        /// <summary>
        /// Escala uma posição no espaço
        /// </summary>
        /// <param name="pos">Posição a ser escalada</param>
        /// <returns>Vetor escalonado.</returns>
        public int GetSpace(int pos)
        {
            return Scale * pos;
        }

        /// <summary>
        /// Escala um vetor no espaço
        /// </summary>
        /// <param name="vector">Vetor a ser escalado.</param>
        /// <returns>Vetor escalonado.</returns>
        public Vector2 GetVector(Vector2 vector)
        {
            return Vector2.Multiply(vector, Scale);
        }

        /// <summary>
        /// Pega a altura do Viewport com escala invertida aplicada.
        /// </summary>
        /// <returns>Altura do Viewport com escala invertida aplicada.</returns>
        public float GetViewportHeight()
        {
            return graphics.GraphicsDevice.Viewport.Height / Scale;
        }

        /// <summary>
        /// Pega a altura do Viewport com escala invertida aplicada.
        /// </summary>
        /// <returns>Altura do Viewport com escala invertida aplicada.</returns>
        public float GetViewportWidth()
        {
            try
            {
                return graphics.GraphicsDevice.Viewport.Width / Scale;
            }
            catch
            {
                return 0;
            }
        }
    }
}
