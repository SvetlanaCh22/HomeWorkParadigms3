using System;

class Program
{
    static char[,] board = new char[3, 3]; // Двумерный массив для представления игровой доски
    static char currentPlayer = 'X'; // Игрок, который сейчас ходит

    static void Main()
    {
        InitializeBoard();
        bool gameOver = false;
        
        while (!gameOver)
        {
            PrintBoard();
            MakeMove();
            gameOver = CheckGameOver();
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Смена игрока
        }
        
        Console.WriteLine("Игра окончена!");
        PrintBoard();
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("  1 2 3");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + 1);

            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + board[i, j]);
            }

            Console.WriteLine();
        }
    }

    static void MakeMove()
    {
        int row = -1, col = -1;
        bool validMove = false;

        while (!validMove)
        {
            Console.WriteLine($"Ходит игрок {currentPlayer}. Введите координаты x и y (от 1 до 3):");
            int.TryParse(Console.ReadLine(), out row);
            int.TryParse(Console.ReadLine(), out col);
            row--; // Приводим к индексу массива
            col--;

            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
            {
                validMove = true;
            }
            else
            {
                Console.WriteLine("Неправильные координаты. Пожалуйста, попробуйте снова.");
            }
        }

        board[row, col] = currentPlayer;
    }

    static bool CheckGameOver()
    {
        // Проверка выигрышных комбинаций по горизонталям, вертикалям и диагоналям
        // Горизонтали
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
            {
                Console.WriteLine($"Игрок {currentPlayer} победил!");
                return true;
            }
        }

        // Вертикали
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[0, i] == board[2, i])
            {
                Console.WriteLine($"Игрок {currentPlayer} победил!");
                return true;
            }
        }

        // Диагонали
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
        {
            Console.WriteLine($"Игрок {currentPlayer} победил!");
            return true;
        }

        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
        {
            Console.WriteLine($"Игрок {currentPlayer} победил!");
            return true;
        }

        // Проверка на ничью
        bool isBoardFull = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                {
                    isBoardFull = false;
                    break;
                }
            }

            if (!isBoardFull)
            {
                break;
            }
        }

        if (isBoardFull)
        {
            Console.WriteLine("Ничья!");
            return true;
        }

        return false; // Игра еще не окончена
    }
}