using System.Runtime.InteropServices;
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
    string[] arrString = str.Split(' ');
    char[] arr = new char[arrString.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = Convert.ToChar(arrString[i]);
    }
    return arr;
}

void FillArrayScheme0(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
            matrix[i, j] = number++;
}

void FillArrayScheme1(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int j = 0; j < columns; j++)
        for (int i = 0; i < rows; i++)
            matrix[i, j] = number++;
}

void FillArrayScheme2(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int i = 0; i < rows; i++)
        for (int j = columns - 1; j >= 0; j--)
            matrix[i, j] = number++;
}

void FillArrayScheme3(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int j = 0; j < columns; j++)
        for (int i = rows - 1; i >= 0; i--)
            matrix[i, j] = number++;
}

void FillArrayScheme4(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = 0;
    int indexj = 0;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < columns; j++)
        {
            if (direction == 0)
                matrix[indexi, indexj++] = number++;
            else if (direction == 1)
                matrix[indexi, indexj--] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi++;
            indexj--;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi++;
            indexj++;
        }
    }
}

void FillArrayScheme5(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = 0;
    int indexj = 0;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < rows; j++)
        {
            if (direction == 0)
                matrix[indexi++, indexj] = number++;
            else if (direction == 1)
                matrix[indexi--, indexj] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexj++;
            indexi--;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexj++;
            indexi++;
        }
    }
}

void FillArrayScheme6(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int i = rows - 1; i >= 0; i--)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = number++;
        }
    }
}

void FillArrayScheme7(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;

    for (int j = columns - 1; j >= 0; j--)
    {
        for (int i = 0; i < rows; i++)
        {
            matrix[i, j] = number++;
        }
    }
}

void FillArrayScheme8(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int i = rows - 1; i >= 0; i--)
    {
        for (int j = columns - 1; j >= 0; j--)
        {
            matrix[i, j] = number++;
        }
    }
}

void FillArrayScheme9(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    for (int j = columns - 1; j >= 0; j--)
    {
        for (int i = rows - 1; i >= 0; i--)
        {
            matrix[i, j] = number++;
        }
    }
}

void FillArrayScheme10(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = rows - 1;
    int indexj = 0;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < columns; j++)
        {
            if (direction == 0)
                matrix[indexi, indexj++] = number++;
            else if (direction == 1)
                matrix[indexi, indexj--] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi--;
            indexj--;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi--;
            indexj++;
        }
    }
}

void FillArrayScheme11(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = 0;
    int indexj = columns - 1;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < columns; j++)
        {
            if (direction == 0)
                matrix[indexi, indexj--] = number++;
            else if (direction == 1)
                matrix[indexi, indexj++] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi++;
            indexj++;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi++;
            indexj--;
        }
    }
}

void FillArrayScheme12(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = 0;
    int indexj = columns - 1;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < rows; j++)
        {
            if (direction == 0)
                matrix[indexi++, indexj] = number++;
            else if (direction == 1)
                matrix[indexi--, indexj] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi--;
            indexj--;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi++;
            indexj--;
        }
    }
}

void FillArrayScheme13(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = rows - 1;
    int indexj = 0;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < rows; j++)
        {
            if (direction == 0)
                matrix[indexi--, indexj] = number++;
            else if (direction == 1)
                matrix[indexi++, indexj] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi++;
            indexj++;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi--;
            indexj++;
        }
    }
}

void FillArrayScheme14(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = rows - 1;
    int indexj = columns - 1;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < columns; j++)
        {
            if (direction == 0)
                matrix[indexi, indexj--] = number++;
            else if (direction == 1)
                matrix[indexi, indexj++] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi--;
            indexj++;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi--;
            indexj--;
        }
    }
}

void FillArrayScheme15(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    int number = 1;
    int indexi = rows - 1;
    int indexj = columns - 1;
    int size = matrix.Length;
    int direction = 0;
    while (number <= size)
    {
        for (int j = 0; j < rows; j++)
        {
            if (direction == 0)
                matrix[indexi--, indexj] = number++;
            else if (direction == 1)
                matrix[indexi++, indexj] = number++;
        }
        if (direction == 0)
        {
            direction = 1;
            indexi++;
            indexj--;
        }
        else if (direction == 1)
        {
            direction = 0;
            indexi--;
            indexj--;
        }
    }
}

int[,] matrix1 = new int[12, 10];

int numberChoice1 = ChoiceScheme(16, 'а', "й");
if (numberChoice1 == 0) FillArrayScheme0(matrix1);
else if (numberChoice1 == 1) FillArrayScheme1(matrix1);
else if (numberChoice1 == 2) FillArrayScheme2(matrix1);
else if (numberChoice1 == 3) FillArrayScheme3(matrix1);
else if (numberChoice1 == 4) FillArrayScheme4(matrix1);
else if (numberChoice1 == 5) FillArrayScheme5(matrix1);
else if (numberChoice1 == 6) FillArrayScheme6(matrix1);
else if (numberChoice1 == 7) FillArrayScheme7(matrix1);
else if (numberChoice1 == 8) FillArrayScheme8(matrix1);
else if (numberChoice1 == 9) FillArrayScheme9(matrix1);
else if (numberChoice1 == 10) FillArrayScheme10(matrix1);
else if (numberChoice1 == 11) FillArrayScheme11(matrix1);
else if (numberChoice1 == 12) FillArrayScheme12(matrix1);
else if (numberChoice1 == 13) FillArrayScheme13(matrix1);
else if (numberChoice1 == 14) FillArrayScheme14(matrix1);
else if (numberChoice1 == 15) FillArrayScheme15(matrix1);

PrintMatrix(matrix1, "", "", "");