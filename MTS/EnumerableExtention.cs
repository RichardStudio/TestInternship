using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public static class EnumerableExtention
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <exception cref="ArgumentNullException">Коллекция null</exception>
        /// <exception cref="OverflowException">Элементов в коллекции больше чем Int.MaxValue/></exception>
        /// <exception cref="ArgumentException">tailLength больше чем размер enumerable</exception>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            int len = enumerable.Count();

            if (tailLength != null && tailLength > len)
            {
                throw new ArgumentException("Кол-во элементов в коллекции меньше чем tailLength");
            }
            var result = new List<(T item, int? tail)>();

            if (tailLength.HasValue)
            {
                int i = 0;
                //Индекс, с которого начинаем считать хвост.
                int startIndex = len - tailLength.Value;

                foreach (var item in enumerable)
                {
                    if (i < startIndex)
                    {
                        result.Add((item, null));
                        i++;
                    }
                    else
                    {
                        result.Add((item, len - i - 1));
                        i++;
                    }
                }
            }

            return result;
        }
    }
}
