//a) M2.7. В массиве хранятся сведения о количестве осадков, выпавших за каждый день января. 
// Определить общее количество осадков за январь.
//б) M2.8. В массиве хранятся сведения о стоимости 12 различных предметов. 
// Определить общую стоимость всех предметов.
//в) M2.9. В массиве хранится информация о сопротивлении каждого из 20 элементов электрической цепи. 
// Все элементы соединены последовательно. Определить общее сопротивление цепи.
//г) M2.10. В массиве хранится информация о сопротивлении каждого из 20 элементов электрической цепи. 
// Все элементы соединены параллельно. Определить общее сопротивление цепи.

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

void PrintArray(int[] arr, string beginStr, string separatorElems, string endStr)
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

int[] array = CreateArrayRndInt(31, 0, 8);
PrintArray(array, "a) [", ",", @"]
");

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
Console.WriteLine($"Общее количество осадков за январь = {sumArray} мм");

//б) M2.8. В массиве хранятся сведения о стоимости 12 различных предметов. 
// Определить общую стоимость всех предметов.

int[] array2 = CreateArrayRndInt(12, 30, 200);
PrintArray(array2, @"
б) [", ",", @"]
");

int sumArray2 = SumArray(array2);
Console.WriteLine($"Общая стоимость всех предметов = {sumArray2} р.");

//в) M2.9. В массиве хранится информация о сопротивлении каждого из 20 элементов электрической цепи. 
// Все элементы соединены последовательно. Определить общее сопротивление цепи.

int[] array3 = CreateArrayRndInt(20, 1, 10);
PrintArray(array3, @"
в) [", ",", @"]
");

int sumArray3 = SumArray(array3);
Console.WriteLine($"Общее сопротивление цепи = {sumArray3} Ом");

//г) M2.10. В массиве хранится информация о сопротивлении каждого из 20 элементов электрической цепи. 
// Все элементы соединены параллельно. Определить общее сопротивление цепи.

int[] array4 = CreateArrayRndInt(20, 1, 5);
PrintArray(array4, @"
г) [", ",", @"]
");

long MultArray(int[] arr)
{
    long mult = 1;
    for (int i = 0; i < arr.Length; i++)
    {
        mult *= arr[i];
    }
    return mult;
}
long multArray4 = MultArray(array4);
int sumArray4 = SumArray(array);
long resistance4 = multArray4/sumArray4;
Console.WriteLine($"Общее сопротивление цепи = {resistance4} Ом");