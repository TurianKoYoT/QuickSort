using System;

namespace ConsoleApplication
{
    class Program
    {
        public static void QuickSort(int[] array, int first, int last)
        {
            if (array.Length == 0)
                return;

            int pointer = array[(last - first) / 2 + first];
            int temp;
            int left = first;
            int right = last;
            while (left <= right)
            {
                while (array[left] < pointer && left <= last) ++left;
                while (array[right] > pointer && right >= first) --right;
                if (left <= right)
                {
                    temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    ++left;
                    --right;
                }
            }
            if (right > first) QuickSort(array, first, right);
            if (left < last) QuickSort(array, left, last);
        }

        static void Main(string[] args)
        {
            ThreeElementArray();
            AllSameElementsArray();
            ThousandRandomElementsArray();
            VoidArray();

            Console.ReadKey();
        }

        private static void ThreeElementArray()
        {
            //Тестирование сортировки в массиве из 3 элементов
            int[] array = new[] { 8, 1, 4 };
            QuickSort(array, 0, array.Length - 1);
            if (array[1] > array[0] && array[2] > array[1])
                Console.WriteLine("Сортировка массива из 3 элементов работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 3 элементов работает неверно");
        }

        private static void AllSameElementsArray()
        {
            //Тестирование сортировки в массиве из 100 одинаковых элементов
            int[] array = new int[100];
            for (int i = 0; i < array.Length; i += 1)
                array[i] = 10;
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Сортировка массива из 100 одинаковых элементов не выдает ошибки");
        }

        private static void ThousandRandomElementsArray()
        {
            //Тестирование сортировки в массиве из 1000 случайных элементов
            var rnd = new Random();
            int check = 1;
            int[] array = new int[1000];
            for (int i = 0; i < array.Length; i += 1)
                array[i] = rnd.Next(0, 1000);
            QuickSort(array, 0, array.Length - 1);
            for (int i = 0; i < 10; i += 1)
            {
                int first_rnd = rnd.Next(0, array.Length - 1);
                int second_rnd = rnd.Next(first_rnd, array.Length - 1);
                if (array[first_rnd] > array[second_rnd])
                    check = 0;
            }

            if (check == 1)
                Console.WriteLine("Сортировка массива из 1000 случайных элементов работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 1000 случайных элементов работает неверно");
        }

        private static void VoidArray()
        {
            //Тестирование сортировки в массиве из 100 одинаковых элементов
            int[] array = new int[] { };
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Сортировка пустого массива не выдает ошибки");
        }
    }
}