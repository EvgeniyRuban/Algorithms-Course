using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lesson_2
{
    public static class SearchAlgorithm
    {
        public static int OperationCount { get; private set; } = 0;

        public static int BinarySearch(int[] array, int value)
        {
            // Асимптотическая сложность: O(logN)
            OperationCount = 0;

            int min = 0;
            int max = array.Length - 1;

            while(min <= max)
            {
                OperationCount++;
                int mid = (max + min) / 2;
                if (array[mid] > value) max = mid;
                else if (array[mid] < value) min = mid + 1;
                else return array[mid];
            } 

            return -1;
        }
    }
}
