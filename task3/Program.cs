// S3.4. Дано вещественное число a. Пользуясь только операцией умножения, получить:
// а) a3 и a10 за четыре операции;
// б) a4 и a20 за пять операций;
// в) a5 и a13 за пять операций;
// г) a5 и a19 за пять операций;
// д) a2, a5 и a17 за шесть операций;
// е) a4, a12 и a28 за шесть операций.
double a = 2;

Console.WriteLine($"Число a = {a}");

double a3 = 0;
double a10 = 0;

double a4 = 0;
double a20 = 0;

double a5 = 0;
double a13 = 0;

double a2 = 0;
double a17 = 0;

double a12 = 0;
double a28 = 0;

double MultDegree(int degree, double arg1)
{
    int count = 1;
    double res = arg1;
    while (count < degree)
    {
        res = res * arg1;
        count++;
    }
    return res;
}

a3 = MultDegree(3, a);
a10 = MultDegree(10, a);

a4 = MultDegree(4, a);
a20 = MultDegree(20, a);

a5 = MultDegree(5, a);
a13 = MultDegree(13, a);

a2 = MultDegree(2, a);
a17 = MultDegree(17, a);

a12 = MultDegree(12, a);
a28 = MultDegree(28, a);

Console.WriteLine($"a) Число {a} в 3 степени = {a3}");
Console.WriteLine($"б) Число {a} в 10 степени = {a10}");
Console.WriteLine();
Console.WriteLine($"в) Число {a} в 4 степени = {a4}");
Console.WriteLine($"г) Число {a} в 20 степени = {a20}");
Console.WriteLine();
Console.WriteLine($"д) Число {a} в 5 степени = {a5}");
Console.WriteLine($"е) Число {a} в 13 степени = {a13}");
Console.WriteLine();
Console.WriteLine($"е) Число {a} в 12степени = {a12}");
Console.WriteLine($"е) Число {a} в 17 степени = {a17}");
Console.WriteLine();
Console.WriteLine($"е) Число {a} в 12 степени = {a12}");
Console.WriteLine($"е) Число {a} в 28 степени = {a28}");