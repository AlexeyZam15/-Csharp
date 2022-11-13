// S3.3. Дано вещественное число а. Пользуясь только операцией умножения, получить:
// а) a4 за две операции;
// б) a6  за три операции;
// в) a7 за четыре операции;
// г) a8  за три операции;
// д) a9 за четыре операции;
// е) a10  за четыре операции.
double a = 2;
double a2 = 0;
double a4 = 0;
double a6 = 0;
double a7 = 0;
double a8 = 0;
double a9 = 0;
double a10 = 0;
Console.WriteLine($"Число a = {a}");
a2 = a * a;
a4 = a2 * a2;
a6 = a2 * a2 * a2;
a7 = a2 * a2 * a2 * a;
a8 = a6 * a * a;
a9 = a4 * a2 * a2 * a;
a10 = a6 * a * a * a * a;
Console.WriteLine($"a) Число {a} в 4 степени = {a4}");
Console.WriteLine($"б) Число {a} в 6 степени = {a6}");
Console.WriteLine($"в) Число {a} в 7 степени = {a7}");
Console.WriteLine($"г) Число {a} в 8 степени = {a8}");
Console.WriteLine($"д) Число {a} в 9 степени = {a9}");
Console.WriteLine($"е) Число {a} в 10 степени = {a10}");