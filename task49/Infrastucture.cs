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

}