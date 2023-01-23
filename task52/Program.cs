// Напишите программу, которая 
// 1. Ищет методом перебора загаданное случайным образом число
// 2. Ищет методом перебора загаданное случайным образом число, с помощью параллелирования.
// 3. Сравнить результаты выполнения алгоритмов по времени

using System.Diagnostics;


const int MIN = 0;
const int MAX = 1000000000;

Random rnd = new Random();
int hiddenNumber = rnd.Next(MIN, MAX);
Console.WriteLine($"Загадано число: {hiddenNumber}");

int EnumFindNumber(int foundNumb, int hiddenNumb, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        if (i == hiddenNumb)
        {
            foundNumb = i;
            break;
        }
    }
    return foundNumb;
}

int ParallelEnumFindNumber(int hiddenNumb, int min, int max, int ThreadsNumber)
{
    int foundNumb = min;
    int[] foundNumbThreads = new int[ThreadsNumber];
    int eachThreadCalc = max / ThreadsNumber;
    var threadsList = new List<Thread>();
    for (int i = 0; i < ThreadsNumber; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        //если последний поток
        if (i == ThreadsNumber - 1) endPos = max;
        // Console.WriteLine($"{i} {startPos} {endPos} {array1.GetLength(0)}");
        threadsList.Add(new Thread(() => foundNumbThreads[i] = EnumFindNumber(foundNumb, hiddenNumb, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < ThreadsNumber; i++)
    {
        threadsList[i].Join();
        if (foundNumbThreads[i] != min)
        foundNumb = foundNumbThreads[i];
    }
    return foundNumb;
}

Stopwatch sw = new Stopwatch();
sw.Start();
int serialFoundNumber = MIN;
serialFoundNumber = EnumFindNumber(serialFoundNumber, hiddenNumber, MIN, MAX);
sw.Stop();
Console.WriteLine($"Найдено число: {serialFoundNumber}");
Console.WriteLine($"Time serial enumeration find number = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
int parallelFoundNumber = ParallelEnumFindNumber(hiddenNumber, MIN, MAX, ThreadsNumber: 10);
sw.Stop();
Console.WriteLine($"Найдено число: {parallelFoundNumber}");
Console.WriteLine($"Time parallel enumeration find number = {sw.ElapsedMilliseconds} Milliseconds");