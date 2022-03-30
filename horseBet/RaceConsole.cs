using processing;

namespace horseBet
{
    /// <summary>
    /// Race info for console
    /// </summary>
    internal class RaceConsole 
    { 
        /// <summary>
        /// The horse race
        /// </summary>
        public CreateRace MakeRace { get; set; }

        public void GetRace(int count)
        {
            MakeRace = new CreateRace(count);
        }

        public bool HorseCheck(string name)
        {
            return MakeRace.IsHorse(name);
        }

        public string[] HorsesForReport()
        {
            return SortHorses.SortHorsesInRace(MakeRace);
        }

        public void PrintHorsesWithResult()
        {
            string[] horses = SortHorses.SortHorsesInRace(MakeRace);

            for (int i = 0; i < horses.Length; i++)
            {
                Printer.Print(horses[i]);
            }
        }

        public void PrintHorsesWithoutResul()
        {
            string[] horses = MakeRace.NewRace();

            for (int i = 0; i < horses.Length; i++)
            {
                Printer.Print($"{horses[i].Substring(0, 12)}");
            }
        }
    }
}
