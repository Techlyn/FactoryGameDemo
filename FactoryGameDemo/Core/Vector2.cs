using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace FactoryGameDemo.Core
{
    public struct Vector2<T> where T : INumber<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Vector2(T x, T y)
        {
            X = x;
            Y = y;
        }

        public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b) => new(a.X + b.X, a.Y + b.Y);
        public static Vector2<T> operator +(Vector2<T> a, T value) => new(a.X + value, a.Y + value);
        public static Vector2<T> operator -(Vector2<T> a, Vector2<T> b) => new(a.X - b.X, a.Y - b.Y);
        public static Vector2<T> operator *(Vector2<T> a, T value) => new(a.X * value, a.Y * value);
        public static Vector2<T> operator /(Vector2<T> a, T value) => new(a.X / value, a.Y / value);
        public override string ToString() => $"({X}, {Y})";

        public static bool operator <(Vector2<T> a, Vector2<T> b) => a.X < b.X && a.Y < b.Y;
        public static bool operator >(Vector2<T> a, Vector2<T> b) => a.X > b.X && a.Y > b.Y;
        public static bool operator >=(Vector2<T> a, Vector2<T> b) => a.X >= b.X && a.Y >= b.Y;
        public static bool operator <=(Vector2<T> a, Vector2<T> b) => a.X <= b.X && a.Y <= b.Y;

        public static bool operator ==(Vector2<T> a, Vector2<T> b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2<T> a, Vector2<T> b) => !(a == b);
        public override bool Equals(object? obj) => obj is Vector2<T> other && this == other;
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static Vector2<int> ToInt(Vector2<T> v)
        {
            int x = Convert.ToInt32(v.X);
            int y = Convert.ToInt32(v.Y);
            return new Vector2<int>(x, y);
        }

        public static Vector2<float> ToFloat(Vector2<T> v)
        {
            float x = Convert.ToSingle(v.X);
            float y = Convert.ToSingle(v.Y);
            return new Vector2<float>(x, y);
        }

    }
}
