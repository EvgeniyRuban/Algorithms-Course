using System;

namespace Algorithms.Lesson_8
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[30];
            Random rnd = new Random();
            for(int i=0; i <array.Length; i++) array[i] = rnd.Next(100);
            int[] array_1 = (int[])array.Clone();
            int[] array_2 = (int[])array.Clone();

            Console.WriteLine("Array generated:");
            Print(array);

            Console.WriteLine("\nBucketsort:");
            Print(Sorter.Bucketsort(array_1));

            Console.WriteLine("\nQuicksort:");
            Print(Sorter.Quicksort(array_2, 0, array_2.Length - 1));

            Console.ReadKey();
        }
        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(i == 0) Console.Write($" {array[i]}");
                else Console.Write($", {array[i]}");
            } 
            Console.WriteLine(";");
        }
    }
}
