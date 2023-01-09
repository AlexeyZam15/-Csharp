// Даны два натуральных числа a и b.  
// Вычислите НОД(a,b) - наибольший общий делитель а и b, алгоритмом Евклида.

using System.Diagnostics;

int a = 0;
while (a <= 0)
{
    Console.Write("Введите натуральное число a: ");
    a = Convert.ToInt32(Console.ReadLine());
    if (a <= 0)
        Console.WriteLine("Введены неверные данные");
}

int b = 0;
while (b <= 0)
{
    Console.Write("Введите натуральное число b: ");
    b = Convert.ToInt32(Console.ReadLine());
    if (b <= 0)
        Console.WriteLine("Введены неверные данные");
}

int AlgorithmEucley(int number1, int number2)
{
    if (number1 > number2)
    {
        while (number1 > number2)
            number1 -= number2;
        if (number1 > 0)
            AlgorithmEucley(number2, number1);
    }
    if (number2 > number1)
    {
        while (number2 > number1)
            number2 -= number1;
        if (number2 > 0)
            AlgorithmEucley(number1, number2);
    }
    return number1 > number2 ? number2 : number1;
}

Stopwatch sw = new();
sw.Start();

int nod = AlgorithmEucley(a, b);
sw.Stop();
Console.WriteLine($"Время выполнения программы = {sw.ElapsedMilliseconds} миллисекунд");
Console.WriteLine($"НОД({a},{b}) = {nod}");
