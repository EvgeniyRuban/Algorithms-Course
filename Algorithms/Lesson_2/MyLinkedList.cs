using System;

namespace Algorithms.Lesson_2
{
    public class MyLinkedList : ILinkedList
    {
        private Node _firstNode;
        private Node _lastNode;
        private int _nodesCount = 0;

        public MyLinkedList(params int[] values)
        {
            for (int i = 0; i < values.Length; i++)
                AddNode(values[i]);
        }
        public void AddNode(int value)//Complet
        {
            if(_nodesCount == 0)
            {
                _firstNode = new Node(value, null, _lastNode);
                _lastNode = _firstNode;
            }
            else
            {
                Node newNode = new Node(value, _lastNode);
                _lastNode.NextNode = newNode;
                _lastNode = newNode;
            }
            _nodesCount++;
        }
        public void AddNodeAfter(Node node, int value)//Complet
        {
            if (node == _lastNode) AddNode(value);
            else
            {
                Node newNode = new Node(value, node, node.NextNode);
                newNode.NextNode.PrevNode = newNode;
                node.NextNode = newNode;
            }
            _nodesCount++;
        }
        public Node FindNode(int searchValue)//Complet
        {
            Node temp = _firstNode;
            for(int i=0; i < _nodesCount; i++)
            {
                if (temp.Value == searchValue) return temp;
                else temp = temp.NextNode;
            }
            return null;
        }
        public Node FindNode(uint index)//Complet
        {
            Node temp = _firstNode;
            for (int i = 0; i < index; i++)
                temp = temp.NextNode;
            return temp;
        }
        public int GetCount()//Complet
        {
            return _nodesCount;
        }
        public void RemoveNode(int index)//Complet
        {
            Node temp = FindNode((uint)index);
            if (temp == _firstNode) _firstNode = _firstNode.NextNode;
            else if (temp == _lastNode) _lastNode = _lastNode.PrevNode;
            else
            {
                temp.PrevNode.NextNode = temp.NextNode;
                temp.NextNode.PrevNode = temp.PrevNode;
            }

            _nodesCount--;
        }
        public void RemoveNode(Node node)//Complet
        {
            if (node == _firstNode) _firstNode = _firstNode.NextNode;
            else if (node == _lastNode) _lastNode = _lastNode.PrevNode;
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }

            _nodesCount--;
        }
        public void PrintItem(int index)//Complet
        {
            Node temp = FindNode((uint)index);
            Console.Write(temp.Value);
        }
    }
}
