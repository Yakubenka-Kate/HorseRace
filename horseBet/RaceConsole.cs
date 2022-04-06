using processing;
using System.Collections;

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

        public IEnumerable HorsesForReport()
        {
            return SortHorses.SortHorsesInRace(MakeRace);
        }

        public void PrintHorsesWithResult()
        {
            var horses = SortHorses.SortHorsesInRace(MakeRace);

            foreach (var o in horses) {
                Printer.Print(o.ToString());
            }
        }

        public void PrintHorsesWithoutResul()
        {
            string[] horses = MakeRace.NewRace();

            foreach(var h in horses)
            {
                Printer.Print($"{h[..12]}");
            }
        }
    }
}
