// // D2.1. Заполнить двумерный массив результатами таблицы умножения 
// (в первой строке должны быть записаны произведения каждого из чисел от 1 до 9 на 1,
// // во второй — на 2, …, в последней — на 9).

// Метод для создания таблиц умножения от min числа до max;
int[,] CreateMatrixTableMult(int min, int max)
{
    int size = max - min + 2;
    int[,] matrix = new int[size, size];

    for (int i = 0, mult1 = min; i < size - 1; i++, mult1++)
    {
        matrix[i + 1, 0] = (mult1);
        matrix[0, i + 1] = (mult1);
    }

    for (int i = 1, mult1 = min; i < size; i++, mult1++)
    {
        for (int j = 1, mult2 = min; j < size; j++, mult2++)
        {
            matrix[i, j] = (mult1) * (mult2);
        }
    }

    return matrix;
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

Console.Write("Введите минимальное число таблицы умножения: ");
int minNumber = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное таблицы умножения: ");
int maxNumber = Convert.ToInt32(Console.ReadLine());

int[,] multTable = CreateMatrixTableMult(minNumber, maxNumber);
PrintMatrix(multTable, "", "", "");