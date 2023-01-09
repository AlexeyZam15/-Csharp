// Дано натуральное (целое неотрицательное) число а и целое 
// положительное число d. Вычислите частное q и остаток r при делении а 
// на d, не используя операций div и mod.

Random rnd = new Random();
int a = rnd.Next(1, 101);
int d = rnd.Next(1, 11);
int q = 0;
int c = a;
if (c > d)
    while (c >= d)
    {
        c -= d;
        q++;
    }
else
    q = 0;
Console.WriteLine($@"Частное {a} / {d} = {q}
Остаток = {c}");
