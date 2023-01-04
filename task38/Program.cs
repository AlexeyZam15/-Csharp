// Все дети с 1 до N номерами шкафчиков открывают свои шкафчики.
// Дети с чётными номерами шкафчиков закрывают свои шкафчики.
// Дети с номерами шкафчиков, делимыми на 3, меняют состояние своего шкафчика на обратное.
// Дети с номерами шкафчиков, делимыми на 4, меняют состояние своего шкафчика на обратное.
// Дети с номерами шкафчиков, делимыми на N, меняют состояние своего шкафчика на обратное.
// ...
// С какими номера шкафчики останутся открытыми?

int[,] CreateIncIntMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    int number = 1;
    for (int i = 0; i < rows; i++)
    {
        matrix[i, 0] = number++;
    }
    return matrix;
}

void PrintmatrixIntSpecial(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    for (var i = 0; i < rows; i++)
        Console.Write($"{matrix[i, 0],3}");
    Console.WriteLine();
    for (int number = 2; number <= rows; number++)
    {
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, 0] % number == 0)
                if (matrix[i, 1] == 0)
                    matrix[i, 1] = 1;
                else matrix[i, 1] = 0;
            if (matrix[i, 1] == 0)
                Console.Write($"{matrix[i, 0],3}");
            else
                Console.Write($"{" ",3}");
        }
        Console.WriteLine();
    }
}

Console.Write($"Введите кол-во шкафчиков: ");
int n = Convert.ToInt32(Console.ReadLine());

int[,] matrix1 = CreateIncIntMatrix(n, 2);
PrintmatrixIntSpecial(matrix1);