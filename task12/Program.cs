// M2.5. Определить:
// а) сумму всех элементов массива;
// б) произведение всех элементов массива;
// в) сумму квадратов всех элементов массива;
// г) сумму шести первых элементов массива;
// д) сумму элементов массива с k1-го по k2-й (значения k1 и k2 вводятся с клавиатуры; k2 > k1);
// е) среднее арифметическое всех элементов массива;
// ж) среднее арифметическое элементов массива с s1-го по s2-й (значения s1 и s2 вводятся с клавиатуры; s2 > s1).

int[] CreateArrayRndInt(int size, int min, int max)
{
    int[] arr = new int[size];
    Random rnd = new Random();

    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rnd.Next(min, max + 1);
    }
    return arr;
}

void PrintArray(int[] arr, string beginStr, string endStr, string separatorElems)
{
    Console.Write(beginStr);
    for (int i = 0; i < arr.Length; i++)
    {
        if (i < arr.Length - 1)
            Console.Write($"{arr[i]}{separatorElems} ");
        else Console.Write($"{arr[i]}");
    }
    Console.Write(endStr);
}

int[] array = CreateArrayRndInt(10, 0, 10);
PrintArray(array, "", @"
", " |");

// а) сумма всех элементов массива;

int SumArray(int[] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    return sum;
}

int sumArray = SumArray(array);
Console.WriteLine($"а) сумма всех элементов массива = {sumArray}");

// б) произведение всех элементов массива;

int MultArray(int[] arr)
{
    int mult = 1;
    for (int i = 0; i < arr.Length; i++)
    {
        mult *= arr[i];
    }
    return mult;
}

int multArray = MultArray(array);
Console.WriteLine($"б) произведение всех элементов массива = {multArray}");

// в) сумма квадратов всех элементов массива;

int SumSqrtArray(int[] arr)
{
    int sumSqrt = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sumSqrt += arr[i] * arr[i];
    }
    return sumSqrt;
}

int sumSqrtArray = SumSqrtArray(array);
Console.WriteLine($"в) сумма квадратов всех элементов массива = {sumSqrtArray}");

// г) сумма шести первых элементов массива;

int SumFirstSixArray(int[] arr)
{
    int sum = 0;
    for (int i = 0; i < 6; i++)
    {
        sum += arr[i];
    }
    return sum;
}

int sumFirstSixArray = SumFirstSixArray(array);
Console.WriteLine($"г) сумма шести первых элементов массива = {sumFirstSixArray}");

// д) сумму элементов массива с k1-го по k2-й (значения k1 и k2 вводятся с клавиатуры; k2 > k1);

int k1 = -1;
int k2 = -2;
while (k2 < k1)
{
    Console.Write("Введите значение k1: ");
    k1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите значение k2: ");
    k2 = Convert.ToInt32(Console.ReadLine());

    if (k2 < k1) Console.WriteLine("k2 должно быть больше k1");
}

int SumK1K2Array(int[] arr, int k11, int k22)
{
    int sum = 0;
    for (int i = k11; i <= k22; i++)
    {
        sum += arr[i];
    }
    return sum;
}

int sumK1K2Array = SumK1K2Array(array, k1, k2);
System.Console.WriteLine($"д) сумма элементов массива с {k1}-го по {k2}-й = {sumK1K2Array}");

// е) среднее арифметическое всех элементов массива;

double AverageArray(int[] arr)
{
    double sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
    }
    double average = sum / arr.Length;
    return average;
}

double averageArray = AverageArray(array);
Console.WriteLine($"е) среднее арифметическое всех элементов массива = {averageArray}");

// ж) среднее арифметическое элементов массива с s1-го по s2-й (значения s1 и s2 вводятся с клавиатуры; s2 > s1).

int s1 = -1;
int s2 = -2;
while (s2 < s1)
{
    Console.Write("Введите значение s1: ");
    s1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите значение s2: ");
    s2 = Convert.ToInt32(Console.ReadLine());

    if (s2 < s1) Console.WriteLine("s2 должно быть больше s1");
}

double AverageS1S2Array(int[] arr, int s11, int s22)
{
    double sum = 0;
    for (int i = s11; i <= s22; i++)
    {
        sum += arr[i];
    }
    double average = sum / (s22+1);
    return average;
}

double averageS1S2Array = AverageS1S2Array(array, s1, s2);
Console.WriteLine($"ж) среднее арифметическое элементов массива с {s1}-го по {s2}-й = {averageS1S2Array}");