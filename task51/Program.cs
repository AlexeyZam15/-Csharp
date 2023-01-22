// Напишите программу, которая 
// 1. Составляет массив из наибольших чисел среди N количества элементов исходного массива
// 2. Составляет массив из наибольших чисел среди N количества элементов исходного массива, с помощью параллелирования
// 3. Сравнить результаты выполнения алгоритмов по времени

using System.Diagnostics;
using static Infrastucture;

const int N = 4;
const int ARRAYS_SIZE = 10000000;
const bool OUTPUT = false;

void LargestOfAmountElemsArray(int[] array1, int[] array, int amount, int startPos, int endPos)
{
    // 0 1 2 3 4 5 6 7  8  9  10 11 12 13 14 15 16 17 18 19
    // 3 4 5 6 7 8 9|10 11 12 13 14 15 16 17 18 19
    int index = 0;
    if (startPos != 0)
    {
        startPos = startPos - amount + 1;
        index = startPos;
    }
    int size = endPos - startPos - amount + 1;
    for (int i = startPos; i < endPos - amount + 1; i++)
    {
        int max = array[i];
        for (int j = 1; j < amount; j++)
        {
            if (array[i + j] > max) max = array[i + j];
        }
        array1[index++] = max;
    }
}

int[] ParallelLargestOfAmountElemsArray(int[] array, int amount, int ThreadsNumber)
{
    int size = array.Length;
    int[] array1 = new int[size - amount + 1];
    int index = 0;
    int eachThreadCalc = size / ThreadsNumber;
    var threadsList = new List<Thread>();
    for (int i = 0; i < ThreadsNumber; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        startPos = i * eachThreadCalc;
        //если последний поток
        if (i == ThreadsNumber - 1) endPos = size;
        // Console.WriteLine($"{i} {startPos} {endPos} {array1.GetLength(0)}");
        threadsList.Add(new Thread(() => LargestOfAmountElemsArray(array1, array, amount, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < ThreadsNumber; i++)
    {
        threadsList[i].Join();
    }
    return array1;
}

int[] arr = new int[ARRAYS_SIZE];
ParallelFillArray(arr, -9, 9, 10);
if (OUTPUT == true)
    PrintArray(arr);

Stopwatch sw = new Stopwatch();

sw.Start();
int[] largestOfAmountElemsArray = new int[ARRAYS_SIZE - N + 1];
LargestOfAmountElemsArray(largestOfAmountElemsArray, arr, N, 0, ARRAYS_SIZE);
sw.Stop();
if (OUTPUT == true)
    PrintArray(largestOfAmountElemsArray);
Console.WriteLine($"Time serial finding largest of {N} elements = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
int[] largestOfAmountElemsArray1 = ParallelLargestOfAmountElemsArray(arr, N, ThreadsNumber: 10);
sw.Stop();
Console.WriteLine($"Time parallel finding largest of {N} elements = {sw.ElapsedMilliseconds} Milliseconds");
if (OUTPUT == true)
    PrintArray(largestOfAmountElemsArray1);

Console.WriteLine(EqualityArrays(largestOfAmountElemsArray, largestOfAmountElemsArray1) ? "Массивы равны" : "Массивы не равны");
