using FluorettoEngine.Core;
using FluorettoEngine.Helpers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine
{
    public class GameContext<TState>
    {
        /// <summary>
        /// Instância do jogo.
        /// </summary>
        public Game Game { get; }

        /// <summary>
        /// Instâcia atual do gerenciador de estado do jogo.
        /// </summary>
        public TState State { get; }

        /// <summary>
        /// Instância atual do gerenciador de gráficos do jogo.
        /// </summary>
        public GraphicsDeviceManager Graphics { get; }

        /// <summary>
        /// Ajuda nas operações de escalanomento.
        /// </summary>
        public ScaleHelper ScaleHelper { get; }

        /// <summary>
        /// Gerencia as ações do mouse/touch
        /// </summary>
        public VisualInputManager VisualInputManager { get; }

        public GameContext(Game game, TState state, GraphicsDeviceManager graphics, int scale)
        {
            Game = game;
            State = state;
            Graphics = graphics;
            ScaleHelper = new ScaleHelper(scale, graphics);
            VisualInputManager = new VisualInputManager(ScaleHelper);
        }
    }
}
