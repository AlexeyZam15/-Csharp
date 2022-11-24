// Проверка на ввод только цифр через Console.ReadLine().

string InputOnlyNumbers()
{
    char[] numbers = { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    bool success = false;
    string input = string.Empty;
    while (success != true)
    {
        Console.Write("Введите число: ");
        input = Console.ReadLine();
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (input[i] == numbers[j])
                {
                    success = true;
                    if (input[i] == '-' && i != 0) success = false;
                    break;
                }
                else success = false;
            }
            if (success == false)
            {
                Console.WriteLine("Введены неверные данные");
                break;
            }
        }
    }
    return input;
}

int number = Convert.ToInt32(InputOnlyNumbers());
Console.WriteLine($"Число: {number}");