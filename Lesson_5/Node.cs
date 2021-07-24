using System.Collections;

namespace Algorithms.Lesson_5
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public bool Leaf => Left == null && Right == null ? true : false;

        public Node(T value)
        {
            Value = value;
        }
        public Node(T value, Node<T> parentNode)
        {
            Value = value;
            Parent = parentNode;
        }
        public Node(T value, Node<T> rightNode, Node<T> leftNode, Node<T> parentNode)
        {
            Value = value;
            Right = rightNode;
            Left = leftNode;
            Parent = parentNode;
        }
    }
}