using dataReading;
using System.Collections;

namespace processing
{
    internal static class SortHorses
    {
        public static IEnumerable SortHorsesInRace(CreateRace race)
        {
            var sortHorses = race.GenerateRace.HorsesInRace
                 .Select(horse => new Horse()
                 {
                     HorseName = horse.HorseName,
                     HorseCoef = horse.HorseCoef,
                     HorseResult = horse.HorseResult,
                 })
                 .OrderBy(horse => horse.HorseResult)
                 .Select(horse => horse.ToString());
                 
            return sortHorses;
        }
    }
}
