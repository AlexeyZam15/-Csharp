// D2.10. Используя датчик случайных чисел, заполнить двумерный массив не повторяющимися числами.

void PrintMatrix(int[,] matrix, string beginRow, string separatorElems, string endRow)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write(beginRow);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1)
                Console.Write($"{matrix[i, j],3}{separatorElems}");
            else Console.Write($"{matrix[i, j],3}");
        }
        Console.WriteLine(endRow);
    }
}

bool CheckNumberArray(int[] array, int number)
{
    bool repeated = false;
    for (int i = 0; i < array.Length; i++)
    {
        if (number == array[i])
        {
            return true;
        }
    }
    return repeated;
}

int[,] CreateUnicRndIntMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    int[] allNumbers = new int[matrix.Length];
    Random rnd = new Random();
    int index = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int temp = 0;
            bool repeated = true;
            while (repeated == true)
            {
                temp = rnd.Next(min, max + 1);
                repeated = CheckNumberArray(allNumbers, temp);
            }
            matrix[i, j] = temp;
            allNumbers[index++] = temp;
        }
    }
    return matrix;
}

int[,] matrix1 = CreateUnicRndIntMatrix(4, 4, 1, 16);
PrintMatrix(matrix1, "", "", "");