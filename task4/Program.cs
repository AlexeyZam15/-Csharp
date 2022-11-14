// A1.1. Дано расстояние в сантиметрах. Найти число полных метров в нем.
// A1.2. Дана масса в килограммах. Найти число полных центнеров в ней.
// A1.3. Дана масса в килограммах. Найти число полных тонн в ней.
// A1.4. Дано расстояние в метрах. Найти число полных километров в нем.
// A1.5. С некоторого момента прошло 234 дня. Сколько полных недель прошло за этот период?

double Weight(double var, string arg1, string arg2)
{
    double res = var;
    if (arg1 == "kilograms" & arg2 == "tons")
    {
        res = var / 1000;
    }
    if (arg1 == "tons" & arg2 == "kilograms")
    {
        res = var * 1000;
    }
    if (arg1 == "kilograms" & arg2 == "centner")
    {
        res = var / 100;
    }
    if (arg1 == "centner" & arg2 == "kilograms")
    {
        res = var * 100;
    }
    return res;
}

double Distance(double var1, string arg11, string arg22)
{
    double res1 = var1;
    if (arg11 == "centimeters" & arg22 == "meters")
    {
        res1 = var1 / 100;
    }
    if (arg11 == "meters" & arg22 == "centimeters")
    {
        res1 = var1 * 100;
    }
    if (arg11 == "meters" & arg22 == "kilometers")
    {
        res1 = var1 / 1000;
    }
    if (arg11 == "kilometers" & arg22 == "meters")
    {
        res1 = var1 * 1000;
    }
    return res1;
}

// double centimeter = 850;
// double meter = centimeter / 100;
// Console.WriteLine($"В {centimeter} сантиметрах {meter} метров");

double centimeter = 850;
double meter = Distance(centimeter, "centimeters", "meters");
Console.WriteLine($"В {centimeter} сантиметрах {meter} метров");


// double kilograms = 450;
// double centner = kilograms / 100;
// Console.WriteLine($"В {kilograms} килограмм {centner} центнеров");

double kilograms = 450;
double centner = Weight(kilograms, "kilograms", "centner");
Console.WriteLine($"В {kilograms} килограмм {centner} центнеров");

// double kilograms2 = 5449;
// double tons = kilograms2 / 1000;
// Console.WriteLine($"В {kilograms2} килограмм {tons} тонн");

double kilograms2 = 5449;
double tons = Weight(kilograms2, "kilograms", "tons");
Console.WriteLine($"В {kilograms2} килограмм {tons} тонн");

// double meter2 = 1200;
// double kilometer = meter2 / 1000;
// Console.WriteLine($"В {meter2} метрах {kilometer} километров");

double meter2 = 1200;
double kilometer = Distance(meter2, "meters", "kilometers");
Console.WriteLine($"В {meter2} метрах {kilometer} километров");

int days = 234;
int weeks = days / 7;
Console.WriteLine($"За {days} дней прошло {weeks} полных недель");