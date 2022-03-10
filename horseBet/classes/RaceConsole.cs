namespace horseBet.classes
{
    internal class RaceConsole : Race
    {
        public RaceConsole(int count) : base(count) { }

        public void PrintHorsesWithResult()
        {
            for (int i = 0; i < CountHorses; i++)
            {
                Printer.Print(HorsesInRace[i].ToString());
            }
        }
        public void PrintHorses()
        {
            for (int i = 0; i < CountHorses; i++)
            {
                Printer.Print($"{HorsesInRace[i].HorseName,7} {HorsesInRace[i].HorseCoef,6:F2}");
            }
        }

    }
}
