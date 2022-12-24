// D3.5. В зрительном зале 25 рядов, в каждом из которых 36 мест (кресел). 
// Информация о проданных билетах хранится в двумерном массиве, номера строк  
// которого соответствуют номерам рядов, а номера столбцов — номерам мест. 
// Если билет на то или иное место продан, то соответствующий элемент массива имеет значение 1, в противном случае — 0. 
// Составить программу, определяющую число проданных билетов на места в 12-м ряду.

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
    Console.Write($"{" ",3}");
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"{j+1,3}");
    }
    Console.WriteLine();

}

void PrintMatrixWithNumbers(int[,] matrix, string beginRow, string separatorElems, string endRow)
{
    PrintColumnsNumbers(matrix);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write($"{i+1,3}");
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

int[,] auditoriumTickets = CreateRandomIntMatrix(25, 36, 0, 1);
PrintMatrixWithNumbers(auditoriumTickets, "", "", "");

int soldTickets12row = ElementsMatrixRowSum(auditoriumTickets, 11);
Console.WriteLine($"В 12-м ряду продано {soldTickets12row} билетов");
