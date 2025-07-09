namespace Sims__3
{
    public class Inventory
    {
        private Player _player;
        public Inventory(Player player) => _player = player;

        public void ShowInventory()
        {
            Console.WriteLine("\nEkwipunek:");
            if (!_player.OwnsFlat && !_player.OwnsLuxuryFlat)
                Console.WriteLine("- Podstawowe mieszkanie (wynajem): -1500 zł/miesiąc");
            if (_player.OwnsFlat)
                Console.WriteLine("- Kupione mieszkanie");
            if (_player.OwnsLuxuryFlat)
                Console.WriteLine("- Kupione luksusowe mieszkanie");
            if (_player.OwnsCar)
                Console.WriteLine("- Samochód");
            if (_player.OwnsPhone)
                Console.WriteLine("- Telefon");
        }
    }
}
