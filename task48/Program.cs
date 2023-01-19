// Напишите программу, которая 
// 1. Создаёт массив из рандомных чисел
// 2. Создаёт массив из рандомных чисел с помощью параллелирования
// 3. Сравнить результаты выполнения алгоритмов по времени

using System.Diagnostics;

void FillArrayRnd(int[] array, int min, int max, int startPos, int endPos)
{
    Random rnd = new();

    for (int i = startPos; i < endPos; i++)
    {
        array[i] = rnd.Next(min, max + 1);
    }
}

void ParallelFillArray(int[] array, int min, int max, int THREADS_NUMBER)
{
    int size = array.Length;
    int eachThreadCalc = size / THREADS_NUMBER;
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        //если последний поток
        if (i == THREADS_NUMBER - 1) endPos = size;
        threadsList.Add(new Thread(() => FillArrayRnd(array, min, max, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
}

int[] array1 = new int[10000000];

Stopwatch sw = new();

sw.Start();
FillArrayRnd(array1, 0, 9, 0, array1.Length);
sw.Stop();

Console.WriteLine($"Serial fill array time = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
ParallelFillArray(array1, 0, 9, 10);
sw.Stop();

Console.WriteLine($"Parallel fill array time = {sw.ElapsedMilliseconds} Milliseconds");
