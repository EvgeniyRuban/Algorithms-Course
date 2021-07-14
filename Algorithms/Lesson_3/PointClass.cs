using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_3
{
    internal class PointClass<T> : ICloneable
    {
        public T X { get; set; }
        public T Y { get; set; }

        public PointClass(T x, T y) { X = x; Y = y; }
        public object Clone() => new PointClass<T>(X, Y);
    }
    internal struct PointStruct<T> : ICloneable
    {
        public T X { get; set; }
        public T Y { get; set; }

        public PointStruct(T x, T y){ X = x; Y = y; }
        public object Clone() => new PointStruct<T>(X, Y);
    }
}
