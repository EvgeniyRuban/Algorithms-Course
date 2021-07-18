using System;
using System.Collections.Generic;

namespace Algorithms.Lesson_5
{
    public class BinaryTree : ITree<int>
    {
        /// <summary>
        /// Кореневой элемент дерева.
        /// </summary>
        public Node<int> Root { get; private set; }
        /// <summary>
        /// Максимальная глубина расположения листа дерева.  
        /// </summary>
        public int Depth { get => Root != null ? GetDepthPreOrder(Root) : 0; }
        /// <summary>
        /// Вместимость элементов на самом глубоком уровне расположения листа дерева.
        /// </summary>
        public int Width { get => (int)Math.Pow(2, (double)Depth - 1); }
        /// <summary>
        /// Кол-во элементов в дереве.
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Максимальное возможное кол-во элементов, с текущей глубиное дерева.
        /// </summary>
        public int MaxCount => Width + Width - 1;

        public BinaryTree(int rootValue, params int[] array)
        {
            Root = new Node<int>(rootValue);
            foreach (int item in array) AddItemPreOrder(Root, item);
            Count = array.Length + 1;
        }
        /// <summary>
        /// Добавляет новый элемент в дерево.
        /// </summary>
        public void AddItem(int value)
        { 
            AddItemPreOrder(Root, value);
            Count++;
        }
        /// <summary>
        /// Добавляет массив новый элемент в дерево.
        /// </summary>
        public void AddItem(params int[] values) 
        {
            foreach (int value in values) AddItemPreOrder(Root, value);
            Count += values.Length;
        }
        /// <summary>
        /// Получить элемент дерева с заданным значением.
        /// </summary>
        /// <param name="value"></param>
        public Node<int> GetNode(int value) => GetNodeRecursiv(Root, value);
        /// <summary>
        /// Получить дерево в виде массива.
        /// </summary>
        /// <returns></returns>
        public Node<int>[] GetTree()
        {
            // Обход в ширину
            if (Root == null) return null;
            List<Node<int>> listNode = new List<Node<int>>();
            Queue<Node<int>> queue = new Queue<Node<int>>();
            int maxNodeCount = MaxCount;
            queue.Enqueue(Root);
            listNode.Add(Root);

            do
            {
                Node<int> currentNode = queue.Dequeue();
                if (currentNode != null)
                {
                    queue.Enqueue(currentNode.Left);
                    queue.Enqueue(currentNode.Right);
                    listNode.Add(currentNode.Left);
                    listNode.Add(currentNode.Right);
                }
                else
                {
                    queue.Enqueue(null);
                    queue.Enqueue(null);
                    listNode.Add(null);
                    listNode.Add(null);
                }

            } while (queue.Count > 0 && listNode.Count < maxNodeCount);
            return listNode.ToArray();
        }
        /// <summary>
        /// Удалить элемент дерева с заданным значанием.
        /// </summary>
        /// <param name="value"></param>
        public void RemoveItem(int value)
        {
            if (RemoveItemRecursiv(value)) Count--;
        }
        /// <summary>
        /// Осуществляет вывод дерева в консоль.
        /// </summary>
        public void PrintTree() => DataVisualization.PrintBinaryTree(GetTree(), Depth);
        private void AddItemPreOrder(Node<int> node, int value)
        {
            if (node == null) return;
            else if (node.Value > value && node.Left == null)
                node.Left = new Node<int>(value, node);
            else if (node.Value > value)
                AddItemPreOrder(node.Left, value);
            else if(node.Value <= value && node.Right == null)
                node.Right = new Node<int>(value, node);
            else if (node.Value <= value)
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
        private bool RemoveItemRecursiv(int value)// Дописать
        {
            Node<int> node = GetNodeRecursiv(Root, value);
            if (node == null) return false;
            if (node == Root)
            {
                if(Count != 1)
                {
                    // Если корневой элемент не последний в дереве, тогда ищем замену в правом поддереве.
                    Node<int> swapNode = node.Right != null ? GetNodeWithMinValue(node.Right) : GetNodeWithMaxValue(node.Left);// Запоминаем новый.
                    RemoveItemRecursiv(swapNode.Value);// Старый удаляем.
                    node.Value = swapNode.Value;// Перезаписываем значение найденого элемента.
                    return true;
                }
                else
                {
                    Root = null;
                }
                return true;
            }
            if (node.Left == null && node.Right == null) // Если удаляемый элемент является лепестком.
            {
                if (node.Parent.Value > node.Value) node.Parent.Left = null;
                else node.Parent.Right = null;
                return true;
            }
            else if (node.Left != null && node.Right == null) // Если у удаляемого элемент есть левый наследника.
            {
                if (node.Parent.Value > node.Value) node.Parent.Left = node.Left;
                else node.Parent.Right = node.Left;
                return true;
            }
            else if (node.Left == null && node.Right != null) // Если у удаляемого элемент есть правый наследника.
            {
                if (node.Parent.Value > node.Value) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
                return true;
            }
            else if (node.Left != null && node.Right != null) // Если у удаляемого элемент есть оба наследника.
            {
                Node<int> swapNode = node.Left == null ? GetNodeWithMinValue(node.Right) : GetNodeWithMaxValue(node.Left);
                RemoveItemRecursiv(swapNode.Value);
                node.Value = swapNode.Value;
                return true;
            }
            return false;
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
