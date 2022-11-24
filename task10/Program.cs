// Даны целочисленные массивы X и Y с разным количеством элементов.   
// Найти минимальный элемент массивов среди элементов, имеющих четный индекс.

int[] x = { 1, -2, -3, 4, 5, 6 };
int[] y = { 7, 8, 9, 10, 0 };

Console.WriteLine($"Массив X: {string.Join(" ", x)}");
Console.WriteLine($"Массив Y: {string.Join(" ", y)}");

int MinEven(int[] array1, int[] array2)
{
    int min = array1[0];
    for (int i = 1; i < array1.Length; i++)
    {
        if (i % 2 == 0)
            if (array1[i] < min) min = array1[i];
    }
    for (int i = 0; i < array2.Length; i++)
    {
        if (i % 2 == 0)
            if (array2[i] < min) min = array2[i];
    }
    return min;
}

int minEven = MinEven(x,y);

System.Console.WriteLine($"Минимальный элемент среди элементов, имеющих четный индекс = {minEven}");