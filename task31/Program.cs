// D3.4. В двумерном массиве хранится информация о баллах, полученных спортсменами-пятиборцами 
// в каждом из пяти видов спорта (в первой строке — информация о баллах первого спортсмена, 
// во второй — второго и т. д.). Общее число спортсменов равно 20. 
// Определить общую сумму баллов, набранных третьим спортсменом.

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

int[,] athletesPoints = CreateRandomIntMatrix(20, 5, 1, 10);
PrintMatrix(athletesPoints, "", "", "");

int thirdAthletePoints = ElementsMatrixRowSum(athletesPoints, 2);
Console.WriteLine($"Третий спортсмен набрал {thirdAthletePoints} баллов");
