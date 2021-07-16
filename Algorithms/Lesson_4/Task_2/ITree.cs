using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_4.Task_2
{
    public interface ITree<T>
    {
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        Node<T> GetNode(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

}
