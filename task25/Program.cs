// D2.11. Дан двумерный массив. Вывести на экран:
// а) все элементы третьей строки массива, начиная с последнего элемента этой строки;
// б) все элементы k-го столбца массива, начиная с нижнего элемента этого столбца.

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

void SpecialPrintMatrixRowFromColumnsEnd(int[,] matrix, int rowIndex)
{
    int columns = matrix.GetLength(1);
    for (int j = columns - 1; j >= 0; j--)
    {
        Console.Write($"{matrix[rowIndex, j]} ");
    }
}

void SpecialPrintMatrixColumnFromRowsEnd(int[,] matrix, int columnIndex)
{
    int rows = matrix.GetLength(0);
    for (int i = rows - 1; i >= 0; i--)
    {
        Console.Write($"{matrix[i, columnIndex]} ");
    }
}

int[,] matrix1 = CreateIncIntMatrix(4, 4, 1);
PrintMatrix(matrix1, "", "", "");

int numberChoice1 = ChoiceScheme(2, 'а', "");
if (numberChoice1 == 0)
    SpecialPrintMatrixRowFromColumnsEnd(matrix1, 3);
else if (numberChoice1 == 1)
{
    Console.Write("Введите номер столбца: ");
    int columnIndex1 = Convert.ToInt32(Console.ReadLine());
    SpecialPrintMatrixColumnFromRowsEnd(matrix1, columnIndex1 - 1);
}