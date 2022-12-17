// D2.7. Заполнить двумерный массив размером 5 5 так, 
// как представлено на рисунке (спираль).
// https://c-sharp.pro/wp-content/uploads/2020/11/d2.7.jpg
// D2.8. Заполнить двумерный массив размером 7 x 7 числами 1, 2, …, 49, расположенными в нем по спирали
// D2.9. Дан двумерный массив размером 9 x 9. Построить последовательность чисел, 
// получающуюся при чтении этого массива по спирали.

int[,] CreateMatrixIncIntSpiral(int rows, int columns, int startNumber)
{
    int[,] matrix = new int[rows, columns];
    int direction = 0;
    int size = matrix.Length;
    int indexi = 0;
    int indexj = 0;
    int directionLength = columns;
    int count = 0;
    while (count < size)
    {
        {
            for (int j = 0; j < directionLength; j++, count++)
            {
                // Console.WriteLine($"{direction} {directionLength} {indexi} {indexj} {startNumber + 1}");
                if (direction == 0)
                {
                    matrix[indexi, indexj++] = startNumber++;
                }
                else if (direction == 1)
                {
                    matrix[indexi++, indexj] = startNumber++;
                }
                else if (direction == 2)
                {
                    matrix[indexi, indexj--] = startNumber++;
                }
                else if (direction == 3)
                    matrix[indexi--, indexj] = startNumber++;
            }
            if (direction == 0)
            {
                rows--;
                directionLength = rows;
                indexj--;
                indexi++;
                direction = 1;
            }
            else if (direction == 1)
            {
                columns--;
                directionLength = columns;
                direction = 2;
                indexi--;
                indexj--;
            }
            else if (direction == 2)
            {
                rows--;
                directionLength = rows;
                direction = 3;
                indexj++;
                indexi--;
            }
            else if (direction == 3)
            {
                columns--;
                directionLength = columns;
                direction = 0;
                indexi++;
                indexj++;
            }
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
                Console.Write($"{matrix[i, j],3}{separatorElems}");
            else Console.Write($"{matrix[i, j],3}");
        }
        Console.WriteLine(endRow);
    }
}

Console.Write($"Введите кол-во строк матрицы: ");
int rows1 = Convert.ToInt32(Console.ReadLine());
Console.Write($"Введите кол-во столбцов матрицы: ");
int columns1 = Convert.ToInt32(Console.ReadLine());

int[,] matrix1 = CreateMatrixIncIntSpiral(rows1, columns1, 1);
PrintMatrix(matrix1, "", "", "");