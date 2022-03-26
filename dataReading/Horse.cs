namespace dataReading
{
    /// <summary>
    /// Horses in the race
    /// </summary>
    internal class Horse
    {
        /// <summary>
        /// Sets name of horse in the race
        /// </summary>
        public string HorseName { get; set; }

        /// <summary>
        /// Sets coefficient for horse to win in the race
        /// </summary>
        public double HorseCoef { get; set; }

        /// <summary>
        /// The finishing position of the horse in the race
        /// </summary>
        public int HorseResult { get; set; }

        public Horse(string name, double coef, int result)
        {
            HorseName = name;
            HorseCoef = coef;
            HorseResult = result;
        }

        public override string ToString() => $"{HorseName,7} {HorseCoef,6}  {HorseResult}";

    }
}
