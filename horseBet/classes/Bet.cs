namespace horseBet.classes
{
    /// <summary>
    /// A bet in the race
    /// </summary>
    internal class Bet
    {
        public static double balance;

        /// <summary>
        /// The size of the player's bet on the horse
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// The player's intended finishing position of the horse in the race
        /// </summary>
        public int Position { get; set; }

        public Bet()
        {
            UpdateBalance(Rate);
            Rate = 0;
            Position = 0;
        }

        public Bet(double bet, int position)
        {
            Rate = bet;
            Position = position;
        }

        public void UpdateBalance(double bet)
        {
            balance -= bet;
        }

        public double Profit(int count, Bet[] bet, Horse[] betHorses)
        {
            double profit = 0;

            for (int i = 0; i < count; i++)
            {
                if (bet[i].Position == betHorses[i].HorseResult)
                {
                    profit += bet[i].Rate * betHorses[i].HorseCoef;
                }
            }

            return profit;
        }
    }
}
