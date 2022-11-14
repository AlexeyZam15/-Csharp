// A1.1. Дано расстояние в сантиметрах. Найти число полных метров в нем.
// A1.2. Дана масса в килограммах. Найти число полных центнеров в ней.
// A1.3. Дана масса в килограммах. Найти число полных тонн в ней.
// A1.4. Дано расстояние в метрах. Найти число полных километров в нем.
// A1.5. С некоторого момента прошло 234 дня. Сколько полных недель прошло за этот период?

double centimeter = 850;
double meter = centimeter / 100;
Console.WriteLine($"В {centimeter} сантиметрах {meter} метров");

double kilograms = 450;
double centner = kilograms / 100;
Console.WriteLine($"В {kilograms} килограмм {centner} центнеров");

double kilograms2 = 5449;
double tons = kilograms2 / 1000;
Console.WriteLine($"В {kilograms2} килограмм {tons} тонн");

double meter2 = 1200;
double kilometer = meter2 / 1000;
Console.WriteLine($"В {meter2} метрах {kilometer} километров");

int days = 234;
int weeks = days / 7;
Console.WriteLine($"За {days} дней прошло {weeks} полных недель");