namespace dataReading
{
    /// <summary>
    /// A bet in the race
    /// </summary>
    internal class Bet
    {
        /// <summary>
        /// User balance in the game
        /// </summary>
        public static double balance;

        public Horse BetHorse { get; set; }

        /// <summary>
        /// The size of the player's bet on the horse
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// The player's intended finishing position of the horse in the race
        /// </summary>
        public int Position { get; set; }

        public Bet(Horse horse, double rate, int position)
        {
            BetHorse = horse;
            Rate = rate;
            Position = position;

        }
    }
}
