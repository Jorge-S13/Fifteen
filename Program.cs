using System;
using System.IO;
using System.Threading;

// Минимальный размер доски
const int MIN = 3;

// Максимальный размер доски
const int MAX = 9;

// Доска, где board[i][j] представляет строку i и столбец j
int[,] board = new int[MAX, MAX];

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
    Thread.Sleep(2000);
}

void Init()
{
    // TODO
}

void Draw()
{
    // TODO
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

void Save()
{
    // Лог файл
    const string log = "log.txt";

    // Удаляем существующий лог при первом сохранении
    bool saved = false;
    if (!saved)
    {
        if (File.Exists(log))
        {
            File.Delete(log);
        }
        saved = true;
    }

    // Открываем лог для записи
    using (StreamWriter sw = new StreamWriter(log, true))
    {
        sw.Write("{");
        for (int i = 0; i < d; i++)
        {
            sw.Write("{");
            for (int j = 0; j < d; j++)
            {
                sw.Write(board[i, j]);
                if (j < d - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write("}");
            if (i < d - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write("}\n");
    }
}

// Основная функция
void Main(string[] args)
{
    // Приветствуем игрока
    Greet();

    // Проверяем правильность использования
    if (args.Length != 1)
    {
        Console.WriteLine("Usage: fifteen d");
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

        // Сохраняем текущее состояние доски (для тестирования)
        Save();

        // Проверяем на победу
        if (Won())
        {
            Console.WriteLine("ftw!");
            break;
        }

        // Запрашиваем ход
        Console.Write("Tile to move: ");
        int tile;
        string? input = Console.ReadLine();

        if(input != null && int.TryParse(input, out tile))
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
}

// Вызов функции Main с аргументами
Main(Environment.GetCommandLineArgs());
