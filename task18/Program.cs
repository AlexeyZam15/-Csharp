// Заполнить двумерный массив размером 7 x 7 так, как показано на рисунках а, б, в. 
// https://c-sharp.pro/wp-content/uploads/2020/11/d2.2-2.jpg

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

void FillArrayBinarySchemeA(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (i == j || i + j == rows - 1)
            {
                matrix[i, j] = 1;
            }
        }
    }
}

void FillArrayBinarySchemeB(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (i == j || i + j == rows - 1 || i == 3 || j == 3)
            {
                matrix[i, j] = 1;
            }
        }
    }
}

void FillArrayBinarySchemeV(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0, c = 0; i < rows / 2 + 1; i++, c++)
    {
        for (int j = c; j < columns - c; j++)
        {
            matrix[i, j] = 1;
            matrix[rows - i - 1, columns - j - 1] = 1;
        }
    }
}

int[,] matrix1 = new int[7, 7];

int ChoiceScheme()
{
    char choice = Convert.ToChar("0");
    int numberChoice = -1;
    while (numberChoice == -1)
    {
        Console.WriteLine("Выберите схему: а, б или в");
        choice = Console.ReadKey(true).KeyChar;
        if (choice == Convert.ToChar("а")) numberChoice = 0;
        else if (choice == Convert.ToChar("б")) numberChoice = 1;
        else if (choice == Convert.ToChar("в")) numberChoice = 2;
        else Console.WriteLine("Неправильный ввод");
    }
    return numberChoice;
}

int numberChoice1 = ChoiceScheme();

if (numberChoice1 == 0) FillArrayBinarySchemeA(matrix1);
else if (numberChoice1 == 1) FillArrayBinarySchemeB(matrix1);
else FillArrayBinarySchemeV(matrix1);

PrintMatrix(matrix1, "", "", "");