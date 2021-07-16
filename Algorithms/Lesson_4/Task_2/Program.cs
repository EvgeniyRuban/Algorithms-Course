using System;
using System.Text;

namespace Algorithms.Lesson_4.Task_2
{
    class Program
    {
        // 2. Реализуйте двоичное дерево и метод вывода его в консоль
        // Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска.
        // Дерево должно быть сбалансированным(это требование не обязательно).
        // Также напишите метод вывода в консоль дерева, чтобы увидеть, насколько корректно работает ваша реализация.

        private static BinaryTree _bTree;

        static void Main(string[] args)
        {
            Initialize();

            while (_bTree.Root != null)
            {
                _bTree.PrintTree();
                _bTree.RemoveItem(Int32.Parse(Console.ReadLine()));
                Console.Clear();
            }
        }
        static void Initialize()
        {
            Random rnd = new Random();
            _bTree = new BinaryTree(50);
            for (int i = 0; i < 10; i++) _bTree.AddItem(rnd.Next(_bTree.Root.Value * 2));
        }
    }
}
