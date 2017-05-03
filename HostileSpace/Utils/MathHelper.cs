using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;

namespace HostileSpace
{
    public class MathHelper
    {
        public static Single GetDistance(Vector2f A, Vector2f B)
        {
            return (Single)Math.Sqrt(Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2));
        }

        public static Single DegreeToRadian(Single angle)
        {
            return (Single)Math.PI * angle / 180.0f;
        }

        public static Single RadianToDegree(Single angle)
        {
            return angle * (180.0f / (Single)Math.PI);
        }

        public static Single ShortestRotation(Single start, Single end)
        {
            Single diff = end - start;

            if (diff > 180.0f)
                diff -= 360.0f;
            else if (diff < -180.0f)
                diff += 360.0f;

            return diff;
        }

    }
}
