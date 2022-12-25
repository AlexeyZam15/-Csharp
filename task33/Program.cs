// D3.6. В двумерном массиве хранится информация о количестве студентов в той или иной группе каждого курса института 
// с первого по пятый (в первой строке — информация о группах первого курса, во второй — второго и т. д.). 
// На каждом курсе имеется 8 групп. Составить программу для расчета общего числа студентов на любом курсе.

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

int[,] students = CreateRandomIntMatrix(5, 8, 20, 25);
PrintMatrix(students, "", "", "");

int course = -1;

while (course <= 0 || course > students.GetLength(0))
{
    Console.Write($"Введите номер курса: ");
    course = Convert.ToInt32(Console.ReadLine());
    if (course <= 0 || course > students.GetLength(0))
        Console.WriteLine("Введёны неверные данные.");
}

int studentsCount = ElementsMatrixRowSum(students, course - 1);
Console.WriteLine($"Число студентов на {course} курсе = {studentsCount}");