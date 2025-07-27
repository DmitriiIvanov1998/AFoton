using System;
using System.Text;

// Создаём основной класс
class Program

{
    // Создаем процедуру, не требующую конкретного объекта
    static void Main(string[] args)

    {
        // Задаём переменную
        int number = 100;
        
        // Делаем так, чтобы работали русские буквы
        Console.OutputEncoding = Encoding.UTF8;

        // Пишется в консоли то, что в кавычках
        // $ делает из строки умну/ строк
        Console.Write($"Извлечение квадратного корня из {number} в столбик");
        
        Console.WriteLine($" = {Math.Sqrt(number)}");
        ;

    }

    static string ManualSqrt(int number)

    {
        // переводим число в строку
        string numStr = number.ToString();
        
        // находим длину строки
        int len = numStr.Length;

        // находим максимальное кол-во групп
        int groups = (len + 1) / 2;

        // создаём пустой список ( массив ) 
        int[] pairs = new int[groups];


        // запускаем цикл
        for (int i = 0; i < len; i++)

        {
            if (len % 2 == 1 && i == 0)
            { // в случае, если длина не чётная и мы в начале цикла
            // то в первый элемент массива кладём первую цифру числа
                pairs[0] = int.Parse(numStr.Substring(0, 1));
            }
            // иначе 
            else
            {
                
                // инициируем переменную 
                int pairIndex = 0;
                // если длина нечетная
                if (len % 2 == 1)  
                
                    {
                    pairIndex = i / 2 + 1 ;
                    } 
                else  
                    {
                    pairIndex = i / 2 ;
                    }
                // сдвиг текущего значения в паре на разряд
                pairs[pairIndex] *= 10;
                // прибавляем следующую цифру
                pairs[pairIndex] += (numStr[i] - '0');
            }
            // итого на этом этапе имеем все пары чисел, которые составляют первоначальное число 

        }
        
        //
        string result = "";
        int remainder = 0;
        for (int i = 0; i < groups; i++)
        {   
            // Добавляем следующую пару к остатку
            int current = remainder * 100 + pairs[i];
            int x = 0;
            for (int j = 1; j <= 9; j++)
            {   // Подбираем такую цифру j, при которой
                int trial = (int.Parse(result + j.ToString()) * j);
                // — это наибольшее число, не превышающее current.
                if (trial <= current)
                { x = j;
                }
                else
                {
                    break;
                }
            }
            // Сохраняем x как наибольшее подходящее j.
            result += x.ToString();
            remainder = current - (int.Parse(result) * x);
        }
        return result;
    }

}
