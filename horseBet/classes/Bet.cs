namespace horseBet.classes
{
    internal class Bet
    {
        public static double balance;
        private double rate;
        private int position;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public Bet()
        {
            UpdateBalance(rate);
            rate = 0;
            position = 0;
        }

        public Bet(double bet, int position)
        {
            this.rate = bet;
            this.position = position;
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
