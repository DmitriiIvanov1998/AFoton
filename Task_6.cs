using System;
using System.Text;

class Program

{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введите длину массива (n):");

        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Введите " + n + " элементов массива в порядке возрастания:");

        for (int i = 0; i < n; i++)
        {
            int currentElement = int.Parse(Console.ReadLine());
            if (i > 0 && currentElement < array[i - 1])

            {
                Console.WriteLine("Ошибка: элемент должен быть больше или равен предыдущему. Попробуйте снова.");
                i--; // Уменьшаем счетчик, чтобы повторить ввод для этого индекса
            }

            else

            {
                array[i] = currentElement;
            }

        }

        Console.WriteLine("Введите число k:");

        int k = int.Parse(Console.ReadLine());

        // Инициализируем два указателя

        int left = 0;

        int right = n - 1;

        bool found = false;

        // Находим два числа, которые в сумме дают k

        while (left < right)

        {

            int sum = array[left] + array[right];

            if (sum == k)

            {

                Console.WriteLine("Найдены числа: " + array[left] + " и " + array[right]);

                found = true;

                break;

            }

            else if (sum < k)

            {

                left++; // Увеличиваем левый указатель, чтобы увеличить сумму

            }

            else

            {

                right--; // Уменьшаем правый указатель, чтобы уменьшить сумму

            }

        }

        if (!found)

        {

            Console.WriteLine("Числа, сумма которых равна " + k + ", не найдены.");

        }

    }

}


Что делает алгоритм:
Находит два числа из отсортированного массива, которые в сумме дают k.
    
Как работает:
Используются два указателя:
левый (left) — на начало массива,
правый (right) — на конец.
Если сумма этих двух чисел больше k, сдвигаем правый указатель влево.
Если меньше k, сдвигаем левый вправо.
Если равно — нашли нужную пару.
Процесс идёт, пока указатели не пересекутся.

Благодаря упорядоченности массива поиск идёт за O(n) и требует O(1) памяти.
