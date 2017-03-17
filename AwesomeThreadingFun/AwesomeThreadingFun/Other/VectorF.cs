using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Other
{
    class VectorF
    {
        public static VectorF operator + (VectorF lhs, Vector rhs)
            => new VectorF(lhs.X + rhs.X, lhs.Y + rhs.Y);
        public static VectorF operator +(VectorF lhs, VectorF rhs)
            => new VectorF(lhs.X + rhs.X, lhs.Y + rhs.Y);
        public static VectorF operator - (VectorF lhs, Vector rhs)
            => new VectorF(lhs.X - rhs.X, lhs.Y - rhs.Y);
        public static VectorF operator -(VectorF lhs, VectorF rhs)
            => new VectorF(lhs.X - rhs.X, lhs.Y - rhs.Y);
        public static VectorF operator *(VectorF lhs, float rhs)
            => new VectorF(lhs.X * rhs, lhs.Y * rhs);
        public static VectorF operator *(VectorF lhs, int rhs)
            => new VectorF(lhs.X * rhs, lhs.Y * rhs);
        public static VectorF operator /(VectorF lhs, int rhs)
            => new VectorF(lhs.X / rhs, lhs.Y / rhs);
        public static VectorF operator /(VectorF lhs, float rhs)
            => new VectorF(lhs.X / rhs, lhs.Y / rhs);
        public static bool operator ==(VectorF lhs, VectorF rhs)
            => lhs.X == rhs.X && lhs.Y == rhs.Y;
        public static bool operator !=(VectorF lhs, VectorF rhs)
            => !(lhs == rhs);

        public static explicit operator VectorF(Vector v)
            => new VectorF(v.X, v.Y);
        public static explicit operator VectorF(Microsoft.Xna.Framework.Vector2 v)
            => new VectorF(v.X, v.Y);
        public static explicit operator Microsoft.Xna.Framework.Vector2(VectorF v)
            => new Microsoft.Xna.Framework.Vector2(v.X, v.Y);

        public float X { get; set; }
        public float Y { get; set; }
        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }
        public static VectorF Zero { get { return new VectorF(0, 0); } }

        public VectorF(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
