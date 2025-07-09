namespace Sims__3
{
    public class Game
    {
        private Player _player = new Player { Name = "Gracz" };
        private Inventory _inventory = null!;
        private Shop _shop = null!;

        public void Start()
        {
            Console.Write("Wprowadź imię: ");
            string name = Console.ReadLine() ?? "Gracz";

            _player.Name = name;
            _inventory = new Inventory(_player); 
            _shop = new Shop(_player); 

            Console.WriteLine("Sen spada o 5 jednostek za godzinę, jeśli którykolwiek wskaźnik spadnie do zera, gra się kończy. Postaraj się przeżyć rok.");
            Console.WriteLine("\nNaciśnij dowolny klawisz, aby rozpocząć...");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();

                Console.WriteLine(_player.Status());
                Console.WriteLine("1) Iść do pracy (10h, +250 zł, -40 sytość, -35 rozum)");
                Console.WriteLine("2) Zjeść (1h, -30 zł, +65 sytość)");
                Console.WriteLine("3) Zabawa (3h, -15 sytość, +40 rozum)");
                Console.WriteLine("4) Spać (8h, -20 sytość, +80 sen)");
                Console.WriteLine("5) Sklep");
                Console.WriteLine("6) Ekwipunek");
                Console.WriteLine("7) Wyjście z gry");

                var choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        int hours = _player.OwnsCar ? 8 : 10;
                        int satietyLoss = _player.OwnsCar ? 35 : 50;
                        _player.Money += 250;
                        _player.Satiety -= satietyLoss;
                        _player.Sanity -= 35;
                        _player.AdvanceTime(hours);
                        Console.WriteLine("Poszedłeś do pracy.");
                        break;

                    case "2":
                        _player.Money -= 30;
                        _player.Satiety += 65;
                        _player.AdvanceTime(1);
                        Console.WriteLine("Zjadłeś posiłek.");
                        break;

                    case "3":
                        _player.Satiety -= 15;
                        _player.Sanity += 40;
                        _player.AdvanceTime(3);
                        Console.WriteLine("Dobrze się bawiłeś.");
                        break;

                    case "4":
                        _player.Satiety -= 20;
                        _player.Sleep += _player.OwnsPhone ? 100 : 120;
                        _player.AdvanceTime(8);
                        Console.WriteLine("Spałeś.");
                        break;

                    case "5":
                        _shop.ShowShop();
                        break;

                    case "6":
                        _inventory.ShowInventory();
                        break;

                    case "7":
                        return;
                }

                if (choice is "1" or "2" or "3" or "4")
                {
                    Console.WriteLine("\nNaciśnij dowolny klawisz...");
                    Console.ReadKey();
                }

                CheckGameOver();
            }
        }

        private void CheckGameOver()
        {
            if (_player.Satiety <= 0)
            {
                Console.WriteLine("Zmarłeś z głodu. Koniec gry T-T");
                Environment.Exit(0);
            }
            if (_player.Sanity <= 0)
            {
                Console.WriteLine("Praca doprowadziła cię do szaleństwa. Koniec gry T-T");
                Environment.Exit(0);
            }
            if (_player.Sleep <= 0)
            {
                Console.WriteLine("Zmarłeś z braku snu. Koniec gry T-T");
                Environment.Exit(0);
            }
            if (_player.Money < 0)
            {
                Console.WriteLine("Zostałeś eksmitowany. Koniec gry T-T");
                Environment.Exit(0);
            }
            if (_player.EnergyDrinksToday >= 5)
            {
                Console.WriteLine("Zmarłeś na zawał po energetykach. Koniec gry T-T");
                Environment.Exit(0);
            }
        }
    }
}
