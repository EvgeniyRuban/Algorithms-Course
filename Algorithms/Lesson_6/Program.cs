using System;

namespace Algorithms.Lesson_6
{
    class Program
    {
        private static Graph _graph;

        public static void Main(string[] args)
        {
            _graph = new Graph(new int[8, 8]
            {
                {0, 32, 95, 75, 57, 0, 0, 0 },
                {32, 0, 5, 0, 23, 0, 0, 16 },
                {95, 5, 0, 18, 0, 6, 0, 0 },
                {75, 0, 18, 0, 24, 9, 0, 0 },
                {57, 23, 0, 24, 0, 11, 20, 94 },
                {0, 0, 6, 9, 11, 0, 7, 0 },
                {0, 0, 0, 0, 20, 7, 0, 81 },
                {0, 16, 0, 0, 94, 0, 81, 0 }
            });

            foreach(Vertex vertex in _graph.Vertices) Test(vertex);
        }
        private static void Test(Vertex vertex)
        {
            Console.WriteLine($"Start vertex: ({vertex.Value})");
            int[] array = _graph.GetShortestPath(vertex);
            Console.Write($"Vertex: ");
            for (int i=0; i<_graph.Vertices.Count; i++)
                Console.Write($"({_graph.Vertices[i].Value})\t");
            Console.WriteLine();
            Console.Write($"Path:\t");
            for (int i = 0; i < _graph.Vertices.Count; i++)
                Console.Write($"{array[i]}\t");
            Console.WriteLine("\n");
        }
    }
}
