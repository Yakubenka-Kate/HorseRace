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
            Console.WriteLine(Communication.horseCount);

            while ((!int.TryParse(Console.ReadLine(), out count)) || count < 5 || count > 15)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine(Communication.horseCount);
            }

            var newRace = new Race(count);

            newRace.NewRace();
            newRace.PrintWithResult();

            return newRace;
        }

        public int BetsCount(Race raceHorses)
        {
            int count;
            var betHorse = new Horse[3];

            Console.WriteLine(Communication.betCount);

            while ((!int.TryParse(Console.ReadLine(), out count)) || count < 0 || count > 3)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine(Communication.betCount);
            }

            return count;
        }

        public Horse SelectHorses(Race raceHorses)
        {
            Console.WriteLine(Communication.horseName);
            string? name = Console.ReadLine();

            bool isHorse = raceHorses.IsHorse(name!, out Horse betHorse);

            while (isHorse != true)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine(Communication.horseName);

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

            Console.WriteLine($"{Communication.bet}{Bet.balance:F2})");

            while ((!double.TryParse(Console.ReadLine(), out bet)) || bet < 0 || bet > Bet.balance)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine($"{Communication.bet} {Bet.balance:F2})");
            }

            Console.WriteLine(Communication.position);

            while ((!int.TryParse(Console.ReadLine(), out position)) || position > count || position < 0)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine(Communication.position);
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
