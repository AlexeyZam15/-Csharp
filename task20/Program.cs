// D2.4. Заполнить двумерный массив так, как представлено на рис. a — р.
// https://c-sharp.pro/wp-content/uploads/2020/11/d2.4_1.jpg

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

int ChoiceScheme(int numberChoices, char startSymbol)
{
    char choice = Convert.ToChar("0");
    int numberChoice = -1;
    char[] choicesAlphabet = new char[numberChoices];
    string Alphabet = string.Empty;
    for (int i = 0, j = 0; i < choicesAlphabet.Length; i++)
    {
        if ((char)(startSymbol + i) != 'й')
            choicesAlphabet[i] = (char)(startSymbol + j++);
        else
        {
            choicesAlphabet[i] = (char)(startSymbol + j++ + 1);
            j++;
        }
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

int[,] matrix1 = new int[6, 6];

int numberChoice1 = ChoiceScheme(16, 'а');
if (numberChoice1 == 0) FillArraySchemeA(matrix1);
else FillArraySchemeB(matrix1);

PrintMatrix(matrix1, "", "", "");