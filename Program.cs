using System;

class Program
{
    static void Main()
    {
        Console.Write("Wybierz kierunek konwersji (C -> na Fahrenheity, F -> na Celsjusze): ");
        string wybor = Console.ReadLine().ToUpper();

        Console.Write("Podaj wartość temperatury: ");
        double temp = Convert.ToDouble(Console.ReadLine());

        if (wybor == "C")
        {
            double f = temp * 1.8 + 32;
            Console.WriteLine($"{temp}°C = {f:F2}°F");
        }
        else if (wybor == "F")
        {
            double c = (temp - 32) / 1.8;
            Console.WriteLine($"{temp}°F = {c:F2}°C");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy wybór kierunku konwersji.");
        }
    }
}