using dataReading;

namespace processing
{
    /// <summary>
    /// Create a bet
    /// </summary>
    internal class CreateBet
    {
        /// <summary>
        /// The count of bets the user makes
        /// </summary>
        public int CountBets { get; set; }

        /// <summary>
        /// The user bets
        /// </summary>
        public Bet[] GenerateBets { get; set; }

        public CreateBet(int count)
        {
            CountBets = 0;
            GenerateBets = new Bet[count];
        }

        public void SetStartBalance(double balance)
        {
            Bet.balance = balance;
        }

        public double GetBalance()
        {
            return Bet.balance;
        }

        public void UpdateBalance(double bet)
        {
            Bet.balance -= bet;
        }

        public void AddBet(CreateRace race, string name, double rate, int position)
        {
            GenerateBets[CountBets] = new Bet(race.GetHorseByName(name), rate, position);
            CountBets++;
            UpdateBalance(rate);
        }

        public string[] BetsForPrint()
        {
            string[] bets = new string[CountBets];
            string[] result = new string[CountBets];

            for (int i = 0; i < CountBets; i++)
            {
                if (GenerateBets[i].BetHorse.HorseResult == GenerateBets[i].Position)
                {
                    result[i] = "Win";
                }
                else
                {
                    result[i] = "Lose";
                }
            }

            for (int i = 0; i < CountBets; i++)
            {
                bets[i] = $"{GenerateBets[i].BetHorse.HorseName,4} {GenerateBets[i].BetHorse.HorseCoef} " +
                          $"{GenerateBets[i].BetHorse.HorseResult} {GenerateBets[i].Rate} {GenerateBets[i].Position} " +
                          $"{result[i]}";
            }

            return bets;
        }

        public double Profit()
        {
            double profit = 0;

            for (int i = 0; i < CountBets; i++)
            {
                if (GenerateBets[i].BetHorse.HorseResult == GenerateBets[i].Position)
                {
                    profit += GenerateBets[i].Rate * GenerateBets[i].BetHorse.HorseCoef;
                }
            }

            return profit;
        }
    }
}
