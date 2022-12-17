// D2.5. Заполнить двумерный массив размером n x n единицами и нулями таким образом, чтобы единицы размещались так, как размещаются на шахматной доске черные поля, а нули — как белые поля. Левое нижнее поле на шахматной доске всегда черное. Задачу решить:
// а) при четном значении n;
// б) при нечетном значении n.

Console.Write($"Введите значение n: ");
int n = Convert.ToInt32(Console.ReadLine());

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

int[,] CreateMatrixBinaryChessBoard(int size)
{
    int[,] matrix = new int[size, size];
    int number = 0;
    int direction = 0;
    int count = 1;
    int indexi = size - 1;
    int indexj = 0;
    while (count <= matrix.Length)
    {
        for (int j = 0; j < size; j++, count++)
        {
            if (number == 0)
                number = 1;
            else
                number = 0;
            if (direction == 0)
                matrix[indexi, indexj++] = number;
            else
                matrix[indexi, indexj--] = number;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi--;
            indexj--;
        }
        else
        {
            direction = 0;
            indexi--;
            indexj++;
        }
    }
    return matrix;
}

int[,] matrix1 = CreateMatrixBinaryChessBoard(n);
PrintMatrix(matrix1, "", "", "");