// M2.3. Дан массив. Все его элементы:
// а) увеличить в 2 раза;
// б) уменьшить на число А;
// в) разделить на первый элемент.

double[] array = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine($"Элементы массива: {string.Join(" ", array)}");

char choice = Convert.ToChar("0");
int number_choice = 0;

while (number_choice == 0)
{
    Console.WriteLine("Выберите схему: ");
    Console.WriteLine("a) увеличить элементы массива в 2 раза;");
    Console.WriteLine("b) уменьшить элементы массива на число А;");
    Console.WriteLine("с) разделить элементы массива на первый элемент;");
    Console.WriteLine("q) выход.");
    choice = Console.ReadKey(true).KeyChar;
    if (choice == Convert.ToChar("a")) number_choice = 1;
    else if (choice == Convert.ToChar("b")) number_choice = 2;
    else if (choice == Convert.ToChar("c")) number_choice = 3;
    else if (choice == Convert.ToChar("q")) break;
    else Console.WriteLine("Неправильный ввод");
}

if (number_choice == 1)
{
    for (int index = 0; index < array.Length; index++)
    {
        array[index] = array[index] * 2;
    }
    Console.WriteLine($"Элементы массива: {string.Join(" ", array)}");
}

if (number_choice == 2)
{
    Console.Write("Введите число, на которое хотите уменьшить элементы массива: ");
    int A = Convert.ToInt32(Console.ReadLine());
    for (int index = 0; index < array.Length; index++)
    {
        array[index] = array[index] - A;
    }
    Console.WriteLine($"Элементы массива: {string.Join(" ", array)}");
}

if (number_choice == 3)
{
    double firstElement = array[0];
    for (int index = 0; index < array.Length; index++)
    {
        array[index] = array[index] / firstElement;
    }
    Console.WriteLine($"Элементы массива: {string.Join(" ", array)}");
}


