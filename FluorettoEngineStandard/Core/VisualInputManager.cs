using FluorettoEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace FluorettoEngine.Core
{
    public class VisualInputManager
    {
        public ScreenInputHandler ScreenInputHandler { get; }

        // Areas de detecção de eventos
        List<CursorEventArea> areas = new List<CursorEventArea>();

        public VisualInputManager(ScaleHelper scaleHelper)
        {
            ScreenInputHandler = new ScreenInputHandler(scaleHelper.Scale);

            ScreenInputHandler.CursorMoved    += ScreenInputHandler_CursorAction;
            ScreenInputHandler.CursorPressed  += ScreenInputHandler_CursorAction;
            ScreenInputHandler.CursorReleased += ScreenInputHandler_CursorAction;

            ScreenInputHandler.CursorMoved    += ScreenInputHandler_CursorMoved;
            ScreenInputHandler.CursorReleased += ScreenInputHandler_CursorReleased;
        }

        private void ScreenInputHandler_CursorReleased(object sender, CursorActionArgs e)
        {
            foreach (var area in areas)
            {
                area.CancelClick(e);
            }
        }

        private void ScreenInputHandler_CursorMoved(object sender, CursorActionArgs e)
        {
            foreach (var area in areas)
            {
                area.CheckIn(e);
            }
        }

        private void ScreenInputHandler_CursorAction(object sender, CursorActionArgs e)
        {
            PropagateAction(e);
        }

        /// <summary>
        /// Adiciona uma área de detecção
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="z"></param>
        /// <returns>Área de detecção</returns>
        public CursorEventArea AddArea(int x, int y, int width, int height, int z)
        {
            CursorEventArea area = new CursorEventArea(x, y, width, height, z);

            areas.Add(area);

            areas.Sort((a, b) => a.Z.CompareTo(b.Z));

            return area;
        }

        public void Update()
        {
            ScreenInputHandler.Update();
        }

        private void PropagateAction(CursorActionArgs e)
        {
            foreach (var area in areas)
            {
                if (area.Bounds.Contains(e.Position))
                {
                    // Quebre se a propagação foi parada.
                    if (area.HandleAction(e)) break;
                }
            }
        }
    }

    public enum CursorAction
    {
        None = 0,
        Moved = 1,
        Pressed = 2,
        Released = 3
    }
}
