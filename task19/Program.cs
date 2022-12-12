// D2.3. Заполнить массив размером 6 x 6 так, как показано на рисунках а, б.
// https://c-sharp.pro/wp-content/uploads/2020/11/d2.3.jpg

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

void FillArraySchemeA(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (i != 0 && j != 0)
            {
                matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
            }
            else matrix[i, j] = 1;
        }
    }
}

void FillArraySchemeB(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0, number = i + 1; j < columns; j++, number++)
        {
            if (number > 6) number = 1;
            matrix[i, j] = number;
        }
    }
}

int ChoiceScheme()
{
    char choice = Convert.ToChar("0");
    int numberChoice = -1;
    while (numberChoice == -1)
    {
        Console.WriteLine("Выберите схему: а или б");
        choice = Console.ReadKey(true).KeyChar;
        if (choice == Convert.ToChar("а")) numberChoice = 0;
        else if (choice == Convert.ToChar("б")) numberChoice = 1;
        else Console.WriteLine("Неправильный ввод");
    }
    return numberChoice;
}

int[,] matrix1 = new int[6, 6];

int numberChoice1 = ChoiceScheme();
if (numberChoice1 == 0) FillArraySchemeA(matrix1);
else FillArraySchemeB(matrix1);

PrintMatrix(matrix1, "", "", "");