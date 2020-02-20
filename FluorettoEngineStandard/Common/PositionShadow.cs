using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Common
{
    public class PositionShadow
    {
        public event EventHandler XChanged;
        public event EventHandler YChanged;

        private Vector2 _vector = new Vector2(0, 0);
        private Vector2 _shadowVector = new Vector2(0, 5);

        public float X
        {
            get
            {
                return _vector.X;
            }
            set
            {
                _vector.X       = value;
                _shadowVector.X = value;

                XChanged?.Invoke(this, null);
            }
        }

        public float Y
        {
            get
            {
                return _vector.Y;
            }
            set
            {
                _vector.Y       = value;
                _shadowVector.Y = value + ShadowDistance;

                YChanged?.Invoke(this, null);
            }
        }

        public int ShadowDistance { get; set; } = 0;

        public Vector2 GetShadowVector()
        {
            return _shadowVector;
        }

        public Vector2 GetPositionVector()
        {
            return _vector;
        }
    }
}
