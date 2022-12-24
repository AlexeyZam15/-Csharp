// D2.13. Дан двумерный массив. Вывести на экран его элементы следующим образом:
// а) сначала элементы первой строки справа налево, затем второй строки справа налево и т. п.;
// б) сначала элементы первой строки справа налево, затем второй строки слева направо и т. п.;
// в) сначала элементы первого столбца сверху вниз, затем второго столбца сверху вниз и т. п.;
// г) сначала элементы первого столбца снизу вверх, затем второго столбца снизу вверх и т. п.

int[,] CreateIncIntMatrix(int rows, int columns, int startNumber)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = startNumber++;
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

char[] StringToCharArray(string str)
{
    if (str != "" && str != " ")
    {
        string[] arrString = str.Split(' ');
        char[] arr = new char[arrString.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Convert.ToChar(arrString[i]);
        }
        return arr;
    }
    else
    {
        char[] arr = { ' ' };
        return arr;
    }
}

int ChoiceScheme(int numberChoices, char startSymbol, string exceptionsSymbols)
{
    char[] exceptionsSymbolsArray = StringToCharArray(exceptionsSymbols);
    char choice = Convert.ToChar("0");
    int numberChoice = -1;
    char[] choicesAlphabet = new char[numberChoices];
    string Alphabet = string.Empty;
    for (int i = 0, j = 0; i < choicesAlphabet.Length; i++)
    {
        for (int k = 0; k < exceptionsSymbolsArray.Length; k++)
        {
            if (exceptionsSymbolsArray[k] == (char)(startSymbol + j))
            {
                j++;
            }
        }
        choicesAlphabet[i] = (char)(startSymbol + j++);
        Alphabet += choicesAlphabet[i];
    }
    while (numberChoice == -1)
    {
        Console.Write("Выберите схему: ");
        for (int i = 0; i < choicesAlphabet.Length; i++)
        {
            if (i < choicesAlphabet.Length - 1)
                Console.Write($"{choicesAlphabet[i]}, ");
            else Console.Write($"или {choicesAlphabet[i]}");
        }
        Console.WriteLine();
        choice = Console.ReadKey(true).KeyChar;
        for (int i = 0; i < choicesAlphabet.Length; i++)
            if (choicesAlphabet[i] == choice)
            {
                numberChoice = i;
                Console.WriteLine($"Выбрана схема {choicesAlphabet[i]}");
                break;
            }
        if (numberChoice == -1) Console.WriteLine("Неправильный ввод");
    }
    return numberChoice;
}

// а) сначала элементы первой строки справа налево, затем второй строки справа налево и т. п.;

void SpecialPrintMatrixFromColumnsEnd(int[,] matrix)
{
    int columns = matrix.GetLength(1);
    int rows = matrix.GetLength(0);
    for (int i = 0; i < rows; i++)
    {
        for (int j = columns - 1; j >= 0; j--)
        {
            Console.Write($"{matrix[i, j],3}");
        }
        Console.WriteLine();
    }
}

// б) сначала элементы первой строки справа налево, затем второй строки слева направо и т. п.;

void SpecialPrintMatrixOneColumnFromEndOneFromStart(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int indexj = 0;
    int direction = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (direction == 0)
                Console.Write($"{matrix[i, j],3}");
            else if (direction == 1)
                Console.Write($"{matrix[i, columns - 1 - j],3}");
        }
        if (direction == 0)
            direction = 1;
        else if (direction == 1)
            direction = 0;
        Console.WriteLine();
    }
}

// в) сначала элементы первого столбца сверху вниз, затем второго столбца сверху вниз и т. п.;

void SpecialPrintMatrixRows(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int j = 0; j < columns; j++)
    {
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"{matrix[i, j],3}");
        }
        Console.WriteLine();
    }
}

// г) сначала элементы первого столбца снизу вверх, затем второго столбца снизу вверх и т. п.

void SpecialPrintMatrixRowsFromRowsEnd(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    for (int j = 0; j < columns; j++)
    {
        for (int i = rows - 1; i >= 0; i--)
        {
            Console.Write($"{matrix[i, j],3}");
        }
        Console.WriteLine();
    }
}


int[,] matrix1 = CreateIncIntMatrix(5, 5, 1);
PrintMatrix(matrix1, "", "", "");

int numberChoice1 = ChoiceScheme(4, 'а', "");

if (numberChoice1 == 0)
{
    SpecialPrintMatrixFromColumnsEnd(matrix1);
}
else if (numberChoice1 == 1)
{
    SpecialPrintMatrixOneColumnFromEndOneFromStart(matrix1);
}
else if (numberChoice1 == 2)
{
    SpecialPrintMatrixRows(matrix1);
}
else if (numberChoice1 == 3)
{
    SpecialPrintMatrixRowsFromRowsEnd(matrix1);
}