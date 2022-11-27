// M2.6. Дан массив a. Определить знакопеременную сумму a[1] — a[2] + a[3] — a[4] …
// Условный оператор и операцию возведения в степень не использовать.

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

int[] array = CreateArrayRndInt(6,0,10);
PrintArray(array,"[",@"]
",",");

int AlternatingSum(int[] arr)
{
    int sum = 0;
    int mod = 1;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i]*mod;
        mod *= -1;
        // sum += i % 2 == 0 ? sum : -sum;
    }
    return sum;
}

int alternatingSum = AlternatingSum(array);
Console.WriteLine($"Знакопеременная сумма элементов массива = {alternatingSum}");