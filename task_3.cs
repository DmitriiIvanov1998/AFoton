using System.Collections.Generic;
using System;

using System.Text;

class Program

{
    
    // все варианты ходов коня
    static readonly int[] dx = { -2, -2, -1, -1, 1, 1, 2, 2 };
    static readonly int[] dy = { -1, 1, -2, 2, -2, 2, -1, 1 };

    const int boardSize = 100;

    static void Main()

    {
        
        Console.OutputEncoding = Encoding.UTF8;

        // Собираем координаты начала
        Console.Write("Введите координаты точки A (строка и столбец через пробел): ");

        string[] inputA = Console.ReadLine().Split();
        int startX = int.Parse(inputA[0]);
        int startY = int.Parse(inputA[1]);

        Console.Write("Введите координаты точки B (строка и столбец через пробел): ");

        // Собираем координаты конца
        string[] inputB = Console.ReadLine().Split();
        int endX = int.Parse(inputB[0]);
        int endY = int.Parse(inputB[1]);


        // проверка на то, что начало и конец лежат на доске
        if (!IsValidCell(startX, startY) || !IsValidCell(endX, endY))

        {

            Console.WriteLine("Ошибка: введены некорректные координаты.");
            return;

        }

        // проверка на то, что начало и конец равны
        if (startX == endX && startY == endY)
        {
            Console.WriteLine("Конь уже находится в точке B. Минимальное количество ходов: 0");
            return;
        }


        int result = MinKnightMoves(startX, startY, endX, endY);

        Console.WriteLine($"Минимальное количество ходов коня из точки A ({startX}, {startY}) в точку B ({endX}, {endY}): {result}");

    }

    static bool IsValidCell(int x, int y)
    {
        return x >= 1 && x <= boardSize && y >= 1 && y <= boardSize;
    }

    static int MinKnightMoves(int startX, int startY, int endX, int endY)

    {
        Queue<(int x, int y, int moves)> queue = new Queue<(int, int, int)>();
        
        // кладём нулевой ход
        queue.Enqueue((startX, startY, 0));

        // Массив посещённых клеток
        bool[,] visited = new bool[boardSize + 1, boardSize + 1];
        visited[startX, startY] = true;


        // Основной цикл BFS
        
        // пока в очереди есть числа
        while (queue.Count > 0)
        {
            // если мы закончили - то возвращаем ход
            
            ///// забираем первое с конца число
            var (x, y, moves) = queue.Dequeue();
            
            ///// если мы на финише - возвращаем кол-во ходом
            if (x == endX && y == endY)
                return moves;
            
            // проверяем все возможные ходы
            for (int i = 0; i < 8; i++)
            {
                int nextX = x + dx[i];
                int netY = y + dy[i]
                if (IsValidCell(nextX, nextY) && !visited[nextX, nextY])
                // отмечаем все посещённые клетки и делаем новые очереди
                {
                    visited[nextX, nextY] = true;
                    queue.Enqueue((nextX, nextY, moves + 1));
                }

            }

        }

        return -1;
    }
}

    
