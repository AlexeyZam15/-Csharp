// Найти индекс числа в отсортированном массиве с помощью бинарного поиска.

int[] CreateArrayRndInt(int size, int min, int max)
{
    int[] array = new int[size];
    Random rnd = new Random();
    for (int i = 0; i < size; i++)
    {
        array[i] = rnd.Next(min, max + 1);
    }
    return array;
}

int[] SortQuick(int[] collection, int left, int right, bool log = false)
{
    int i = left;
    int j = right;

    int pivot = collection[(left + right) / 2];

    if (log == true)
    {
        Console.WriteLine($"i = {i}, j = {j}");
        Console.WriteLine($"Опорный элемент = {pivot}");
    }

    while (i <= j)
    {
        while (collection[i] < pivot)
        {
            if (log == true)
                Console.WriteLine($"[{string.Join(", ", collection)}] | {collection[i]}<{pivot}  | i++ | i = {i + 1}");
            i++;
        }
        while (collection[j] > pivot)
        {
            if (log == true)
                Console.WriteLine($"[{string.Join(", ", collection)}] | {collection[j]}>{pivot}  | j-- | j = {j - 1}");
            j--;
        }

        if (i <= j)
        {
            if (log == true)
            {
                Console.WriteLine($"[{string.Join(", ", collection)}] | i<=j | {collection[i]}<->{collection[j]}");
                Console.WriteLine($"i++ | j++ | i = {i + 1} | j = {j - 1}");
            }
            int t = collection[i];
            collection[i] = collection[j];
            collection[j] = t;
            i++;
            j--;
        }
        else if (log == true)
            Console.WriteLine($"[{string.Join(", ", collection)}] | i>j  | {collection[i]} X {collection[j]}");
    }
    if (i < right)
    {
        if (log == true)
            Console.WriteLine($"i<right  | повторяем алгоритм");
        SortQuick(collection, i, right);
    }
    else if (log == true) Console.WriteLine($"i>=right | завершение работы алгоритма");
    if (j > left)
    {
        if (log == true)
            Console.WriteLine($"j>left | повторяем алгоритм");
        SortQuick(collection, left, j);
    }
    return collection;
}

// int IntBinarySearchInArray(int[] array, int number, bool log = false)
// {
//     int size = array.Length;
//     int max = size - 1;
//     int min = 0;
//     int middle = max;
//     while (middle - 1 != min && middle + 1 != max)
//     {
//         if (log == true)
//             Console.Write($"{min,4} {middle,4} {max,4}");
//         if (array[min] == number)
//         {
//             if (log == true)
//                 Console.WriteLine($"{"=",3}");
//             return min;
//         }
//         if (number == array[middle])
//         {
//             if (log == true)
//                 Console.WriteLine($"{"=",3}");
//             return middle;
//         }
//         if (number < array[middle])
//         {
//             if (log == true)
//                 Console.WriteLine($"{"<",3}");
//             max = middle + 1;
//             middle -= (middle - min) / 2;
//         }
//         else
//         {
//             if (log == true)
//                 Console.WriteLine($"{">",3}");
//             min = middle - 1;
//             middle += (max - min) / 2;
//         }
//     }
//     return -1;
// }

static int BinarySearch(int[] array, int searchedValue, bool log = false)
{
    int left = 0;
    int right = array.Length - 1;
    while (left <= right)
    {
        var middle = (left + right) / 2;
        if (log == true)
            Console.Write($"{left} {middle} {right}");
        if (searchedValue == array[middle])
        {
            if (log == true)
                Console.WriteLine(" =");
            return middle;
        }
        else if (searchedValue < array[middle])
        {
            if (log == true)
                Console.WriteLine(" <");
            right = middle - 1;
        }
        else
        {
            if (log == true)
                Console.WriteLine(" >");
            left = middle + 1;
        }
    }
    return -1;
}

int[] arr = CreateArrayRndInt(10, 1, 15);

arr = SortQuick(arr, 0, arr.Length - 1);

Console.WriteLine(string.Join(" ", arr));

Console.Write($"Введите число, которое хотите найти: ");
int searchNumber = Convert.ToInt32(Console.ReadLine());

// int numberIndex = IntBinarySearchInArray(arr, searchNumber, false);

int numberIndex = BinarySearch(arr, searchNumber, true);

Console.WriteLine(numberIndex != -1 ? $"Индекс числа {searchNumber} в массиве = {numberIndex}"
                                    : $"Число {searchNumber} не найдено в массиве");
