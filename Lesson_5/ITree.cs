using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_5
{
    public interface ITree<T>
    {
        void AddItem(T value); // добавить узел
        void RemoveItem(T value); // удалить узел по значению
        Node<T> GetNode(T value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

}
