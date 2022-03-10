namespace horseBet.classes
{
    internal class Bet
    {
        public static double balance;
        public double Rate { get; set; }
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
