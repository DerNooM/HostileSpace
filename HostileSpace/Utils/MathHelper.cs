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
    }
}
