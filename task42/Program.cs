// Дано  натуральное  n,  вычислите 1/0! + 1/1!+ ... + 1/n!

int n = 0;
while (n <= 0)
{
    Console.WriteLine("Введите натуральное число n:");
    n = Convert.ToInt32(Console.ReadLine());
    if (n <= 0)
        Console.WriteLine("Введены неверные данные");
}

double sum = 1;
double factorial = 1;
for (double i = 1; i <= n; i++)
{
    factorial *= i;
    sum += 1 / factorial;
}

Console.WriteLine($"1/0! + 1/1!+ ... + 1/{n}! = {sum}");
