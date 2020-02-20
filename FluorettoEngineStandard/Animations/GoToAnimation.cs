using System;
using System.Collections.Generic;
using System.Text;

namespace FluorettoEngine.Animations
{
    public class GoToAnimation
    {
        AnimationInterpolator interpolator;

        float startValue;
        float previousTarget;

        float lastRes;

        public GoToAnimation(AnimationInterpolator interpolator, float startValue)
        {
            this.interpolator = interpolator;

            this.startValue     = startValue;
            this.lastRes        = startValue;
            this.previousTarget = startValue;
        }

        public float Go(float to, int delta)
        {
            if (to != previousTarget)
            {
                interpolator.Reset();

                startValue = lastRes;
                previousTarget = to;
            }

            lastRes = interpolator.NextFrame(startValue, to, delta);

            return lastRes;
        }
    }
}
