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
    int value = d * d - 1;

    int rows = board.GetLength(0);
    int columns = board.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            board[i, j] = value;
            value--;
        }
    }

    // Если это четная доска (например, 4x4, 6x6), меняем местами 1 и 2
    if (d % 2 == 0)
    {
        (board[rows - 1, columns - 2], board[rows - 1, columns - 3]) = (board[rows - 1, columns - 3], board[rows - 1, columns - 2]);
    }
}


void Draw()
{
    int rows = board.GetLength(0);
    int columns = board.GetLength(1);

    Console.ForegroundColor = ConsoleColor.Green;
    for(int i = 0; i < rows; i++){
        Console.WriteLine("\n");
        for(int j = 0; j < columns; j++){
            if(board[i, j] == 0){
                Console.Write(" \t");
            }else{
                Console.Write($"{board[i,j]} \t");
            }

        }
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\n");
}

bool Move(int tile)
{
    (int row, int col) = FindElement(board, tile);
    
    if(row != -1 && col != -1){
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        // Проверяем вверх
        if (row - 1 >= 0 && board[row - 1, col] == 0){

            (board[row -1, col], board[row,col]) = (board[row,col], board[row -1, col]);
            return true;
        }
        // Проверяем вниз
        if (row + 1 < rows && board[row + 1, col] == 0){
            (board[row + 1, col], board[row,col]) = (board[row,col], board[row + 1, col]);
            return true;
        } 
        // Проверяем влево
        if (col - 1 >= 0 && board[row, col - 1] == 0){
            (board[row, col - 1], board[row,col]) = (board[row,col], board[row, col - 1]);
            return true;
        } 
        // Проверяем вправо
        if (col + 1 < cols && board[row, col + 1] == 0){
            (board[row, col + 1], board[row,col]) = (board[row,col], board[row, col + 1]);
            return true;
        }     
    }
    return false;
}

bool Won()
{
    int rows = board.GetLength(0);
    int columns = board.GetLength(1);

    int expectedValue = 1; // Первое число, которое должно стоять на доске

    // Проверяем все элементы доски, кроме последнего
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            // Если это последний элемент, он должен быть равен 0
            if (i == rows - 1 && j == columns - 1)
            {
                if (board[i, j] != 0)
                {
                    return false;
                }
            }
            // Все остальные элементы должны идти по порядку от 1 до d*d-1
            else if (board[i, j] != expectedValue)
            {
                return false;
            }

            expectedValue++;
        }
    }
    return true;
}

(int i, int j) FindElement(int[,] array,int tile){
    int rows = board.GetLength(0);
    int columns = board.GetLength(1);

    for(int i = 0;i < rows; i++){
        for(int j = 0;j < columns;j++) {
            if(array[i,j] == tile){
                return (i,j);
            }
        }
    }
    return(-1,-1);
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
