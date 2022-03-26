namespace processing
{
    /// <summary>
    /// Checking the existence of a horse in a race
    /// </summary>
    internal static class CreateRaceExtention
    {
        public static bool IsHorse(this CreateRace horses, string name)
        {
            for (int i = 0; i < horses.GenerateRace.CountHorses; i++)
            {
                if (name == horses.GenerateRace.HorsesInRace[i].HorseName)
                {
                    return true;
                }
                else continue;

            }

            return false;
        }
    }
}
