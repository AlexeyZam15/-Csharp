// Загадано число от 1 до 100. Найти число с помощью алгоритма бинарного поиска.

Random rnd = new Random();
int hiddenNumber = rnd.Next(1, 101);
Console.WriteLine($"Загаданное число - {hiddenNumber}");

int IntBinarySearchWithPrintAlgorithm(int number, int min, int max)
{
    int foundNumber = max;
    while (true)
    {
        Console.Write($"{min,4} {foundNumber,4} {max,4}");
        if (min == number)
        {
            Console.WriteLine($"{"=",3}");
            return min;
        }
        if (number == foundNumber)
        {
            Console.WriteLine($"{"=",3}");
            return foundNumber;
        }
        if (number < foundNumber)
        {
            Console.WriteLine($"{"<",3}");
            max = foundNumber;
            foundNumber -= (foundNumber - min) / 2;
        }
        else
        {
             Console.WriteLine($"{">",3}");
            min = foundNumber;
            foundNumber += (max - min) / 2;
        }
    }
}

int foundNumber = IntBinarySearchWithPrintAlgorithm(hiddenNumber, 1, 100);
Console.WriteLine($"Найденное число - {foundNumber}");
