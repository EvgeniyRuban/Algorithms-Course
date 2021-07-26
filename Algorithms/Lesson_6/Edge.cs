using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_6
{
    class Edge
    {
        public int Weight { get; set; }
        public Vertex Vertex { get; set; }
        public Edge(int weight, Vertex destVertex) { Weight = weight; Vertex = destVertex; }
    }
}
