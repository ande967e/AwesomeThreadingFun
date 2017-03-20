using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeThreadingFun.Other
{
    class VectorF
    {
        #region Operators
        // Tons of operators for all mathematical magic happening
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
        #endregion

        #region Explicit Operators
        // Explicit Operators
        public static explicit operator Microsoft.Xna.Framework.Point(VectorF v)
            => new Microsoft.Xna.Framework.Point((int)v.X, (int)v.Y);
        public static explicit operator VectorF(Microsoft.Xna.Framework.Point p)
            => new VectorF(p.X, p.Y);
        #endregion

        #region Implicit_Operators
        // Implicit Operators
        public static implicit operator VectorF(Vector v)
            => new VectorF(v.X, v.Y);
        public static implicit operator VectorF(Microsoft.Xna.Framework.Vector2 v)
            => new VectorF(v.X, v.Y);
        public static implicit operator Microsoft.Xna.Framework.Vector2(VectorF v)
            => new Microsoft.Xna.Framework.Vector2(v.X, v.Y);
        #endregion

        #region Properties
        // Properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }
        public VectorF Normalized { get { return new VectorF(X / Length, Y / Length); } }
        public static VectorF Zero { get { return new VectorF(0, 0); } }
        #endregion

        #region Constructors
        // Constructors
        public VectorF(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        #endregion
    }
}
