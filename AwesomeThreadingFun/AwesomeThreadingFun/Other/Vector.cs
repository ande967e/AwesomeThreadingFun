using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Other
{
    class Vector
    {
        public static Vector operator + (Vector lhs, VectorF rhs)
            => new Vector((int)(lhs.X + rhs.X), (int)(lhs.Y + rhs.Y));
        public static Vector operator + (Vector lhs, Vector rhs)
            => new Vector(lhs.X + rhs.X, lhs.Y + rhs.Y);
        public static Vector operator - (Vector lhs, VectorF rhs)
            => new Vector((int)(lhs.X - rhs.X), (int)(lhs.Y - rhs.Y));
        public static Vector operator - (Vector lhs, Vector rhs)
            => new Vector(lhs.X - rhs.X, lhs.Y - rhs.Y);
        public static Vector operator * (Vector lhs, float rhs)
            => new Vector((int)(lhs.X * rhs), (int)(lhs.Y * rhs));
        public static Vector operator * (Vector lhs, int rhs)
            => new Vector(lhs.X * rhs, lhs.Y * rhs);
        public static Vector operator / (Vector lhs, int rhs)
            => new Vector(lhs.X / rhs, lhs.Y / rhs);
        public static Vector operator / (Vector lhs, float rhs)
            => new Vector((int)(lhs.X / rhs), (int)(lhs.Y / rhs));
        public static bool operator == (Vector lhs, Vector rhs)
            => lhs.X == rhs.X && lhs.Y == rhs.Y;
        public static bool operator != (Vector lhs, Vector rhs)
            => !(lhs == rhs);

        public static explicit operator Vector(VectorF v)
            => new Vector((int)v.X, (int)v.Y);
        public static explicit operator Vector(Microsoft.Xna.Framework.Vector2 v)
            => new Vector((int)v.X, (int)v.Y);
        public static explicit operator Microsoft.Xna.Framework.Vector2(Vector v)
            => new Microsoft.Xna.Framework.Vector2(v.X, v.Y);

        public int X { get; set; }
        public int Y { get; set; }
        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }
        public static Vector Zero { get { return new Vector(0, 0); } }

        public Vector(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
