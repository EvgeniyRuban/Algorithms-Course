using System;

namespace Algorithms.Lesson_4.Task_2
{
    public class BinaryTree : ITree<int>
    {
        /// <summary>
        /// Корень дерева.
        /// </summary>
        public Node<int> Root { get; private set; }
        /// <summary>
        /// Максимальная глубина расположения листа дерева.  
        /// </summary>
        public int Depth { get => Root != null ? GetDepthPreOrder(Root) : 0; }
        public int Width { get => (int)(Math.Pow(2, (double)Depth - 1)); }

        public BinaryTree(int rootValue, params int[] array)
        {
            Root = new Node<int>(rootValue);
            foreach (int item in array) AddItemPreOrder(Root, item);
        }
        /// <summary>
        /// Добавляет новый элемент в дерево.
        /// </summary>
        public void AddItem(int value) => AddItemPreOrder(Root, value);
        /// <summary>
        /// Добавляет массив новый элемент в дерево.
        /// </summary>
        public void AddItem(params int[] values) 
        {
            foreach (int value in values) AddItemPreOrder(Root, value);
        }
        /// <summary>
        /// Получить элемент дерева с заданным значением.
        /// </summary>
        /// <param name="value"></param>
        public Node<int> GetNode(int value) => GetNodeRecursiv(Root, value);
        /// <summary>
        /// Удалить элемент дерева с заданным значанием.
        /// </summary>
        /// <param name="value"></param>
        public void RemoveItem(int value)// Дописать
        {
            Node<int> node = GetNodeRecursiv(Root, value);
            if (node == null) return;
            if (node.Left == null && node.Right == null) // Если удаляемый элемент является лепестком.
            {
                if (node.Parent.Value > node.Value) node.Parent.Left = null;
                else node.Parent.Right = null;
            }
            else if (node.Left != null && node.Right == null) // Если у удаляемого элемент есть левый наследника.
            {
                if (node.Parent.Value > node.Value) node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
            }
            else if (node.Left == null && node.Right != null) // Если у удаляемого элемент есть правый наследника.
            {
                if (node.Parent.Value > node.Value) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
            }
            else if (node.Left != null && node.Right != null) // Если у удаляемого элемент есть оба наследника.
            {
                Node<int> maxLeftValueNode = GetNodeWithMaxValue(node.Left);
                RemoveItem(maxLeftValueNode.Value);
                node.Value = maxLeftValueNode.Value;
            }
        }
        /// <summary>
        /// Осуществляет вывод дерева в консоль.
        /// </summary>
        public void PrintTree() => DataVisualization.PrintBinaryTree(Root, Depth, Width);
        private void AddItemPreOrder(Node<int> node, int value)
        {
            if (node == null || node.Value == value) return;
            else if (node.Value > value && node.Left == null)
                node.Left = new Node<int>(value, node);
            else if (node.Value > value)
                AddItemPreOrder(node.Left, value);
            else if(node.Value < value && node.Right == null)
                node.Right = new Node<int>(value, node);
            else if (node.Value < value)
                AddItemPreOrder(node.Right, value);
        }
        private Node<int> GetNodeWithMaxValue(Node<int> node)
        {
            if (node == null) return node;
            return node.Right != null ? GetNodeWithMaxValue(node.Right) : node;
        }
        private Node<int> GetNodeWithMinValue(Node<int> node)
        {
            if (node == null) return node;
            return node.Left != null ? GetNodeWithMaxValue(node.Left) : node;
        }
        private Node<int> GetNodeRecursiv(Node<int> node, int value)
        {
            if (node == null) return null;

            if (node.Value == value) return node;
            else if (node.Value > value) return GetNodeRecursiv(node.Left, value);
            else return GetNodeRecursiv(node.Right, value);
        }
        private int GetDepthPreOrder(Node<int> node, int iterator = 1)
        {
            // Возвращает максимальную глубину расположения листа бинарного дерева
            // при помощи прямого обхода в глубину.  

            if (node == null) return iterator - 1;
            int leftStep = GetDepthPreOrder(node.Left, iterator + 1);
            int rightStep = GetDepthPreOrder(node.Right, iterator + 1);
            return leftStep > rightStep ? leftStep : rightStep;
        }
    }
}
