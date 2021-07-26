using System.Collections.Generic;

namespace Algorithms.Lesson_6
{
    class Vertex
    {
        public int Value { get; set; }
        public List<Edge> Edges{ get; set; }
        public Vertex(int value, params Edge[] edges) 
        { 
            Value = value;
            Edges = new List<Edge>();
            foreach (Edge item in edges) { Edges.Add(item); }
        }
    }
}
