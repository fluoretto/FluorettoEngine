using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Components
{
    public abstract class GameScreen<TState>
    {
        protected bool firstDraw { get; private set; }
        protected bool firstUpdate { get; private set; }

        protected readonly GameContext<TState> context;

        protected GameScreen(GameContext<TState> context)
        {
            this.context = context;

            firstDraw = true;
            firstUpdate = true;
        }

        public virtual void ContentReady()
        {

        }

        public virtual void Update(UpdateContext updateContext)
        {
            firstUpdate = false;
        }

        public virtual void Draw(DrawContext drawContext)
        {
            firstDraw = false;
        }
    }
}
