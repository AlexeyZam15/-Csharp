// D3.9. В двумерном массиве хранится информация о зарплате 18 человек за каждый месяц года 
// (за январь — в первом столбце, за февраль — во втором и т. д.). Определить общую зарплату, выплаченную в июне.

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
        Console.Write($"{j+1,4}");
    }
    Console.WriteLine();

}

void PrintMatrixWithNumbers(int[,] matrix, string beginRow, string separatorElems, string endRow)
{
    PrintColumnsNumbers(matrix);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{i+1,4}");
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

int[,] salary = CreateRandomIntMatrix(18, 12, 500, 600);
PrintMatrixWithNumbers(salary, "", "", "");

int salaryForJune = ElementsMatrixColumnSum(salary, 5);
Console.WriteLine($"Общая зарплата сотрудников сотрудников за июнь = {salaryForJune}");
