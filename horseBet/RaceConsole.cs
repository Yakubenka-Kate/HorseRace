using processing;

namespace horseBet
{
    /// <summary>
    /// Race info for console
    /// </summary>
    internal class RaceConsole
    {
        /// <summary>
        /// The horses in race for console
        /// </summary>
        public string[] HorsesInRace { get; set; }

        /// <summary>
        /// The horse race
        /// </summary>
        public CreateRace MakeRace { get; set; }

        public void GetRace(int count)
        {
            MakeRace = new CreateRace(count);
            HorsesInRace = MakeRace.NewRace();
        }

        public bool HorseCheck(string name)
        {
            return MakeRace.IsHorse(name);
        }

        public void PrintHorsesWithResult()
        {
            for (int i = 0; i < HorsesInRace.Length; i++)
            {
                Printer.Print(HorsesInRace[i]);
            }
        }

        public void PrintHorsesWithoutResul()
        {
            for (int i = 0; i < HorsesInRace.Length; i++)
            {
                Printer.Print($"{HorsesInRace[i].Substring(0, 14)}");
            }
        }
    }
}
