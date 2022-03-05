namespace horseBet.classes
{
    internal class Game
    {
        private const double startBalance = 500.00;
        public void MakeBets()
        {
            var raceHorses = HorseList(out int count);

            int betsCount = BetsCount(raceHorses);

            var betHorses = new Horse[betsCount];
            var bet = new Bet[betsCount];
            var res = new Bet();
            Bet.balance = startBalance;

            for (int i = 0; i < betsCount; i++)
            {
                betHorses[i] = SelectHorses(raceHorses);
                bet[i] = BetsAndPosition(count);
            }

            raceHorses.PrintWithResult();

            double profit = res.Profit(betsCount, bet, betHorses);
            double total = Bet.balance + profit;

            Console.WriteLine($"Balance: {total:F2}");

            GetUser(Convert.ToString(Math.Round(total, 2)));
        }

        public Race HorseList(out int count)
        {
            //Console.WriteLine("Enter count of horses in race");
            Console.WriteLine(Communication.horseCount);

            while ((!int.TryParse(Console.ReadLine(), out count)) || count < 5 || count > 15)
            {
                Console.WriteLine("Incorrect, range mast be between 5 and 15");
                Console.WriteLine(Communication.horseCount);
            }

            Console.WriteLine("Horse List:");

            var newRace = new Race(count);

            newRace.NewRace();
            newRace.PrintTable();

            return newRace;
        }

        public int BetsCount(Race raceHorses)
        {
            int count;
            var betHorse = new Horse[3];

            Console.WriteLine("How many bets do you want to make?(max: 3)");

            while ((!int.TryParse(Console.ReadLine(), out count)) || count < 0 || count > 3)
            {
                Console.WriteLine("Incorrect, range mast be between 1 and 3");
                Console.WriteLine("Enter how many bets you want to make");
            }

            return count;
        }

        public Horse SelectHorses(Race raceHorses)
        {
            Console.WriteLine("Enter horse name for bet");
            string? name = Console.ReadLine();

            bool isHorse = raceHorses.IsHorse(name!, out Horse betHorse);

            while (isHorse != true)
            {
                Console.WriteLine("No horse with this name");
                Console.WriteLine("Enter horse name for bet");

                name = Console.ReadLine();
                isHorse = raceHorses.IsHorse(name!, out betHorse);
            }

            return betHorse;
        }

        public Bet BetsAndPosition(int count)
        {
            var newBet = new Bet();
            double bet;
            int position;

            Console.WriteLine($"Enter bet (Balanсe - {Bet.balance:F2})");

            while ((!double.TryParse(Console.ReadLine(), out bet)) || bet < 0 || bet > Bet.balance)
            {
                Console.WriteLine($"Incorrect. Enter bet (Balanсe - {Bet.balance:F2})");
            }

            Console.WriteLine("Enter the position");

            while ((!int.TryParse(Console.ReadLine(), out position)) || position > count || position < 0)
            {
                Console.WriteLine("Incorrect. Enter the position:");
            }

            newBet.UpdateBalance(bet);
            newBet = new Bet(bet, position);

            return newBet;
        }

        public void GetUser(string profit)
        {
            Console.WriteLine("Enter your name");
            string? name = Console.ReadLine();
            var username = new User(name, profit);

            var enter = new Reader();
            enter.CreateOrWrite(username);
        }

        public void GetUserInfo()
        {
            var info = new Reader();
            info.ReaderFile();
        }
    }
}
