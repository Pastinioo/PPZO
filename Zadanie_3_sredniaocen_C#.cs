using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj liczbę ocen: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double sumaOcen = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Podaj ocenę nr {i + 1}: ");
            double ocena = Convert.ToDouble(Console.ReadLine());
            sumaOcen += ocena;
        }

        if (n > 0)
        {
            double srednia = sumaOcen / n;
            Console.WriteLine($"\nŚrednia: {srednia:F2}");

            if (srednia >= 3.0)
            {
                Console.WriteLine("Uczeń zdał.");
            }
            else
            {
                Console.WriteLine("Uczeń nie zdał.");
            }
        }
        else
        {
            Console.WriteLine("Brak wprowadzonych ocen.");
        }
    }
}
