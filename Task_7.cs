using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Введите количество строк (m)");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов (n):");
        int n = int.Parse(Console.ReadLine());

        long sumAbs = 0;          // сумма модулей
        int negCount = 0;         // количество отрицательных
        bool hasZero = false;     // есть ли ноль
        long minAbs = long.MaxValue; // минимальный модуль

        Console.WriteLine("Теперь введите элементы таблицы по одному (каждое число с новой строки):");


        // собираем таблицу циклом
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // вводим по одному значению
                long value = long.Parse(Console.ReadLine());

                // собираем кол-во отрицательных чисел
                if (value < 0) negCount++;
                // собираем кол-во нулей
                if (value == 0) hasZero = true;

                    
                // ищем сумму модулей всех чисел
                long absValue = Math.Abs(value);
                sumAbs += absValue;

                // так же ищем самое близкое к 0 отрициательное число
                if (absValue < minAbs)
                    minAbs = absValue;
            }
        }

        long answer;
        // если у есть нули ИЛИ четно количество отрицательных чисел
        // то мы сможет всё привести к плюсу 
        // и отметом будет сумма модулей
        if (hasZero || (negCount % 2 == 0))
            answer = sumAbs;
        // иначе вычтем из суммы самое маленькое по модулю 
        // отрицательное число
        else
            answer = sumAbs - minAbs  - minAbs;

        Console.WriteLine("Максимальная сумма = " + answer);
    }
}
