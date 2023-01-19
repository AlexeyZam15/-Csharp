// Напишите программу, которая 
// 1. Создаёт массив из квадратов рандомных чисел исходного массива
// 2. Создаёт массив из квадратов рандомных чисел исходного массива первого с помощью параллелирования
// 3. Проверяет является ли массив квадратом другого
// 4. Проверяет является ли массив квадратом другого с помощью параллелирования
// 5. Сравнить результаты выполнения алгоритмов по времени

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

void SquareArray(int[] array, int[] array1, int startPos, int endPos)
{
    int size = array.Length;

    for (int i = startPos; i < endPos; i++)
    {
        array1[i] = array[i] * array[i];
    }
}

void ParallelSquareArray(int[] array, int[] array1, int THREADS_NUMBER)
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
        threadsList.Add(new Thread(() => SquareArray(array, array1, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
}

bool CheckSquareArray(int[] array, int[] array1, int startPos, int endPos)
{
    bool res = false;
    int size = array.Length;
    if (size == array1.Length)
    {
        res = true;
        for (int i = startPos; i < endPos; i++)
        {
            res = res && (array1[i] == array[i] * array[i]);
        }
    }
    else res = false;
    return res;
}

bool ParallelCheckSquareArray(int[] array, int[] array1, int THREADS_NUMBER)
{
    bool res = false;
    int size = array.Length;
    int eachThreadCalc = size / THREADS_NUMBER;
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        //если последний поток
        if (i == THREADS_NUMBER - 1) endPos = size;
        threadsList.Add(new Thread(() => res = CheckSquareArray(array, array1, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
    return res;
}

const int ARRAYS_SIZE = 10000000;

int[] arr = new int[ARRAYS_SIZE];
ParallelFillArray(arr, 0, 9, 10);
// Console.WriteLine(string.Join(" ", arr));

int[] arr1 = new int[ARRAYS_SIZE];

Stopwatch sw = new();

sw.Start();
SquareArray(arr, arr1, 0, ARRAYS_SIZE);
sw.Stop();

// Console.WriteLine(string.Join(" ", arr1));
Console.WriteLine($"Serial Square array time = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
ParallelSquareArray(arr, arr1, 10);
sw.Stop();

// Console.WriteLine(string.Join(" ", arr1));
Console.WriteLine($"Parallel Square array time = {sw.ElapsedMilliseconds} Milliseconds");

bool equalityArrays = false;

sw.Reset();
sw.Start();
equalityArrays = CheckSquareArray(arr, arr1, 0, ARRAYS_SIZE);
sw.Stop();

Console.WriteLine(equalityArrays ? "Массив состоит из квадратов элементов другого массива"
                                : "Массив не состоит квадратов элементов другого массива");
Console.WriteLine($"Serial check square array time = {sw.ElapsedMilliseconds} Milliseconds");

sw.Reset();
sw.Start();
equalityArrays = ParallelCheckSquareArray(arr, arr1, 10);
sw.Stop();

Console.WriteLine(equalityArrays ? "Массив состоит из квадратов элементов другого массива"
                                : "Массив не состоит квадратов элементов другого массива");
Console.WriteLine($"Parallel check square array time = {sw.ElapsedMilliseconds} Milliseconds");
