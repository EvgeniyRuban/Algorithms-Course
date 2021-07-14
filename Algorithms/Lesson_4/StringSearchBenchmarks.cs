using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Algorithms.Lesson_4
{
    public class StringSearchBenchmarks
    {
        private static string[] _array;
        private static HashSet<string> _hashSet;

        static StringSearchBenchmarks()
        {
            _array = new string[10000];
            for (int i = 0; i < _array.Length; i++) _array[i] = GeneratString(10);
            _hashSet = new HashSet<string>(_array);
        }
        [Benchmark]
        public void LinearSearchString()
        {
            StringSearch.Search(_array[new Random().Next(_array.Length)], _array);
        }
        [Benchmark]
        public void SearchStringByHashSet()
        {
            StringSearch.Search(_array[new Random().Next(_array.Length)], _hashSet);
        }
        private static string GeneratString(int wordSize)
        {
            Random rnd = new Random();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < wordSize; i++)
                result.Insert(i, rnd.Next('a', 'z' + 1));

            return result.ToString();
        }
    }
}
