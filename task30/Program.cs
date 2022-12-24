// D3.3. В двумерном массиве хранится информация о количестве учеников 
// в каждом классе каждой параллели школы с первого по одиннадцатый
// (в первой строке — информация о параллелях первого класса, во второй — параллелях второго класса и т. д.). 
// В каждом классе школы имеются четыре параллели
// Определить общее число учеников в параллели 5-х классов.

int[,] CreateRandomIntMatrix(int rows, int columns, int min, int max)
{
    Random rnd = new Random();
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix, string beginRow, string separatorElems, string endRow)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{beginRow}");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1)
                Console.Write($"{matrix[i, j],3}{separatorElems}");
            else Console.Write($"{matrix[i, j],3}");
        }
        Console.WriteLine(endRow);
    }
}

int ElementsMatrixRowSum(int[,] matrix, int rowIndex)
{
    int sum = 0;
    int columns = matrix.GetLength(1);
    for (int j = 0; j < columns; j++)
    {
        sum += matrix[rowIndex, j];
    }
    return sum;
}

int[,] pupilsAmount = CreateRandomIntMatrix(11, 4, 15, 25);
PrintMatrix(pupilsAmount, "", "", "");
int pupilsSum = ElementsMatrixRowSum(pupilsAmount, 4);
Console.WriteLine($"Общее число учеников 5-ых классов: {pupilsSum}");
