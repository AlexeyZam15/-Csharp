// Составить программу для решения задачи методом перебора. 
// Вместо букв A, B, C, D, E, F расставьте числа 1, 2, 3, 4, 5, 6 так, 
// чтобы получилось верное равенство AB^C = DE^F
// (каждое число должно использоваться ровно один раз).

void BustingNotRepeatedInt(int startNumber, int endNumber, out int ab, out int c, out int de, out int f)
{
    bool end = false;
    ab = 0;
    c = 0;
    de = 0;
    f = 0;
    for (int i = startNumber; i <= endNumber; i++)
    {
        if (end == true) break;
        for (int j = startNumber; j <= endNumber; j++)
        {
            if (j != i)
                for (int k = startNumber; k <= endNumber; k++)
                {
                    if (k != j && k != i)
                        for (int l = startNumber; l <= endNumber; l++)
                        {
                            if (l != k && l != j && l != i)
                                for (int n = startNumber; n <= endNumber; n++)
                                {
                                    if (n != l && n != k && n != j && n != i)
                                        for (int m = startNumber; m <= endNumber; m++)
                                        {
                                            if (m != n && m != l && m != k && m != j && m != i)
                                            {
                                                int[] array = { i, j, k, l, n, m };
                                                if (Math.Pow(array[0] + array[1] * 10, array[2]) == Math.Pow(array[3] + array[4] * 10, array[5]))
                                                {
                                                    ab = array[0] + array[1] * 10;
                                                    c = array[2];
                                                    de = array[3] + array[4] * 10;
                                                    f = array[5];
                                                    end = true;
                                                }
                                            }
                                        }
                                }
                        }
                }
        }
    }
}

int[,] BustingNotRepeatedIntArrays(int startNumber, int endNumber)
{
    int size = 0;
    for (int i = startNumber; i <= endNumber; i++)
    {
        for (int j = startNumber; j <= endNumber; j++)
        {
            if (j != i)
                for (int k = startNumber; k <= endNumber; k++)
                {
                    if (k != j && k != i)
                        for (int l = startNumber; l <= endNumber; l++)
                        {
                            if (l != k && l != j && l != i)
                                for (int n = startNumber; n <= endNumber; n++)
                                {
                                    if (n != l && n != k && n != j && n != i)
                                        for (int m = startNumber; m <= endNumber; m++)
                                        {
                                            if (m != n && m != l && m != k && m != j && m != i)
                                            {
                                                int[] array = { i, j, k, l, n, m };
                                                if (Math.Pow(array[0] + array[1] * 10, array[2]) == Math.Pow(array[3] + array[4] * 10, array[5]))
                                                {
                                                    size++;
                                                }
                                            }
                                        }
                                }
                        }
                }
        }
    }
    int[,] array1 = new int[size, 4];

    int index = 0;
    for (int i = startNumber; i <= endNumber; i++)
    {
        for (int j = startNumber; j <= endNumber; j++)
        {
            if (j != i)
                for (int k = startNumber; k <= endNumber; k++)
                {
                    if (k != j && k != i)
                        for (int l = startNumber; l <= endNumber; l++)
                        {
                            if (l != k && l != j && l != i)
                                for (int n = startNumber; n <= endNumber; n++)
                                {
                                    if (n != l && n != k && n != j && n != i)
                                        for (int m = startNumber; m <= endNumber; m++)
                                        {
                                            if (m != n && m != l && m != k && m != j && m != i)
                                            {
                                                int[] array = { i, j, k, l, n, m };
                                                if (Math.Pow(array[0] + array[1] * 10, array[2]) == Math.Pow(array[3] + array[4] * 10, array[5]))
                                                {
                                                    array1[index, 0] = array[0] + array[1] * 10;
                                                    array1[index, 1] = array[2];
                                                    array1[index, 2] = array[3] + array[4] * 10;
                                                    array1[index, 3] = array[5];
                                                    index++;
                                                }
                                            }
                                        }
                                }
                        }
                }
        }
    }
    return array1;
}

void PrintMatrixSpecial(int[,] matrix, string beginRow, string afterEvenColumn, string afterOddColumn, string endRow)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        Console.Write(beginRow);
        for (int j = 0; j < columns; j++)
        {
            if (j < columns - 1)
            {
                if (j % 2 == 0)
                    Console.Write($"{matrix[i, j]}{afterEvenColumn}");
                else Console.Write($"{matrix[i, j]}{afterOddColumn}");
            }
            else Console.Write($"{matrix[i, j]}");
        }
        Console.WriteLine(endRow);
    }
}

// int ab1, de1, c1, f1;
// BustingNotRepeatedInt(1, 6, out ab1, out c1, out de1, out f1);
// Console.WriteLine($"{ab1}^{c1} {de1}^{f1}");

int[,] matrix1 = BustingNotRepeatedIntArrays(1, 6);
PrintMatrixSpecial(matrix1, "", "^", " = ", "");