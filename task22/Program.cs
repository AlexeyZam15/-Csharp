// D2.6. Дан двумерный массив из m строк и n столбцов. Заполнить его значениями элементов одномерного массива размером m x n . 
// Заполнение проводить по строкам, начиная с первой (а в ней — начиная с первого элемента).

void PrintArray(int[] arr, string beginStr, string separatorElems, string endstr)
{
    Console.Write(beginStr);
    for (int i = 0; i < arr.Length; i++)
    {
        if (i < arr.Length - 1)
            Console.Write($"{arr[i]}{separatorElems} ");
        else Console.Write($"{arr[i]}");
    }
    Console.Write(endstr);
}

void PrintMatrix(int[,] matrix, string beginRow, string separatorElems, string endRow)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write(beginRow);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1)
                Console.Write($"{matrix[i, j],4}{separatorElems}");
            else Console.Write($"{matrix[i, j],4}");
        }
        Console.WriteLine(endRow);
    }
}

int[] CreateRndArray(int size, int min, int max)
{
    int[] array = new int[size];
    Random rnd = new Random();
    for (int i = 0; i < size; i++)
    {
        array[i] = rnd.Next(min, max + 1);
    }
    return array;
}

int[,] CreateMatrixFromArray(int rows, int columns, int[] array)
{
    int[,] matrix = new int[rows, columns];
    int arrayIndex = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = array[arrayIndex++];
        }
    }
    return matrix;
}

Console.Write($"Введите значение m: ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write($"Введите значение n: ");
int n = Convert.ToInt32(Console.ReadLine());

int[] array1 = CreateRndArray(m * n, 1, 99);
int[,] matrix1 = CreateMatrixFromArray(m, n, array1);
PrintArray(array1, @"Одномерный массив:
", "", "");
Console.WriteLine();
Console.WriteLine("Двумерный массив:");
PrintMatrix(matrix1, "", "", "");