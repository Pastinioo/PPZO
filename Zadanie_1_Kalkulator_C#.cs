using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj pierwszą liczbę: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Podaj drugą liczbę: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Wybierz operację (+, -, *, /): ");
        string op = Console.ReadLine();

        if (op == "+")
        {
            Console.WriteLine($"Wynik: {num1 + num2}");
        }
        else if (op == "-")
        {
            Console.WriteLine($"Wynik: {num1 - num2}");
        }
        else if (op == "*")
        {
            Console.WriteLine($"Wynik: {num1 * num2}");
        }
        else if (op == "/")
        {
            if (num2 != 0)
            {
                Console.WriteLine($"Wynik: {num1 / num2}");
            }
            else
            {
                Console.WriteLine("Błąd: Nie można dzielić przez zero!");
            }
        }
        else
        {
            Console.WriteLine("Nieznana operacja.");
        }
    }
}
