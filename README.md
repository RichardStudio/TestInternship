# Решения тестовых заданий на стажировку.

## Task 1
Смысл задачи, по моему мнению, в том, чтобы получить исключение, которое нельзя отловить. Тогда в голову сразу приходит StackOverflowException. Достаточно просто вызвать функцию внутри нее же и задача решена.

Следующее, о чем я подумал, это Enviroment.Exit. Это не совсем то решение, которого ждал автор задачи, как мне кажется, но в результате программа завершается, не доходя до строчки с выводом в консоль, а значит, удовлетворяет условиям.

Далее есть вариант использовать класс Marshal. При попытке копирования байта в память вылетает исключение AccessViolationException.

## Task 2
В данной задаче происходит конкатенация строк. Т. к. `someValue2` приводится к строковому типу, то `new Number(someValue1)` тоже приведется к нему же. Для решения данной задачи я переопределил оператор сложения в классе `Number` для сложения его же со строковыми типами.
```C#
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
```
## Task 3
В данной задаче я решил кидать исключение `ArgumentException` в том случае, если `tailLength` больше размера самой колекции. Далее мы проходим по коллекции, пока не дойдем до того индекса, с которого необходимо начинать отсчитывать хвост. Сам хвост считаем по нехитрой формуле `len - i - 1`, где `len` - длинна коллекции, `i` - индекс текущего элемента.
```C#
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

        oreach (var item in enumerable)
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
```
Возможно ли реализовать такой метод выполняя перебор значений перечисления только 1 раз? Полагаю что нет. Нужно знать количество всех элементов в коллекции, чтобы его узнать придется пробежаться по ней лишний раз.

## Task 4


