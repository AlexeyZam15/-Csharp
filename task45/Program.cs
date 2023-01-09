// Даны натуральные a и b, не равные 0 одновременно. Найдите 
// d = НОД(a,b) и такие целые x и y, что d = a · x + b · y.

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

bool checkIntegerSolution(int a, int b, int c)
{
    int nod = AlgorithmEucley(a, b);
    return c % nod == 0;
}

void LinearEquationSolution(int a, int b, int c, out int x, out int y)
{
    int nod = AlgorithmEucley(a, b);
    if (a % nod == 0 && b % nod == 0 && c % nod == 0)
    {
        a /= nod;
        b /= nod;
        c /= nod;
    }
    x = 0;
    for (y = 1; y < 5; y++)
    {
        if ((-b * y + c) % a == 0)
        {
            x = (-b * y + c) / a;
            Console.WriteLine($"x = {x}, y = {y}");
        }
    }
    for (x = 1; x < 5; x++)
    {
        if ((-a * x + c) % b == 0)
        {
            y = (-a * x + c) / b;
            Console.WriteLine($"x = {x}, y = {y}");
        }
    }
}

Stopwatch sw = new();
sw.Start();

int nod = AlgorithmEucley(a, b);
sw.Stop();
Console.WriteLine($"Время выполнения программы = {sw.ElapsedMilliseconds} миллисекунд");
Console.WriteLine($"d = {nod}");
Console.WriteLine(checkIntegerSolution(a, b, nod) ? "Есть решение в целых числах" : "Нет решения в целых числах");
int x, y;
LinearEquationSolution(a, b, nod, out x, out y);
