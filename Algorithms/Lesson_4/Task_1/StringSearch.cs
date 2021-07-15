using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_4.Task_1
{
    static class StringSearch
    {
        public static bool Search(string item, params string[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == item) return true;

            return false;
        }
        public static bool Search(string item, HashSet<string> items)
        {
            return items.Contains(item);
        }
    }
}
