using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Task_5
{
    public struct Vector2
    {
        private static float x = 0, y = 0;
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; }  }
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(X * X + Y * Y);
            }
        }
        public static Vector2 operator *(Vector2 v, float n)
        {
            return new Vector2(v.X * n, v.Y * n);
        }
        public static Vector2 operator *(float n, Vector2 v)
        {
            return new Vector2(v.X * n, v.Y * n);
        }
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
    }
}
