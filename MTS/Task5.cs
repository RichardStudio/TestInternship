using System;
using System.IO;

namespace MTS
{
    class Task5
    {
        static void Main(string[] args)
        {
            TransformToElephant();
            Console.WriteLine("Муха");
            //... custom application code

            Console.WriteLine("Выполняется остальной код...");
        }

        static void TransformToElephant()
        {
            Console.WriteLine("Слон");
            Console.SetOut(new ElephantWriter());
        }

        class ElephantWriter : StringWriter
        {
            TextWriter tw = Console.Out;
            public override void WriteLine(string str)
            {
                if (str == "Муха")
                {
                    Console.SetOut(tw);
                }
            }
        }
    }
}