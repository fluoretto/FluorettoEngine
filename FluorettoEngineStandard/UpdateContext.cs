using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine
{
    public class UpdateContext
    {
        public GameTime Time { get; set; }

        public UpdateContext(GameTime time)
        {
            Time = time;
        }
    }
}
