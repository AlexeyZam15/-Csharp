// D3.7. В двумерном массиве хранится информация о зарплате 20 человек за каждый месяц года 
// (первого человека — в первой строке, второго — во второй и т. д.). 
// Составить программу для расчета общей зарплаты, полученной за год любым человеком, 
// информация о зарплате которого представлена в массиве.

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
                Console.Write($"{matrix[i, j],4}{separatorElems}");
            else Console.Write($"{matrix[i, j],4}");
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

int[,] salary = CreateRandomIntMatrix(20, 12, 500, 600);
PrintMatrix(salary, "", "", "");

int employee = -1;
while (employee <= 0 || employee > salary.GetLength(0))
{
    Console.Write($"Введите номер человека: ");
    employee = Convert.ToInt32(Console.ReadLine());
    if (employee <= 0 || employee > salary.GetLength(0))
        Console.WriteLine("Введёны неверные данные.");
}

int yearSalary = ElementsMatrixRowSum(salary, employee - 1);
Console.WriteLine($"Годовая зарплата {employee}-го человека = {yearSalary}");