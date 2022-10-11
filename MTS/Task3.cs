using System;
using System.Collections.Generic;
using System.Linq;

namespace MTS
{
    class Task3
    {
        static void Main(string[] args)
        {
            var arr = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var res = arr.EnumerateFromTail(7);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
