using System;
using System.Text;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Количество вершин и рёбер
        Console.Write("Введите количество вершин: ");
        int n = int.Parse(Console.ReadLine());
        
        
        Console.Write("Введите количество рёбер: ");
        int m = int.Parse(Console.ReadLine());

        // Матрица смежности
        int[,] g = new int[n, n];


        // Парсим матрицу смежности из ручного ввода
        Console.WriteLine("Введите рёбра в формате: u v w  (можно также u-v-w)");
        for (int i = 0; i < m; i++)
        {
            var parts = Console.ReadLine().Split(new[] { ' ', '-', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int u = int.Parse(parts[0]);
            int v = int.Parse(parts[1]);
            int w = int.Parse(parts[2]);

            g[u, v] = w;
            g[v, u] = w; // граф неориентированный, поэтому зальём его симметричными значениями
        }

        // Выбираем стартовую вершину
        Console.Write("Введите стартовую вершину (0..n-1): ");
        int s = int.Parse(Console.ReadLine());

        // === АЛГОРИТМ ДЕЙКСТРЫ (поиск кратчайших путей) ===

        // dist[i] = кратчайшее найденное расстояние от стартовой вершины до вершины i
        int[] dist = new int[n];

        // used[i] = была ли вершина уже обработана
        bool[] used = new bool[n];

        // Изначально все расстояния считаем «бесконечными»
        for (int i = 0; i < n; i++) dist[i] = int.MaxValue;

        // До самой стартовой вершины расстояние = 0
        dist[s] = 0;

        // Основной цикл Дейкстры: повторяем n раз
        for (int k = 0; k < n; k++)
        {
            // === Шаг 1. Находим вершину v, которая ещё не обработана
            // и имеет минимальное расстояние dist[v]
            int v = -1;
            for (int i = 0; i < n; i++)
                if (!used[i] && (v == -1 || dist[i] < dist[v]))
                    v = i;

            // Если подходящей вершины нет или она недостижима → выходим
            if (v == -1 || dist[v] == int.MaxValue) break;

            // Помечаем вершину v как обработанную
            used[v] = true;

            // === Шаг 2. Обновляем расстояния до соседей вершины v
            for (int u = 0; u < n; u++)
            {
                if (g[v, u] > 0) // есть ребро v → u
                {
                    // Новое возможное расстояние до u через v
                    int nd = dist[v] + g[v, u];

                    // Если оно меньше старого — обновляем
                    if (nd < dist[u]) dist[u] = nd;
                }
            }
        }

        // === ВЫВОД РЕЗУЛЬТАТА ===

        // Радиус для выбранной вершины = самое большое расстояние до других вершин
        int radius = 0;
        for (int i = 0; i < n; i++)
            if (dist[i] != int.MaxValue && dist[i] > radius)
                radius = dist[i];

        // Выводим только число (радиус)
        Console.WriteLine(radius);
    }
}
