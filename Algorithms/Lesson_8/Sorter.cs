using System.Collections.Generic;

namespace Algorithms.Lesson_8
{
    public static class Sorter
    {
        public static int[] Bucketsort(int[] array, int blockCount = 5)
        {
            if (array.Length <= blockCount - 1) return Quicksort(array, 0, array.Length - 1);

            int maxValue = 0; // Поиск максимального значения массива.
            for (int i = 0; i < array.Length; i++)
                if (array[i] > maxValue) maxValue = array[i];

            List<int> splitValues = new List<int>(); // Создание коллекции разделительных значений, для деления на блоки.
            for (int i = 0; i < blockCount - 1; i++) splitValues.Add(maxValue / blockCount * (i + 1));
            splitValues.Add(maxValue);

            List<List<int>> blocks = new List<List<int>>(blockCount);
            for (int i = 0; i < blockCount; i++) blocks.Add(new List<int>());

            for (int i = 0; i < array.Length; i++) // Разбиение данных из массива на блоки.
                for (int j = 0; j < blocks.Count; j++)
                    if (array[i] <= splitValues[j])
                    {
                        blocks[j].Add(array[i]);
                        break;
                    }

            for (int i = 0; i < blocks.Count; i++) // Сортировка каждого блока.
                blocks[i] = new List<int>(Quicksort(blocks[i].ToArray(), 0, blocks[i].Count - 1));

            for (int i = 0, j = 0; i < blocks.Count; i++) // Запись данных обратно в массив.
                for (int l = 0; l < blocks[i].Count; l++, j++) array[j] = blocks[i][l];

            return array;
        }
        public static int[] Quicksort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];
            do
            {
                while (array[i] < x) i++;
                while (array[j] > x) j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                    i++;
                    j--;
                }
            } while (i <= j);
            if (i < last) Quicksort(array, i, last);
            if (first < j) Quicksort(array, first, j);
            return array;
        }
    }
}
