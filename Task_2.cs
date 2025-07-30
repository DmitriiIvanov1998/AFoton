using System;

using System.Text;
class Program

{

    static void Main()

    {
        
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Введите количество строк (m): ");

        int m = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов (n): ");

        int n = int.Parse(Console.ReadLine());

        int[,] table = new int[m, n];

        int value = 1; // Начальное значение

        for (int i = 0; i < m; i++)

        {

            for (int j = 0; j < n; j++)

            {

                table[i, j] = value;

                value++;

            }

        }

        Console.WriteLine("Сгенерированная таблица:");

        for (int i = 0; i < m; i++)

        {

            for (int j = 0; j < n; j++)

            {

                Console.Write(table[i, j] + "\t");

            }

            Console.WriteLine();

        }

        Console.Write("Введите число k, которое нужно найти: ");

        int k = int.Parse(Console.ReadLine());

        // начинаем с первой строки
        int row = 0;

        // начинаем с последнего столбца
        int col = n - 1;

        // пока говорим "не нашли"
        bool found = false;

        while (row < m && col >= 0)

        {

            if (table[row, col] == k)

            {

                found = true;

                Console.WriteLine($"Число {k} найдено в таблице на позиции ({row + 1}, {col + 1}).");

                break;

            }

            else if (table[row, col] > k)

            {

                col--;

            }

            else

            {

                row++;

            }

        }

        if (!found)

        {

            Console.WriteLine($"Число {k} отсутствует в таблице.");

        }

    }

}
