using System;

namespace AwesomeThreadingFun.Other
{
    class Vector
    {
        #region Operators
        // Operators
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
        #endregion

        #region Explicit_Operators
        // Explicit Operators
        public static explicit operator Microsoft.Xna.Framework.Point(Vector v)
            => new Microsoft.Xna.Framework.Point(v.X, v.Y);
        public static explicit operator Vector(Microsoft.Xna.Framework.Point p)
            => new Vector(p.X, p.Y);
        #endregion

        #region Implicit_Operators
        // Implicit Operators
        public static implicit operator Vector(VectorF v)
            => new Vector((int)v.X, (int)v.Y);
        public static implicit operator Vector(Microsoft.Xna.Framework.Vector2 v)
            => new Vector((int)v.X, (int)v.Y);
        public static implicit operator Microsoft.Xna.Framework.Vector2(Vector v)
            => new Microsoft.Xna.Framework.Vector2(v.X, v.Y);
        #endregion

        #region Properties
        // Properties
        public int X { get; set; }
        public int Y { get; set; }
        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }
        public VectorF Normalized { get { return new VectorF(X / Length, Y / Length); } }
        public static Vector Zero { get { return new Vector(0, 0); } }
        #endregion

        #region Constructors
        public Vector(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        #endregion
    }
}
