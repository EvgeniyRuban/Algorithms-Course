using System;

namespace Algorithms.Lesson_2
{
    static class Program
    {
        private static MyLinkedList _linkedList;
        private static Random _random;

        //public static void Main(string[] args)
        //{
        //    int count = 0;
        //    Initialize();

        //    PrintSplitLine('=');
        //    Console.WriteLine("\tTask 1:");
        //    PrintSplitLine('=');
        //    PrintLinkedListInfo("Initial state:");

        //    //======================= AddNode() ============================
        //    for (int i = 0; i < 5; i++)
        //    {
        //        _linkedList.AddNode(i);
        //        PrintLinkedListInfo($"Using AddNode({i}):", ConsoleColor.DarkGreen);
        //    }
        //    //======================= FindNode() ============================
        //    count = _linkedList.GetCount();
        //    int randomValue = 0;
        //    Node searchResult = null;
            
        //    for (int i = 0; i < count; i++)
        //    {
        //        randomValue = _random.Next(count * 2);
        //        searchResult = _linkedList.FindNode(randomValue);
        //        PrintSearchResult($"Using FindNode({randomValue}):", searchResult != null ? true : false);
        //    }
        //    //======================= RemoveNode() ============================
        //    for (int i = 0; i < count; i++) 
        //    {
        //        _linkedList.RemoveNode(0);
        //        PrintLinkedListInfo($"Using RemoveNode({0}):", ConsoleColor.Red);
        //    }

        //    Console.WriteLine("\tTask 2:");
        //    PrintSplitLine('=');
        //    //======================= BinarySearch() ==========================
        //    int[] array = new int[1000];
        //    for (int i = 0; i < array.Length; i++) array[i] = i;

        //    for (int i = 0; i < 5; i++)
        //    {
        //        int searchValue = _random.Next(array.Length * 2);
        //        int result = SearchAlgorithm.BinarySearch(array, searchValue);
        //        PrintBinarySearchResult(array, result, searchValue);
        //    }

        //    Console.ReadKey();
        //}
        private static void Initialize()
        {
            Console.SetWindowSize(25, Console.WindowHeight);
            _linkedList = new MyLinkedList();
            _random = new Random();
        }
        private static void PrintLinkedListInfo(string comment)
        {
            int count = _linkedList.GetCount();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(comment);
            Console.ResetColor();
            Console.WriteLine($"Item count: {count}");
            Console.Write($"Content: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < count; i++)
            {
                _linkedList.PrintItem(i);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ResetColor();
            PrintSplitLine('=');
        }
        private static void PrintLinkedListInfo(string comment, ConsoleColor commentColor)
        {
            int count = _linkedList.GetCount();

            Console.ForegroundColor = commentColor;
            Console.WriteLine(comment);
            Console.ResetColor();
            Console.WriteLine($"Item count: {count}");
            Console.Write($"Content: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < count; i++)
            {
                _linkedList.PrintItem(i);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ResetColor();
            PrintSplitLine('=');
        }
        private static void PrintSplitLine(char spliter)
        {
            for(int i=0; i < 20; i++)
                Console.Write(spliter);
            Console.WriteLine();
        }
        private static void PrintSearchResult(string comment, bool isFound)
        {
            int count = _linkedList.GetCount();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(comment);
            Console.ResetColor();

            Console.Write("Search result: ");
            Console.ForegroundColor = isFound ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(isFound);
            Console.ResetColor();
            PrintSplitLine('=');
        }
        private static void PrintBinarySearchResult(int[] array, int result, int searchValue)
        {
            Console.WriteLine($"Array size: {array.Length}");
            Console.WriteLine($"Operation count: {SearchAlgorithm.OperationCount}");
            Console.WriteLine($"Searching value: {searchValue}");
            Console.Write($"Searching result: ");
            Console.ForegroundColor = result != -1 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(result);
            Console.ResetColor();
            PrintSplitLine('=');
        }
    }
}
