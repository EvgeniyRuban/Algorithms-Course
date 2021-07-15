using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_4
{
    static class DataVisualization
    {
        public static void PrintBinaryTree(Node<int> root, int height, int width)
        {

        }
        private static void PrintNode(Node<int> node, int width, int iterator = 0)
        {
            Console.SetCursorPosition(width / 2 - (node.Value.ToString().Length / 2), Console.CursorTop);
            Console.Write($"({node.Value})");
        }
        private static void PrintRecursiv(Node<int> node, int height, int width, int iterator = 0)
        {
            if (node == null) return;

            for (int i = 0; i < height; i++) Console.Write("\t");
            Console.WriteLine($"({node.Value})");

            PrintRecursiv(node.Left, height, width, iterator - 1);
            PrintRecursiv(node.Right, height, width, iterator - 1);
        }
    }
}
