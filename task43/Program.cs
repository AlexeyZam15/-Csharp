// Даны два натуральных числа a и b.  
// Вычислите НОД(a,b) - наибольший общий делитель а и b.

using System.Diagnostics;

int a = 0;
while (a <= 0)
{
    Console.WriteLine("Введите натуральное число a:");
    a = Convert.ToInt32(Console.ReadLine());
    if (a <= 0)
        Console.WriteLine("Введены неверные данные");
}

int b = 0;
while (b <= 0)
{
    Console.WriteLine("Введите натуральное число b:");
    b = Convert.ToInt32(Console.ReadLine());
    if (b <= 0)
        Console.WriteLine("Введены неверные данные");
}

Stopwatch sw = new();
sw.Start();

int nod = 1;
int max = a;
if (b > max) max = b;
for (int i = max; i > 1; i--)
{
    if (a % i == 0 & b % i == 0)
    {
        nod = i;
        break;
    }
}

sw.Stop();
Console.WriteLine($"Время выполнения программы = {sw.ElapsedMilliseconds} миллисекунд");
Console.WriteLine($"НОД({a},{b}) = {nod}");
