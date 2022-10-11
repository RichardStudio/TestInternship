using System;
using System.Globalization;


namespace MTS
{
    class Task2
    {
        static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

        class Number
        {
            readonly int _number;

            public Number(int number)
            {
                _number = number;
            }

            public override string ToString()
            {
                return _number.ToString(_ifp);
            }
            /// <summary>
            /// Перегрузка оператора сложения для сложения со строками.
            /// </summary>
            /// <param name="firstNum"></param>
            /// <param name="str"></param>
            /// <exception cref="ArgumentException">Строку нельзя преобразовать в целочисленное значение</exception>
            /// <returns>Строка с результатом сложения</returns>
            public static string operator +(Number firstNum, string str)
            {
                int secondNum = int.Parse(str);
                return (firstNum._number + secondNum).ToString();
            }
        }

        static void Main(string[] args)
        {
            int someValue1 = 10;
            int someValue2 = 5;

            string result = new Number(someValue1) + someValue2.ToString(_ifp);
            Console.WriteLine(result);
            Console.ReadKey();
        }

    }
}
