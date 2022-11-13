//S3.2. Cоставить программу обмена значениями трех переменных величин а, b, c 
// по следующим двум схемам: 
// a) b присвоить значение c, а присвоить значение b, с присвоить значение а;
// b) b присвоить значение а, с присвоить значение b, а присвоить значение с.
int a = new Random().Next(1, 100);
int b = new Random().Next(1, 100);
int c = new Random().Next(1, 100);
Console.WriteLine($"a = {a}, b = {b}, c = {c}");
char choice = Convert.ToChar("0");
int number_choice = 0;
while (number_choice == 0)
{
    Console.WriteLine("Выберите схему: a или b");
    choice = Console.ReadKey(true).KeyChar;
    if (choice == Convert.ToChar("a")) number_choice = 1;
    else if (choice == Convert.ToChar("b")) number_choice = 2;
    else Console.WriteLine("Неправильный ввод");
}
int temporary = 0;
if (number_choice == 1)
{
    temporary = b;
    b = c;
    c = a;
    a = temporary;
}
else if (number_choice == 2)
{
    temporary = b;
    b = a;
    a = c;
    c = temporary;
}
Console.WriteLine($"a = {a}, b = {b}, c = {c}");