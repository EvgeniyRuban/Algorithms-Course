using System;
using System.Collections.Generic;

namespace Algorithms.Lesson_5
{
    public static class DataVisualization
    {
        public static void PrintBinaryTree<T>(Node<T>[] array , int depth)
        {
            int currentPosition = 0;// Кол-во выведенных в консоль элементов.
            for (int level=1; level <= depth; level++)
            {
                int iterationCount = (int)Math.Pow(2, level - 1) + currentPosition;// Кол-во элементов на каждом уровне дерева.
                for (; currentPosition < iterationCount; currentPosition++)
                {
                    if (array[currentPosition] != null) Console.Write($"({array[currentPosition].Value})");
                    else Console.Write("(-)");
                }
                Console.WriteLine();
            }
        }
        private static void PrintByLevelOrder<T>(Node<T> node)
        {
            if (node == null) return;
                
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);

            do
            {
                Node<T> currentNode = queue.Dequeue();
                Console.Write($"({currentNode.Value})");
                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                else Console.Write("()");
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                else Console.Write("()");
            } while (queue.Count > 0) ;
        }
    }
}
