// Проверка на ввод только цифр через Console.ReadKey().

bool success = true;
char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
string text = string.Empty;
Console.WriteLine("Нажмите любую кнопку для начала работы программы");
ConsoleKeyInfo input = Console.ReadKey(true);
Console.Write("Введите число и нажмите Enter: ");
while (input.Key != ConsoleKey.Enter)
{
    if (success == false)
    {
        Console.WriteLine();
        Console.WriteLine("Введены неверные данные, повторите ввод");
        text = string.Empty;
        Console.Write("Введите число и нажмите Enter: ");
    }
    input = Console.ReadKey();
    for (int i = 0; i < numbers.Length; i++)
    {
        if (input.KeyChar == numbers[i])
        {
            success = true;
            break;
        }
        else success = false;
    }
    text = text + input.KeyChar;
}
Console.WriteLine();
Console.WriteLine($"Введённое число: {text}");