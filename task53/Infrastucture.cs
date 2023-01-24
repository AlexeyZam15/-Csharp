public static class Infrastucture
{
    /// <summary>
    /// Метод заполнения массива случайными числами
    /// </summary>
    /// <param name="array">исходный массив</param>
    /// <param name="min">минимальной число в диапазоне случайных чисел</param>
    /// <param name="max">максимальное число в диапазоне случайных чисел</param>
    /// <param name="startPos">индекс с которого начинается заполнение массива</param>
    /// <param name="endPos">индекс которым заканчинается заполнение массива</param>
    public static void FillArrayRnd(int[] array, int min, int max, int startPos, int endPos)
    {
        Random rnd = new();

        for (int i = startPos; i < endPos; i++)
        {
            array[i] = rnd.Next(min, max + 1);
        }
    }

    public static void FillListRnd(List<int> array, int min, int max, int startPos, int endPos)
    {
        Random rnd = new();

        for (int i = startPos; i < endPos; i++)
        {
            array.Add(rnd.Next(min, max + 1));
        }
    }

    /// <summary>
    /// Метод параллельного заполнения массива случайными числами
    /// </summary>
    /// <param name="array">исходный массив</param>
    /// <param name="min">минимальной число в диапазоне случайных чисел</param>
    /// <param name="max">максимальное число в диапазоне случайных чисел</param>
    /// <param name="THREADS_NUMBER">количество поток</param>
    public static void ParallelFillArray(int[] array, int min, int max, int THREADS_NUMBER)
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

    /// <summary>
    /// Метод проверки равенства двух массивов
    /// </summary>
    /// <param name="array">Первый массив</param>
    /// <param name="array1">Второй массив</param>
    /// <returns></returns>
    public static bool EqualityArrays(int[] array, int[] array1)
    {
        bool res = true;
        int size = array.Length;
        if (size == array1.Length)
            for (int i = 0; i < array.Length; i++)
                res = res && (array[i] == array1[i]);
        else
            res = false;
        return res;
    }

     public static bool EqualityLists(List<int> array, List<int> array1)
    {
        bool res = true;
        int size = array.Count;
        if (size == array1.Count)
            for (int i = 0; i < size; i++)
                res = res && (array[i] == array1[i]);
        else
            res = false;
        return res;
    }

    /// <summary>
    /// Метод печати массива
    /// </summary>
    /// <param name="array">Массив</param>
    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i],3}");
        }
        Console.WriteLine();
    }

    public static void PrintList(List<int> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            Console.Write($"{array[i],3}");
        }
        Console.WriteLine();
    }
}