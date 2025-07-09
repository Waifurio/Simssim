namespace Sims__3
{
    public class Player
    {
        public required string Name { get; set; }
        public int Day { get; set; } = 1;
        public int Month { get; set; } = 1;
        public int Hour { get; set; } = 0;
        public int Satiety { get; set; } = 100;
        public int Sanity { get; set; } = 100;
        public int Sleep { get; set; } = 100;
        public int Money { get; set; } = 0;

        public int SatietyLimit { get; set; } = 100;
        public int SanityLimit { get; set; } = 100;
        public int SleepLimit { get; set; } = 100;

        public bool OwnsPhone { get; set; } = false;
        public bool OwnsCar { get; set; } = false;
        public bool OwnsLuxuryFlat { get; set; } = false;
        public bool OwnsFlat { get; set; } = false;

        public int EnergyDrinksToday { get; set; } = 0;
        public int Rent { get; set; } = 1500;

        public void AdvanceTime(int hours)
        {
            Hour += hours;
            for (int i = 0; i < hours; i++)
            {
                Sleep -= 5;
                if (OwnsPhone && i % 2 == 0)
                    Sanity += 5;
            }

            if (Hour >= 24)
            {
                Hour -= 24;
                Day++;
                EnergyDrinksToday = 0;

                if (Day > 30)
                {
                    Day = 1;
                    Month++;
                    PayRent();
                }
            }

            ClampStats();
        }

        public void ClampStats()
        {
            Satiety = Math.Min(Satiety, SatietyLimit);
            Sanity = Math.Min(Sanity, SanityLimit);
            Sleep = Math.Min(Sleep, SleepLimit);

            Satiety = Math.Max(Satiety, 0);
            Sanity = Math.Max(Sanity, 0);
            Sleep = Math.Max(Sleep, 0);
        }

        private void PayRent()
        {
            if (!OwnsFlat && !OwnsLuxuryFlat)
            {
                Money -= Rent;
            }
        }

        public string Status()
        {
            return $"{Name} | Miesiąc {Month}, Dzień {Day}/30, {Hour}/24 godz | {Satiety}/{SatietyLimit} sytość | {Sanity}/{SanityLimit} rozum | {Sleep}/{SleepLimit} sen | {Money} zł";
        }
    }
}
