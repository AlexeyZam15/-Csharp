// M2.2. Дан массив целых чисел. Выяснить:
// а) является ли s-й элемент массива положительным числом;
// б) является ли k-й элемент массива четным числом;
// в) какой элемент массива больше: k-й или s-й.

int[] array = {1,2,-3,4,-5,6,7,8,-9,-10};
Console.WriteLine($"Элементы массива: {string.Join(" ", array)}");

Console.Write("Укажите индекс нужного элемента массива: ");
int s = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(array[s] > 0 ? $"Элемент массива {array[s]} - положительное число" : $"Элемент массива {array[s]} - отрицательное число");

Console.Write("Укажите индекс нужного элемента массива: ");
int k = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(array[k] % 2 == 0 ? $"Элемент массива {array[k]} является чётным числом" : $"Элемент массива {array[k]} не является чётным числом");

if (array[s] != array[k]) 
Console.WriteLine(array[s] > array[k] ? $"Элемент массива {array[s]} больше элемента массива {array[k]}" : $"Элемент массива {array[k]} больше элемента массива {array[s]}");
else Console.WriteLine($"Элементы массива {array[s]} и {array[k]} равны");