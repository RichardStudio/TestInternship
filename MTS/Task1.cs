using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS
{
    class Task1
    {
        static void Main(string[] args)
        {
            try
            {
                FailProcess();
            }
            catch { }

            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }

        static void FailProcess()
        {
            //Вызываем исключение, которое нельзя отловить
            FailProcess();

            //2й вариант. Просто останавливаем выполнение программы.
            //Environment.Exit(0);
        }
    }
}
