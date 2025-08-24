using System;
using System.Text;

class Program

{

    static void Main(string[] args)

    {
        // собираем информацию, в каком доме сколько чего 
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введите количество денег в каждом доме, разделённое запятой");



        string input = Console.ReadLine();

        // создали массив, где каждое значение - количество деняк в доме
        int[] houses = Array.ConvertAll (input.Split(' '), int.Parse);


        
        int maxProfit = FindMaxProfit (houses);

        Console.WriteLine("Максиальный выйгрыш: " + maxProfit);

    }


    // собстна, функция по поиску максимальной выгоды
    static int FindMaxProfit(int[] houses)

    {

        // создаем перемен
        int n = houses.Length;


        // проводим базовые проверки
        if (n == 0) return 0;

        if (n == 1) return houses[0];

        if (n == 2) return Math.Max(houses[0], houses[1]);

        // конец базовым проверкам
        // 
        int prev1 = 0;

        int prev2 = 0;

        // создаём цикл  по всем домам
        for (int i = 0; i < n; i++)

        {
            // на каждом этапе проверяем, что больше: прошлый или текущий + препредыдущий
            int current = Math.Max(prev2, prev1 + houses[i]);

            // сдвигаем 
            prev1 = prev2;

            // сдвигаем
            prev2 = current;

        }

        // возвращаем последний выигрыш
        return prev2;

    }

}
