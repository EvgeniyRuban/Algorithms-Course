using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_3
{
    class Size<T> : ICloneable
    {
        public T Height { get; }
        public T Width { get; }

        public Size(T height, T width) { Height = height; Width = width; }
        public object Clone() => new Size<T>(Height, Width);
    }
}
