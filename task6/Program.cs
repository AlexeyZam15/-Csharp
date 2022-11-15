// M2.1. Дан массив. Составить программу:
// а) расчета квадратного корня из любого элемента массива;
// б) расчета среднего арифметического двух любых элементов массива.
double[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
string str = string.Join(" ", array);
Console.WriteLine($"Эллементы массива: {str}");

char choice = Convert.ToChar("0");
int number_choice = 0;

while (number_choice == 0)
{
    Console.WriteLine("Выберите схему: ");
    Console.WriteLine("a) расчет квадратного корня из любого элемента массива;");
    Console.WriteLine("b) расчет среднего арифметического двух любых элементов массива;");
    Console.WriteLine("q) выход.");
    choice = Console.ReadKey(true).KeyChar;
    if (choice == Convert.ToChar("a")) number_choice = 1;
    else if (choice == Convert.ToChar("b")) number_choice = 2;
    else if (choice == Convert.ToChar("q")) break;
    else Console.WriteLine("Неправильный ввод");
}

void SqrRoot()
{
    Console.Write("Укажите индекс нужного элемента массива: ");
    int index = Convert.ToInt32(Console.ReadLine());
    double root = Math.Sqrt(array[index]);
    Console.Write($"Квадратный корень элемента массива {array[index]} = {root}");
}

if (number_choice == 1) SqrRoot();

void Average()
{
    Console.Write("Укажите индекс первого нужного элемента массива: ");
    int index1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Укажите индекс второго нужного элемента массива: ");
    int index2 = Convert.ToInt32(Console.ReadLine());
    double average = (array[index1] + array[index2])/2;
    Console.Write($"Среднее арифметическое элементов массива {array[index1]} и {array[index2]} = {average}");
}

if (number_choice == 2) Average();
