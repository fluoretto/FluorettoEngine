using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Components
{
    public abstract class DrawableComponent
    {
        public virtual void ContentReady()
        {

        }

        public virtual void Update(UpdateContext context)
        {

        }

        public virtual void Draw(DrawContext drawContext)
        {

        }
    }
}
