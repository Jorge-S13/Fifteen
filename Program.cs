using System;
using System.IO;
using System.Threading;

// Минимальный размер доски
const int MIN = 3;

// Максимальный размер доски
const int MAX = 9;

// Доска, где board[i][j] представляет строку i и столбец j
int[,] board;
// Размер доски
int d;


// Прототипы функций
void Clear()
{
    Console.Clear();
}

void Greet()
{
    Clear();
    Console.WriteLine("GAME OF FIFTEEN");
    Thread.Sleep(1000);
}

void Init()
{
    board = new int[d, d];
}

void Draw()
{
    int rows = board.GetUpperBound(0) + 1;
    int columns = board.Length / rows;

    for(int i = 0; i < rows; i++){
        Console.WriteLine("\n");
        for(int j = 0; j < columns; j++){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{board[i,j]} \t");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
    Console.WriteLine("\n");
}

bool Move(int tile)
{
    // TODO
    return false;
}

bool Won()
{
    // TODO
    return false;
}


    // Приветствуем игрока
    Greet();

    // Проверяем правильность использования
    if (args.Length != 1 || !int.TryParse(args[0], out d))
    {
        Console.WriteLine("Usage: dotnet run d. Where \"d\" is board size");
        Console.WriteLine("Example: \"dotnet run 3\". Command create 3 x 3 game board.");
        return;
    }

    // Проверяем допустимость размеров доски
    d = int.Parse(args[0]);
    if (d < MIN || d > MAX)
    {
        Console.WriteLine($"Board must be between {MIN} x {MIN} and {MAX} x {MAX}, inclusive.");
        return;
    }

    // Инициализируем доску
    Init();

    // Принимаем ходы до тех пор, пока игра не будет выиграна
    while (true)
    {
        // Очищаем экран
        Clear();

        // Рисуем текущее состояние доски
        Draw();

        // Проверяем на победу
        if (Won())
        {
            Console.WriteLine("ftw!");
            break;
        }

        // Запрашиваем ход
        Console.Write("Tile to move: ");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int tile))
        {
        // Делаем ход, если возможно, иначе сообщаем об ошибке
        if (!Move(tile))
        {
            Console.WriteLine("\nIllegal move.");
            Thread.Sleep(500);
        }

        // Пауза для анимации
        Thread.Sleep(500);
        }
    }
