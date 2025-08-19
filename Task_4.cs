using System;
using System.Text;


class Program

{

    static void Main(string[] args)

    {
        
        Console.OutputEncoding = Encoding.UTF8;

        // собираем количество полей
        Console.Write("Введите количество статей (n): ");

        int n = Convert.ToInt32(Console.ReadLine());

        // размер списка = кол-во статей
        int[] citations = new int[n];


        // собираем количество цитирований по каждому полю
        Console.WriteLine("Введите количество цитирований для каждой статьи:");

        for (int i = 0; i < n; i++)

        {
            // заполняем каждую ячейку этого списка 
            citations[i] = Convert.ToInt32(Console.ReadLine());

        }

        int hIndex = CalculateHIndex(citations);

        Console.WriteLine($"H-индекс ученого: {hIndex}");

    }

    static int CalculateHIndex(int[] citations)

    {

        // индекс Хирша не может быть больше чем кол-во статей
        int n = citations.Length;

        int[] count = new int[n + 1];

        // проходимся циклом по  цитированию каждой статьи
        for (int i = 0; i < n; i++)

        {
            
            // если цитирований больше, чем длина списка, то увеличиваем счетчик на 1
            if (citations[i] >= n)

            {

                count[n]++;

            }

            else

            {
            // тут храним, сколько раз встречается каждое цитировниае 
                count[citations[i]]++;

            }

        }

        int total = 0;

        // идем сверху от N до H
        for (int h = n; h >= 0; h--)

        {
        
            // суммируем то, сколько раз встречались эти статьи и все бОльшие
            total += count[h];


            // сумма стала больше, чем кол-во статей - то выходим
            if (total >= h)

            {

                return h;

            }

        }

        return 0;

    }

}
