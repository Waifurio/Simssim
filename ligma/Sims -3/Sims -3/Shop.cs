namespace Sims__3
{
    public class Shop
    {
        private Player _player;
        public Shop(Player player) => _player = player;

        public void ShowShop()
        {
            Console.WriteLine("\nSklep:");
            Console.WriteLine("1) Samochód - 3500 zł");
            Console.WriteLine("2) Telefon - 2300 zł");
            Console.WriteLine("3) Energetyk - 20 zł");
            Console.WriteLine("4) Luksusowy wynajem - 2000 zł/miesiąc");
            Console.WriteLine("5) Kup mieszkanie - 45000 zł");
            Console.WriteLine("6) Kup luksusowe mieszkanie - 80000 zł");
            Console.WriteLine("7) Złoty samochód - 100000 zł");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (_player.Money >= 3500 && !_player.OwnsCar)
                    {
                        _player.Money -= 3500;
                        _player.OwnsCar = true;
                        Console.WriteLine("Kupiłeś samochód.");
                    }
                    break;
                case "2":
                    if (_player.Money >= 2300 && !_player.OwnsPhone)
                    {
                        _player.Money -= 2300;
                        _player.OwnsPhone = true;
                        _player.SanityLimit = 150;
                        Console.WriteLine("Kupiłeś telefon.");
                    }
                    break;
                case "3":
                    if (_player.Money >= 20)
                    {
                        _player.Money -= 20;
                        _player.Sleep += 15;
                        _player.Sanity -= 10;
                        _player.EnergyDrinksToday++;
                        _player.AdvanceTime(1);
                        Console.WriteLine("Wypiłeś energetyka.");
                    }
                    break;
                case "4":
                    if (_player.Money >= 2000 && !_player.OwnsLuxuryFlat)
                    {
                        _player.Money -= 2000;
                        _player.SatietyLimit += 25;
                        _player.SanityLimit += 25;
                        _player.SleepLimit += 25;
                        _player.Rent = 2000;
                        Console.WriteLine("Wynająłeś luksusowe mieszkanie.");
                    }
                    break;
                case "5":
                    if (_player.Money >= 45000 && !_player.OwnsFlat)
                    {
                        _player.Money -= 45000;
                        _player.OwnsFlat = true;
                        _player.Rent = 0;
                        Console.WriteLine("Kupiłeś mieszkanie.");
                    }
                    break;
                case "6":
                    if (_player.Money >= 80000 && !_player.OwnsLuxuryFlat)
                    {
                        _player.Money -= 80000;
                        _player.OwnsLuxuryFlat = true;
                        _player.Rent = 0;
                        _player.SatietyLimit += 25;
                        _player.SanityLimit += 25;
                        _player.SleepLimit += 25;
                        Console.WriteLine("Kupiłeś luksusowe mieszkanie.");
                    }
                    break;
                case "7":
                    if (_player.Money >= 100000)
                    {
                        _player.Money -= 100000;
                        Console.WriteLine("Kupiłeś złoty samochód. Gratulacje, jesteś bogaty! (nie ma różnicy)");
                    }
                    break;
            }

            _player.ClampStats();
        }
    }
}
