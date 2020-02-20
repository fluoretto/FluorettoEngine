using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Animations
{
    public class AnimationInterpolator
    {
        private readonly int durationInMs;
        private readonly int delayInMs;

        private readonly Easings.Functions function;

        public bool AnimEnded { get; private set; } = false;

        private int passedTime = 0;

        private float deltaVal = 0;

        /// <summary>
        /// Cria um interpolador de animação.
        /// </summary>
        /// <param name="delay">Delay em milissegundos.</param>
        /// <param name="duration">Duração em milissegundos.</param>
        /// <param name="function">Função de easing em milissegundos.</param>
        public AnimationInterpolator(int delay, int duration, Easings.Functions function)
        {
            this.delayInMs = delay;
            this.durationInMs = duration;
            this.function = function;
        }

        /// <summary>
        /// Gets the next value for the animation
        /// </summary>
        /// <param name="deltaTime">The delta from the previous call to nextFrame in milliseconds</param>
        /// <returns></returns>
        public float NextFrame(float startValue, float endValue, int deltaTime)
        {
            passedTime += deltaTime;

            if (AnimEnded)
            {
                return endValue;
            }

            if (passedTime < delayInMs)
            {
                return startValue;
            }

            deltaVal = endValue - startValue;

            float toInterpolate = ((float)passedTime - (float)delayInMs) / (float)durationInMs;

            if (toInterpolate >= 1)
            {
                AnimEnded = true;
                return endValue;
            }

            float val = startValue + Easings.Interpolate(toInterpolate, function) * deltaVal;

            return val;
        }

        public void Reset()
        {
            passedTime = 0;
            AnimEnded = false;
        }
    }
}
