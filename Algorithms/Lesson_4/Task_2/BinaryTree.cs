using System;

namespace Algorithms.Lesson_4
{
    class BinaryTree
    {
        public Node<int> Root {get ; private set;}  
        public int Height { get => Root != null ? GetDepthByPreOrder(Root) : 0; }
        public int Width { get => (int)(Math.Pow(2, (double)Height - 1)); }
        
        public BinaryTree(int rootValue, params int[] array)
        {
            Root = new Node<int>(rootValue);
            foreach (int item in array) AddRecursiv(item, Root);
        }
        public void Add(int value)
        {
            AddRecursiv(value, Root);
        }
        public void Print() => DataVisualization.PrintBinaryTree(Root, Height, Width);
        private void AddRecursiv(int value, Node<int> node)
        {
            if (node == null || node.Value == value) return;
            else if (node.Value > value && node.Left == null)
                node.Left = new Node<int>(value, node);
            else if (node.Value > value)
                AddRecursiv(value, node.Left);
            else if(node.Value < value && node.Right == null)
                node.Right = new Node<int>(value, node);
            else if (node.Value < value)
                AddRecursiv(value, node.Right);
        }
        private int GetDepthByPreOrder(Node<int> node, int iterator = 1)
        {
            // Возвращает максимальную глубину расположения листа бинарного дерева
            // при помощи прямого обхода в глубину.  

            if (node == null) return iterator - 1;
            int leftStep = GetDepthByPreOrder(node.Left, iterator + 1);
            int rightStep = GetDepthByPreOrder(node.Right, iterator + 1);
            return leftStep > rightStep ? leftStep : rightStep;
        }
    }
}
