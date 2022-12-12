//Вывести матрицу с помощью рекурсий.

int[,] CreateMatrixIncInt(int rows, int columns, int startNumber)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = startNumber++;
        }
    }
    return matrix;
}

void PrintMatrixRec(int[,] matrix, int rows, int columns)
{
    if (columns - 1 > -1)
    {
        PrintMatrixRec(matrix, rows, columns - 1);
        Console.Write($"{matrix[rows - 1, columns - 1],4}");
    }
    else if (rows - 1 != 0)
    {
        PrintMatrixRec(matrix, rows - 1, matrix.GetLength(1));
        Console.WriteLine();
    }
}

int[,] matrix1 = CreateMatrixIncInt(4, 4, 1);
PrintMatrixRec(matrix1, matrix1.GetLength(0), matrix1.GetLength(1));