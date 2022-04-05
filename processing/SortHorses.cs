using dataReading;
using System.Collections;

namespace processing
{
    internal static class SortHorses
    {
        public static string[] SortHorsesInRace(CreateRace race)
        {
            var horsesInRace = new List<Horse>();
            IEnumerable<Horse> sortHorses = new List<Horse>();

            for (int i = 0; i < race.GenerateRace.CountHorses; i++)
            {
                horsesInRace.Add(new Horse()
                {
                    HorseName = race.GenerateRace.HorsesInRace[i].HorseName,
                    HorseCoef = race.GenerateRace.HorsesInRace[i].HorseCoef,
                    HorseResult = race.GenerateRace.HorsesInRace[i].HorseResult,
                });

            }

            sortHorses = from horse in horsesInRace
                         orderby horse.HorseResult
                         select horse;

            return sortHorses.Select(n => n.ToString()).ToArray();
        }
    }
}
