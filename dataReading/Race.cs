namespace dataReading
{
    /// <summary>
    /// The horse race
    /// </summary>
    internal class Race
    {
        /// <summary>
        /// Number of horses in the race
        /// </summary>
        public int CountHorses { get; set; }

        /// <summary>
        /// Horses in the race
        /// </summary>
        public Horse[] HorsesInRace { get; set; } = new Horse[15];


        public Race(int count) => CountHorses = count;

    }
}
