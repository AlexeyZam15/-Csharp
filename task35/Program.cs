// D3.8. В поезде 18 вагонов, в каждом из которых 36 мест. 
// Информация о проданных на поезд билетах хранится в двумерном массиве, 
// номера строк которых соответствуют номерам вагонов, а номера столбцов — номерам мест. 
// Если билет на то или иное место продан, то соответствующий элемент массива имеет значение 1, 
// в противном случае — 0. Составить программу, определяющую число свободных мест в любом из вагонов поезда.

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
                Console.Write($"{matrix[i, j],2}{separatorElems}");
            else Console.Write($"{matrix[i, j],2}");
        }
        Console.WriteLine(endRow);
    }
}

int NumberMatrixRowCount(int[,] matrix, int rowIndex, int number)
{
    int count = 0;
    int columns = matrix.GetLength(1);
    for (int j = 0; j < columns; j++)
    {
        if (matrix[rowIndex, j] == number)
            count++;
    }
    return count;
}

int[,] train = CreateRandomIntMatrix(18, 36, 0, 1);
PrintMatrix(train, "", "", "");

int carriage = -1;
while (carriage <= 0 || carriage > train.GetLength(0))
{
    Console.Write($"Введите номер вагона: ");
    carriage = Convert.ToInt32(Console.ReadLine());
    if (carriage <= 0 || carriage > train.GetLength(0))
        Console.WriteLine("Введёны неверные данные.");
}

int freePlaces = NumberMatrixRowCount(train, carriage - 1, 0);
Console.WriteLine($"Количество свободных мест в вагоне номер {carriage} = {freePlaces}");