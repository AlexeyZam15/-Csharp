// D3.11. В двумерном массиве хранится информация о количестве учеников в каждом классе каждой параллели школы 
// с первой по пятую(в первом столбце — информация о классах первой параллели, во втором — второй параллели и т. д.). 
// В каждой параллели школы учатся 11 классов. Составить программу для расчета общего числа учеников в любой параллели.

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

void PrintColumnsNumbers(int[,] matrix)
{
    int columns = matrix.GetLength(1);
    Console.Write($"{" ",4}");
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"{j + 1,4}");
    }
    Console.WriteLine();

}

void PrintMatrixWithNumbers(int[,] matrix, string beginRow, string separatorElems, string endRow)
{
    PrintColumnsNumbers(matrix);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{i + 1,4}");
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

int ElementsMatrixColumnSum(int[,] matrix, int columnIndex)
{
    int sum = 0;
    int rows = matrix.GetLength(0);
    for (int i = 0; i < rows; i++)
    {
        sum += matrix[i, columnIndex];
    }
    return sum;
}

int[,] Pupils = CreateRandomIntMatrix(11, 5, 20, 25);
PrintMatrixWithNumbers(Pupils, "", "", "");

int parallelsCount = Pupils.GetLength(1);
int parallel = -1;

while (parallel < 0 || parallel > parallelsCount)
{
    Console.WriteLine($"Введите номер паралели");
    parallel = Convert.ToInt32(Console.ReadLine());
    if (parallel < 0 || parallel > parallelsCount)
        Console.WriteLine($"Введены неверные данные");
}

int parallelPupils = ElementsMatrixColumnSum(Pupils, parallel - 1);
Console.WriteLine($"Общее число учеников на {parallel} параллели = {parallelPupils}");
