// Напишите программу, которая 
// 1. Составляет массив из чисел, делимых на число N без остатка, исходного массива
// 2. Составляет массив из чисел, делимых на число N без остатка, исходного массива, с помощью параллелирования
// 3. Сравнить результаты выполнения алгоритмов по времени

using System.Diagnostics;
using static Infrastucture;

const int N = 2;
const int ARRAYS_SIZE = 10000000;
const bool OUTPUT = false;
object lock_object = new object();

// int CountDivByNumberElemsArray(int[] array, int divNumber, int startPos, int endPos)
// {
//     int count = 0;
//     for (int i = startPos; i < endPos; i++)
//         if (array[i] % N == 0)
//             count++;
//     return count;
// }

// int ParallelCountDivByNumberElemsArray(int[] array, int divNumber, int ThreadsNumber)
// {
//     int size = array.Length;
//     int count = 0;
//     int eachThreadCalc = size / ThreadsNumber;
//     var threadsList = new List<Thread>();
//     for (int i = 0; i < ThreadsNumber; i++)
//     {
//         int startPos = i * eachThreadCalc;
//         int endPos = (i + 1) * eachThreadCalc;
//         //если последний поток
//         if (i == ThreadsNumber - 1) endPos = size;
//         // Console.WriteLine($"{i} {startPos} {endPos} {newArray.GetLength(0)}");
//         threadsList.Add(new Thread(() => count += CountDivByNumberElemsArray(array, divNumber, startPos, endPos)));
//         threadsList[i].Start();
//     }
//     for (int i = 0; i < ThreadsNumber; i++)
//     {
//         threadsList[i].Join();
//     }
//     return count;
// }

void DivByNumberElemsArray(List<int> newArray, int[] array, int divNumber, int startPos, int endPos)
{
    lock (lock_object)
    for (int i = startPos; i < endPos; i++)
    {
        if (array[i] % N == 0)
            newArray.Add(array[i]);
    }
}

List<int> ParallelDivByNumberElemsArray(int[] array, int divNumber, int ThreadsNumber)
{
    int size = array.Length;
    List<int> newArray = new List<int>();
    int eachThreadCalc = size / ThreadsNumber;
    var threadsList = new List<Thread>();
    for (int i = 0; i < ThreadsNumber; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        //если последний поток
        if (i == ThreadsNumber - 1) endPos = size;
        // Console.WriteLine($"{i} {startPos} {endPos} {newArray.GetLength(0)}");
        threadsList.Add(new Thread(() => DivByNumberElemsArray(newArray, array, divNumber, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < ThreadsNumber; i++)
    {
        threadsList[i].Join();
    }
    return newArray;
}

int[] arr = new int[ARRAYS_SIZE];
ParallelFillArray(arr, -9, 9, 10);
if (OUTPUT == true)
    PrintArray(arr);

Stopwatch sw = new Stopwatch();

sw.Start();
List<int> divByNumberElemsArray = new List<int>();
DivByNumberElemsArray(divByNumberElemsArray, arr, N, 0, ARRAYS_SIZE);
sw.Stop();
if (OUTPUT == true)
    PrintList(divByNumberElemsArray);
Console.WriteLine($"Time serial finding elements div by {N} without a remainder = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
List<int> parallelDivByNumberElemsArray = ParallelDivByNumberElemsArray(arr, N, ThreadsNumber: 10);
sw.Stop();
if (OUTPUT == true)
    PrintList(parallelDivByNumberElemsArray);
Console.WriteLine($"Time parallel finding elements div by {N} without a remainder = {sw.ElapsedMilliseconds} Milliseconds");

Console.WriteLine(EqualityLists(divByNumberElemsArray, parallelDivByNumberElemsArray) ? "Массивы равны" : "Массивы не равны");
