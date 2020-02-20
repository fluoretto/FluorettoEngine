using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Core
{
    public class CursorEventArea
    {
        public bool CursorIn { get; set; } = false;

        /// <summary>
        /// O usuário apertou em cima do objeto
        /// </summary>
        public event CursorActionHandler Click;

        /// <summary>
        /// O usuário apertou em cima do objeto
        /// </summary>
        public event CursorActionHandler CursorPressed;

        /// <summary>
        /// O mouse moveu-se por cima do objeto
        /// </summary>
        public event CursorActionHandler CursorMoved;

        /// <summary>
        /// O usuário soltou em cima do objeto
        /// </summary>
        public event CursorActionHandler CursorReleased;

        /// <summary>
        /// O usuário entrou com o cursor no objeto 
        /// </summary>
        public event CursorActionHandler CursorEnter;

        /// <summary>
        /// O usuário saiu com o cursor do objeto
        /// </summary>
        public event CursorActionHandler CursorExit;

        public int Z { get; set; }
        public Rectangle Bounds { get; set; }

        bool clickInProgress = false;

        public CursorEventArea(int x, int y, int width, int height, int z)
        {
            Bounds = new Rectangle(x, y, width, height);
            Z = z;
        }

        /// <summary>
        /// Despacha a ação.
        /// </summary>
        /// <param name="action">Ação.</param>
        /// <param name="pos">Posição do Cursor.</param>
        /// <param name="delta">Delta da Posição.</param>
        /// <returns>Ação foi parada ou não, i.e., se deve ser propagada.</returns>
        public bool HandleAction(CursorActionArgs args)
        {
            CursorActionHandler handler;

            switch (args.Action)
            {
                case CursorAction.None:
                    return false;
                case CursorAction.Moved:
                    handler = CursorMoved;
                    break;
                case CursorAction.Pressed:
                    handler = CursorPressed;
                    clickInProgress = true;
                    break;
                case CursorAction.Released:
                    handler = CursorReleased;
                    break;
                default:
                    return false;
            }

            if (args.Action == CursorAction.Released && clickInProgress)
            {
                clickInProgress = false;
                Click?.Invoke(this, args);
            }

            //if (args.Action == CursorAction.Released && CursorIn)
            //{
            //    CursorIn = false;
            //    CursorExit?.Invoke(this, args);
            //}

            if ((args.Action == CursorAction.Moved || args.Action == CursorAction.Moved) && !CursorIn)
            {
                CursorIn = true;
                CursorEnter?.Invoke(this, args);
            }

            handler?.Invoke(this, args);

            return args.PropagationPrevented;
        }

        public void CheckIn(CursorActionArgs args)
        {
            if (!CursorIn) return;

            if (!Bounds.Contains(args.Position))
            {
                CursorIn = false;
                CursorExit?.Invoke(this, args);
            }
        }

        public void CancelClick(CursorActionArgs args)
        {
            clickInProgress = false;
        }
    }
}
