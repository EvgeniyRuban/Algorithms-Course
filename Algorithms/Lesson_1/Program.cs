using System;

namespace Algorithms
{
    class Program
    {
        // Task 1:
        // - Требуется реализовать на C# функцию согласно блок-схеме.
        // Блок-схема описывает алгоритм проверки, простое число или нет.
        //
        // Task 2:
        // - Вычислите асимптотическую сложность функции из примера ниже.
        //
        // Task 3:
        // - Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).

        private static int[] _testArray = { 1, 5, 8, 11, 12 };

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(" Task 1:\n");
        //    for (int i=0; i < _testArray.Length; i++)
        //    {
        //        Console.Write($"Test {i + 1}: Input:'{_testArray[i]}' - Output: ");
        //        PrintNumberProperty((uint)_testArray[i]);
        //    }

        //    Console.WriteLine("\n Task 3:\n\n FibonacciRecursiv():");
        //    for (int i = 0; i < _testArray.Length; i++)
        //        Console.WriteLine($"Test {i+1}: Input:'{_testArray[i]}' - Output: {FibonacciRecursiv((uint)_testArray[i])}");

        //    Console.WriteLine("\nFibonacciByLoop():");
        //    for (int i = 0; i < 5; i++)
        //        Console.WriteLine($"Test {i + 1}: Input:'{_testArray[i]}' - Output: { FibonacciByLoop((uint)_testArray[i])}");

        //    Console.ReadKey();
        //}// <-------------------------Tests
        public static void PrintNumberProperty(uint number)// <--------Task 1
        {
            int d = 0, i = 2;
            while (i < number)
            {
                if (number % i == 0) d++;
                i++;
            }
            Console.WriteLine(d == 0 ? "Prime number" : "Not a prime number");
        }
        public static int StrangeSum(int[] inputArray)// <-------------Task 2
        {
            // Асимптотическая сложность алгоритма: O(N^3)
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;
                        if (j != 0)
                        {
                            y = k / j;
                        }
                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }
            return sum;
        }
        public static uint FibonacciRecursiv(uint number)// <----------Task 3
        {
            return  number == 0 || number == 1 ? number : FibonacciRecursiv(number - 1) + FibonacciRecursiv(number - 2);
        }
        public static uint FibonacciByLoop(uint number)// <------------Task 3
        {
            uint iter_1 = 0, iter_2 = 1;
            for (int i = 0; i < (int)number - 1; i++)
                _ = iter_1 < iter_2 ? iter_1 += iter_2 : iter_2 += iter_1;
            return number % 2 == 0 ? iter_1 : iter_2;
        }
    }
}
