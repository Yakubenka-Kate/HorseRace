using processing;
using System.Collections;

namespace horseBet
{
    /// <summary>
    /// Bets info for console and sending bets info to processing
    /// </summary>
    internal class BetConsole
    {
        /// <summary>
        /// The user bet
        /// </summary
        public CreateBet MakeBet { get; set; }

        public BetConsole(int count)
        {
            MakeBet = new CreateBet(count);
        }

        public void SendBet(RaceConsole raceConsole, string name, double rate, int position)
        {
            MakeBet.AddBet(raceConsole.MakeRace, name, rate, position);
        }

        public void SendBalance(double balance)
        {
            MakeBet.SetStartBalance(balance);
        }

        public double Balance()
        {
            return MakeBet.GetBalance();
        }

        public double GetProfit(double balance)
        {
            return balance + MakeBet.Profit();
        }

        public IEnumerable BetsForReport()
        {
            return MakeBet.BetsForPrint();
        }

    }
}
