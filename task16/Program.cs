//а) Создать и вывести массив с таблицей умножения числа N до размера M, начиная с числа I;
//б) Создать и вывести массив степеней числа N до размера M, начиная со степени I. Не использовать встроенные методы;

void PrintArray(int[] arr, string beginStr, string separatorElems, string endstr)
{
    Console.Write(beginStr);
    for (int i = 0; i < arr.Length; i++)
    {
        if (i < arr.Length - 1)
            Console.Write($"{arr[i]}{separatorElems}");
        else Console.Write($"{arr[i]}");
    }
    Console.Write(endstr);
}

int[] MultArray(int number1, int size1, int startNumber1)
{
    int[] array1 = new int[size1];
    for (int i = 0; i < size1; i++)
    {
        array1[i] = number1 * (startNumber1++);
    }
    return array1;
}

int DegreeNumber(int number1, int degree1)
{
    int mult1 = number1;
    for (int i = 1; i < degree1; i++)
        mult1 *= number1;
    return mult1;
}

int[] DegreeArray(int number1, int size1, int startDegree1)
{
    int[] array1 = new int[size1];
    int mult1 = DegreeNumber(number1, startDegree1);
    for (int i = 0; i < size1; i++)
    {
        array1[i] = mult1;
        mult1 *= number1;
    }
    return array1;
}

Console.Write("Введите число для вычислений N: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите размер вычислений M: ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число, с которого будут начинаться вычисления, I: ");
int i = Convert.ToInt32(Console.ReadLine());

int[] multArray = MultArray(n, m, i);
PrintArray(multArray, @$"Таблица умножения числа {n} размером {m} начиная с {n}*{i}
", " ", "");

int[] degreeArray = DegreeArray(n, m, i);
Console.WriteLine();
PrintArray(degreeArray, @$"Таблица степеней числа {n} размером {m} начиная с {n}^{i}
", " ", "");
