using Microsoft.Xna.Framework;

namespace FluorettoEngine.Core
{
    public delegate void CursorActionHandler(object sender, CursorActionArgs e);

    public class CursorActionArgs
    {
        public bool PropagationPrevented { get; private set; } = false;

        public Vector2 Position { get; }
        public Vector2 Delta { get; }
        public CursorAction Action { get; set; }

        public CursorActionArgs(Vector2 pos, Vector2 delta, CursorAction action)
        {
            Position = pos;
            Delta    = delta;
            Action   = action;
        }

        public void PreventPropagation()
        {
            PropagationPrevented = true;
        }
    }
}