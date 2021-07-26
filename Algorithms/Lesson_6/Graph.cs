using System;
using System.Collections.Generic;

namespace Algorithms.Lesson_6
{
    class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public Graph(params Vertex[] vertices) 
        {
            Vertices = new List<Vertex>();
            foreach (Vertex item in vertices) Vertices.Add(item); 
        }
        public Graph(int[,] matrix)
        {
            Vertices = new List<Vertex>();
            for (int i = 0; i < matrix.GetLength(0); i++) Vertices.Add(new Vertex(i+1));
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if(matrix[i,j] != 0)
                        Vertices[i].Edges.Add(new Edge(matrix[i, j], Vertices[j]));
        }
        /// <summary>
        /// Получить значения коротчайшего пути до каждой вершины графа.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int[] GetShortestPath(Vertex vertex)
        {
            if(!Vertices.Contains(vertex)) return null;
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(vertex);
            int[] results = new int[Vertices.Count];
            for (int i = 0; i < results.Length; i++)
            {
                if (i == Vertices.IndexOf(vertex)) results[i] = 0;
                else results[i] = Int32.MaxValue;
            }
            do
            {
                Vertex currentVertex = queue.Dequeue();
                foreach(Edge edge in currentVertex.Edges)
                {
                    if(edge.Weight + results[Vertices.IndexOf(currentVertex)]
                        <
                        results[Vertices.IndexOf(edge.Vertex)])
                    {
                        queue.Enqueue(edge.Vertex);
                        results[Vertices.IndexOf(edge.Vertex)] = edge.Weight + results[Vertices.IndexOf(currentVertex)];
                    }
                }
            } while (queue.Count != 0);
            return results;
        }
        /// <summary>
        /// Получить граф в виде матрицы.
        /// </summary>
        /// <returns></returns>
        public int[,] ToMatrix()
        {
            int[,] result = new int[Vertices.Count, Vertices.Count];
            for (int x = 0; x < Vertices.Count; x++)
                for(int y=0; y < Vertices[x].Edges.Count; y++)
                    result[x, Vertices.IndexOf(Vertices[x].Edges[y].Vertex)] = Vertices[x].Edges[y].Weight;
            return result;
        }
    }
}
