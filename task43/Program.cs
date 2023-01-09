// Даны два натуральных числа a и b.  
// Вычислите НОД(a,b) - наибольший общий делитель а и b.

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

Console.WriteLine($"НОД({a},{b}) = {nod}");
