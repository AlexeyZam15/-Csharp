// Напишите программу, которая 
// 1. Находит сумму элеметов массива
// 2. Находит сумму элеметов массива, с помощью параллелирования
// 3. Сравнить результаты выполнения алгоритмов по времени

using System.Diagnostics;

using static Infrastucture;

int SumElementsArray(int[] array, int startPos, int endPos)
{
    int sum = 0;
    for (var i = startPos; i < endPos; i++)
    {
        sum += array[i];
    }
    return sum;
}

int ParallelSumElementsArray(int[] array, int THREADS_NUMBER)
{
    int sum = 0;
    int index = 0;
    int[] sumThread = new int[THREADS_NUMBER];
    int size = array.Length;
    int eachThreadCalc = size / THREADS_NUMBER;
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        //если последний поток
        if (i == THREADS_NUMBER - 1) endPos = size;
        threadsList.Add(new Thread(() => sumThread[index++] = SumElementsArray(array, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
        sum += sumThread[i];
    }
    return sum;
}

const int ARRAYS_SIZE = 10000000;

int[] arr = new int[ARRAYS_SIZE];
ParallelFillArray(arr, 0, 9, 10);
// Console.WriteLine(string.Join(" ", arr));

Stopwatch sw = new();

sw.Start();
int serialSum = SumElementsArray(arr, 0, arr.Length);
sw.Stop();

Console.WriteLine($"Сумма элементов массива = {serialSum}");
Console.WriteLine($"Serial sum elements of array = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
int parallelSum = ParallelSumElementsArray(arr, 10);
sw.Stop();

Console.WriteLine($"Сумма элементов массива = {parallelSum}");
Console.WriteLine($"Parallel sum elements of array = {sw.ElapsedMilliseconds} Milliseconds");