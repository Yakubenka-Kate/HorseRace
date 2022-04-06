//using processing;

using processing;

namespace horseBet
{
    /// <summary>
    /// Implements the gameplay for the race
    /// </summary>
    internal class Game
    {
        private const double startBalance = 500.00;

        public static void StartGame()
        {
            var raceHorses = CreateRace(out int countHorsesInRace);

            int countBets = BetsCount();

            var bet = CreateBet(countHorsesInRace, countBets, raceHorses);

            raceHorses.PrintHorsesWithResult();
            Console.WriteLine(Math.Round(bet.GetProfit(bet.Balance()), 2));

            string name = SetUser(bet.GetProfit(bet.Balance()));

            CreateReport.AddRaceInFile(raceHorses.HorsesForReport(), name, bet.BetsForReport());

            Program.SubMenu(name!, bet.BetsForReport());
        }

        public static RaceConsole CreateRace(out int countHorsesInRace)
        {
            var race = new RaceConsole();

            Console.WriteLine(Communication.horseCount);
            while (!int.TryParse(Console.ReadLine(), out countHorsesInRace) || countHorsesInRace < 5 || countHorsesInRace > 15)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine(Communication.horseCount);
            }

            race.GetRace(countHorsesInRace);
            race.PrintHorsesWithoutResul();

            return race;
        }

        public static int BetsCount()
        {
            int count;

            Console.WriteLine(Communication.betCount);

            while (!int.TryParse(Console.ReadLine(), out count) || count < 0 || count > 3)
            {
                Console.WriteLine(Communication.incorrect);
                Console.WriteLine(Communication.betCount);
            }

            return count;
        }

        public static BetConsole CreateBet(int countHorsesInRace, int countBets, RaceConsole raceHorses)
        {
            var bet = new BetConsole(countBets);
            bet.SendBalance(startBalance);

            for (int i = 0; i < countBets; i++)
            {
                Console.WriteLine(Communication.horseName);
                string? name = Console.ReadLine();
                bool isHorse = raceHorses.HorseCheck(name!);

                while (isHorse != true)
                {
                    Console.WriteLine(Communication.incorrect);
                    Console.WriteLine(Communication.horseName);

                    name = Console.ReadLine();
                    isHorse = raceHorses.HorseCheck(name!);
                }

                double rate;
                int position;

                Console.WriteLine($"{Communication.bet}{bet.Balance():F2})");

                while (!double.TryParse(Console.ReadLine(), out rate) || rate < 0 || rate > bet.Balance())
                {
                    Console.WriteLine(Communication.incorrect);
                    Console.WriteLine($"{Communication.bet}{bet.Balance():F2})");
                }

                Console.WriteLine(Communication.position);

                while (!int.TryParse(Console.ReadLine(), out position) || position > countHorsesInRace || position < 0)
                {
                    Console.WriteLine(Communication.incorrect);
                    Console.WriteLine(Communication.position);
                }

                bet.SendBet(raceHorses, name!, rate, position);
            }

            return bet;
        }

        public static string SetUser(double profit)
        {
            Console.WriteLine(Communication.userName);
            string? name = Console.ReadLine();
            var user = new UserConsole();
            user.AddNewUser(name!, profit.ToString());

            return name!;
        }

        public static void GetUsersInfo()
        {
            UserConsole.PrintUsers();
        }

    }
}
