

namespace Algorithms.Lesson_2
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int value)
        {
            Value = value;
        }
        public Node(int value, Node prevNode) 
        { 
            Value = value;
            PrevNode = prevNode;
        }
        public Node(int value, Node prevNode, Node nextNode)
        {
            Value = value;
            PrevNode = prevNode;
            NextNode = nextNode;
        }
    }
}
