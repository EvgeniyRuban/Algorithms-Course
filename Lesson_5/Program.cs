using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_5
{
    class Program
    {
        private static BinaryTree _bTree;

        public static void Main(string[] args)
        {
            Random rnd = new Random();
            _bTree = new BinaryTree(50);
            for (int i = 0; i < 10; i++) _bTree.AddItem(rnd.Next(_bTree.Root.Value * 2));

            Console.WriteLine("FullTree:");
            _bTree.PrintTree();
            Node<int>[] preOrder = _bTree.GetTree(TreeTraversal.PreOrder);
            Node<int>[] levelOrder = _bTree.GetTree(TreeTraversal.LevelOrder);
            Console.WriteLine($"\n{TreeTraversal.PreOrder}:");
            foreach (var item in preOrder) if (item != null) Console.Write($"{item.Value}, ");
            Console.WriteLine($"\n\n{TreeTraversal.LevelOrder}:");
            foreach (var item in levelOrder) if (item != null) Console.Write($"{item.Value}, ");

            Console.ReadKey();
        }
    }
}
