using Egzamin_2025;
namespace TestyKonwersji
{
    public class UnitTest1
    {
        [Fact]
        public void Metry_na_Kilometry()
        {
            string jednostka_from = "m";
            string jednostka_to = "km";
            double wartosc = 1500;

            double wynik = Program.Calculate(1,wartosc,jednostka_from,jednostka_to);
            Assert.InRange(wynik, 1.499, 1.501);
        }
        [Fact]
        public void Mile_na_metry()
        {
            string jednostka_from = "mi";
            string jednostka_to = "m";
            double wartosc = 1;

            double wynik = Program.Calculate(1, wartosc, jednostka_from, jednostka_to);
            Assert.InRange(wynik, 1609.33, 1609.35);
        }
        [Fact]
        public void Kilogramy_na_funty()
        {
            string jednostka_from = "kg";
            string jednostka_to = "lb";
            double wartosc = 1;

            double wynik = Program.Calculate(2, wartosc, jednostka_from, jednostka_to);
            Assert.InRange(wynik, 2.2045, 2.2047);
        }
        [Fact]
        public void Miligramy_na_funty()
        {
            double wartosc = 1000000;
            double wynik = Program.Calculate(2, wartosc, "mg", "lb");
            Assert.InRange(wynik, 2.204, 2.205); 
        }
        [Fact]
        public void Celciusze_Fahrenheity()
        {
            string jednostka_from = "c";
            string jednostka_to = "f";
            double wartosc = 100;

            double wynik = Program.Calculate(3, wartosc, jednostka_from, jednostka_to);
            Assert.InRange(wynik, 211.9, 212.1);
        }
        [Fact]
        public void Fahrenhit_na_Celcius()
        {
            double wynik = Program.Calculate(3, 32, "f", "c");
            Assert.InRange(wynik, -0.01, 0.01); 
        }
        [Fact]
        public void Celciusze_na_kelwin()
        {
            string jednostka_from = "c";
            string jednostka_to = "k";
            double wartosc = 0;

            double wynik = Program.Calculate(3, wartosc, jednostka_from, jednostka_to);
            Assert.InRange(wynik, 273.14, 273.16);
        }
        [Fact]
        public void Niepoprawna_dlugosc()
        {
            string jednostka_from = "m";
            string jednostka_to = "blad";
            double wartosc = 1000;

            double wynik = Program.Calculate(3, wartosc, jednostka_from, jednostka_to);
            Assert.Equal(-1.0, wynik);
        }
        [Fact]
        public void Niepoprawna_temp()
        {
            string jednostka_from = "c";
            string jednostka_to = "blad";
            double wartosc = 100;

            double wynik = Program.Calculate(3, wartosc, jednostka_from, jednostka_to);
            Assert.Equal(-1.0, wynik);
        }
    }
}