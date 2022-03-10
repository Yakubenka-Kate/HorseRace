namespace horseBet.classes
{
    internal static class RaceExtention
    {
        public static bool IsHorse(this Race horses, string name, out Horse? horse)
        {
            for (int i = 0; i < horses.CountHorses; i++)
            {
                if (name == horses.HorsesInRace[i].HorseName)
                {
                    horse = horses.HorsesInRace[i];
                    return true;
                }
                else continue;
            }
            
            horse = null;
            return false;
        }
    }
}
