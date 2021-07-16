using System;
using System.Collections.Generic;

namespace Algorithms.Lesson_4
{
    public static class DataVisualization
    {
        public static void PrintBinaryTree(Node<int> root, int depth, int width)
        {
            PrintByLevelOrder(root);
            Console.WriteLine();
        }
        private static void PrintByLevelOrder(Node<int> node)
        {
            if (node == null) return;
                
            Queue<Node<int>> queue = new Queue<Node<int>>();
            queue.Enqueue(node);

            do
            {
                Node<int> currentNode = queue.Dequeue();
                Console.Write($"({currentNode.Value})");
                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                else Console.Write("()");
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                else Console.Write("()");
            } while (queue.Count > 0) ;
        }
    }
}
