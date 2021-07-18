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

        //static void Main(string[] args)
        //{
            
        //}
        private static void TestMethodAddItem()
        {
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                int value = rnd.Next(_bTree.Root.Value * 2);
                Console.WriteLine($"AddItem({value})");
                _bTree.AddItem(value);
                _bTree.PrintTree();
                Console.WriteLine();
            }
        }
        private static void TestMethodRemoveItem()
        {
            Node<int>[] array = _bTree.GetTree();
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] == null) continue;
                Console.WriteLine($"RemoveItem({array[i].Value})");
                _bTree.RemoveItem(array[i].Value);
                _bTree.PrintTree();
                Console.WriteLine();
            }
        }
    }
}
