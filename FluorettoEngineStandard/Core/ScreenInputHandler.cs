using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Core
{
    public class ScreenInputHandler
    {
        // Eventos do Cursor relativos a JANELA
        public event CursorActionHandler CursorPressed;
        public event CursorActionHandler CursorMoved;
        public event CursorActionHandler CursorReleased;

        // É a primeira que detecta o movimento do mouse?
        bool firstMouse = true;

        // Posição do cursor no update anterior
        Vector2 previousPos = Vector2.Zero;

        // Como o mouse estava no update anterior?
        ButtonState previousLastLeft = ButtonState.Released;

        int scale = 1;

        public ScreenInputHandler(int scale)
        {
            this.scale = scale;
        }

        public void Update()
        {
            CursorAction action = 0; // Ação do Cursor

            bool foundTouch = false; // Encontrou Touch?

            Vector2 pos = Vector2.Zero; // Posição do Cursor

            TouchCollection touchCollection = TouchPanel.GetState();

            // Tenta localizar ponto de touch
            if (touchCollection.Count > 0)
            {
                TouchLocation p = touchCollection[0];

                if (p.State != TouchLocationState.Invalid)
                {
                    action = (CursorAction)p.State;

                    pos = p.Position;

                    foundTouch = true;
                }
            }

            // Está usando touchscreen. Não bustque pelo mouse.
            if (foundTouch)
            {
                AnalyzeBounds(pos, action);
                return;
            }

            // Tenta buscar mouse.
            MouseState mouse = Mouse.GetState();

            pos = new Vector2(mouse.X, mouse.Y);

            if (mouse.LeftButton == ButtonState.Pressed && previousLastLeft == ButtonState.Released)
            {
                action = CursorAction.Pressed;
                previousLastLeft = ButtonState.Pressed;
            }
            else if (mouse.LeftButton == ButtonState.Released && previousLastLeft == ButtonState.Pressed)
            {
                action = CursorAction.Released;
                previousLastLeft = ButtonState.Released;
            }
            else if (pos.X != previousPos.X && pos.Y != previousPos.Y)
            {
                if (firstMouse)
                {
                    // Ignora primeiro move do mouse.
                    firstMouse = false;
                }
                else
                {
                    action = CursorAction.Moved;
                }
            }

            if (action == 0)
            {
                // Não houve ação para o mouse ou touch.
                return;
            }

            // Analize se algumas das áreas se interceptam com a posição do cursor.
            AnalyzeBounds(pos, action);

            previousPos = pos;
        }

        private void AnalyzeBounds(Vector2 pos, CursorAction action)
        {
            Vector2 delta = Vector2.Zero;

            if (action != CursorAction.Pressed)
            {
                delta = pos - previousPos;
            }

            var args = new CursorActionArgs(pos / scale, delta / scale, action);

            switch (action)
            {
                case CursorAction.None:
                    break;
                case CursorAction.Moved:
                    CursorMoved?.Invoke(this, args);
                    break;
                case CursorAction.Pressed:
                    CursorPressed?.Invoke(this, args);
                    break;
                case CursorAction.Released:
                    CursorReleased?.Invoke(this, args);
                    break;
                default:
                    break;
            }
        }
    }
}
