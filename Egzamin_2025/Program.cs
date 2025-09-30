using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace Egzamin_2025
{
    public class Program
    {
        public static string[,] jednostki = new string[,]
           {
                {"km","Długość" },
                {"m","Długość" },
                {"mi","Długość" },
                {"mg","Masa" },
                {"kg","Masa" },
                {"lb", "Masa"},
                {"C", "Temperatura" },
                {"F", "Temperatura" },
                {"K", "Temperatura" }
           };
        public static void Main(string[] args)
        {

            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("Wybierz typ konwersji:\n1. Długość\n2. Masa\n3. Temperatura\n");
                string type = Console.ReadLine();

                if (int.TryParse(type, out int typeC))
                {
                    if (typeC == 0) break;

                    Console.WriteLine("Podaj wartość:");
                    string wartosc = Console.ReadLine();

                    if (double.TryParse(wartosc, out double wartoscI))
                    {
                        Console.WriteLine("Dostępne jednostki:");

                        for (int i = 0; i < jednostki.GetLength(0); i++)
                        {
                            if ((typeC == 1 && jednostki[i, 1] == "Długość") ||
                                (typeC == 2 && jednostki[i, 1] == "Masa") ||
                                (typeC == 3 && jednostki[i, 1] == "Temperatura"))
                            {
                                Console.Write($"{jednostki[i, 0]}, ");
                            }
                        }
                        Console.WriteLine();
                        
                        Console.WriteLine("Podaj jednostkę źródłową:");
                        string jednostka_from = Console.ReadLine();

                        Console.WriteLine("Podaj jednostkę docelową:");
                        string jednostka_to = Console.ReadLine();

                        double wartoscD =0;
                        switch (typeC)
                        {
                            case 1:
                                wartoscD=CalculateLength(wartoscI, jednostka_from, jednostka_to);
                                break;
                            case 2:
                                wartoscD = CalculateWeight(wartoscI, jednostka_from, jednostka_to);
                                break;
                            case 3:
                                wartoscD = CalculateTemp(wartoscI, jednostka_from, jednostka_to);
                                break;
                        }
                        Console.WriteLine($"Konwersja z {jednostka_from} na {jednostka_to}");
                        Console.WriteLine($"Wynik: {wartoscD}{jednostka_to}\n");
                    }
                }
            }
        }
        public static double CalculateLength(double wartosc, string jednostka_from, string jednostka_to)
        {
            double metry = jednostka_from switch
            {
                "m" => wartosc,
                "km" => wartosc * 1000,
                "mi" => wartosc * 1609.34,
                _ => -1.0
            };

            if (metry < 0) return -1.0;

            return jednostka_to switch
            {
                "m" => metry,
                "km" => metry / 1000,
                "mi" => metry / 1609.34,
                _ => -1.0
            };
        }
        public static double CalculateWeight(double wartosc, string jednostka_from, string jednostka_to)
        {
            double mg = jednostka_from switch
            {
                "mg" => wartosc,
                "kg" => wartosc * 1000000,
                "g" => wartosc * 1000,
                "lb" => wartosc * 453592,
                _ => -1.0
            };

            if (mg < 0) return -1.0;

            return jednostka_to switch
            {
                "mg" => mg,
                "g" => mg / 1000,
                "kg" => mg / 1_000_000,
                "lb" => mg / 453592,
                _ => -1.0
            };
        }
        public static double CalculateTemp(double wartosc, string jednostka_from, string jednostka_to)
        {
            return (jednostka_from.ToLower(), jednostka_to.ToLower()) switch
            {
                ("c", "f") => wartosc * 9 / 5 + 32,
                ("f", "c") => (wartosc - 32) * 5 / 9,
                ("c", "k") => wartosc + 273.15,
                ("k", "c") => wartosc - 273.15,
                ("f", "k") => (wartosc - 32) * 5 / 9 + 273.15,
                ("k", "f") => (wartosc - 273.15) * 9 / 5 + 32,
                ("c", "c") => wartosc,
                ("f", "f") => wartosc,
                ("k", "k") => wartosc,
                _ => -1.0
            };
        }
      


    }
}