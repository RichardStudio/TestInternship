using System;
using System.Collections.Generic;


namespace MTS
{
    class Task4
    {
        static void Main(string[] args)
        {
            var arr = new[] { 0, 0, 0, 2, 1, 5, 4, 3 };
            var res = Sort(arr, 3, 10);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            //Массив размером от 0 до максимального возможного числа в потоке. Индекс - число, попавшееся в потоке,
            //а значение по этому индексу кол-во таких чисел.
            var arr = new int[maxValue + 1];
            //Минимальное число, которое может далее попасться в потоке.
            int minFact = 0;
            //Минимальное число, которое попадалось.
            int minNum = 1_000_000_001;

            foreach (var item in inputStream)
            {
                //Увеличиваем кол-во чисел с таким значением
                arr[item]++;

                //Проверяем минимальность.
                if (minNum > item)
                {
                    minNum = item;
                }

                //Проверяем, не изменилось ли минимальное число, которое может попасться в потоке.
                if (minFact < item - sortFactor)
                {
                    minFact = item - sortFactor;
                }

                //Когда у нас есть числа, которые уже не могут попасться мы можем спокойно их возвращать от меньшего к большему.
                while (minNum < minFact)
                {
                    while (arr[minNum] > 0)
                    {
                        arr[minNum]--;
                        yield return minNum;
                    }
                    minNum++;
                }
            }

            //Возвращаем остатки после прохода по всей коллекции.
            while (minNum < arr.Length)
            {
                while (arr[minNum] > 0)
                {
                    arr[minNum]--;
                    yield return minNum;
                }
                minNum++;
            }

        }
    }
}
