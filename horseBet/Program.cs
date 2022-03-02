using horserace.classes;
class Program
{
    private const double startBalance = 500.00;
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("1. Make bet");
        Console.WriteLine("2. Users info");
        Console.WriteLine("0. Exit");

        int i;
        while (!int.TryParse(Console.ReadLine(), out i))
        {
            Console.WriteLine("1. Make bet");
            Console.WriteLine("2. Users info");
            Console.WriteLine("0. Exit");
        }

        switch (i)
        {
            case 1:
                MakeBets();
                break;
            case 2:
                GetUserInfo();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Incorrect");
                break;
        }

    }

    static public void MakeBets()
    {
        Race raceHorses = HorseList(out int count);

        int betsCount = BetsCount(raceHorses);

        Horse[] betHorses = new Horse[betsCount];
        Bet[] bet = new Bet[betsCount];
        Bet res = new Bet();
        Bet.balance = startBalance;

        for (int i = 0; i < betsCount; i++)
        {
            betHorses[i] = SelectHorses(raceHorses);
            bet[i] = BetsAndPosition(count);
        }

        raceHorses.PrintWirhResult();

        double profit = res.Profit(betsCount, bet, betHorses);
        double total = Bet.balance + profit;

        Console.WriteLine($"Balance: {total:F2}");

        GetUser(Convert.ToString(Math.Round(total, 2)));

        Menu();
    }

    static Race HorseList(out int count)
    {
        Console.WriteLine("Enter count of horses in race");

        while ((!int.TryParse(Console.ReadLine(), out count)) || count < 5 || count > 15)
        {
            Console.WriteLine("Incorrect, range mast be between 5 and 15");
            Console.WriteLine("Enter count of horses in race");
        }

        Console.WriteLine("Horse List:");

        Race newRace = new Race(count);

        newRace.NewRace();
        newRace.PrintTable();

        return newRace;
    }

    static int BetsCount(Race raceHorses)
    {
        int count;
        Horse[] betHorse = new Horse[3];

        Console.WriteLine("How many bets do you want to make?(max: 3)");

        while ((!int.TryParse(Console.ReadLine(), out count)) || count < 0 || count > 3)
        {
            Console.WriteLine("Incorrect, range mast be between 1 and 3");
            Console.WriteLine("Enter how many bets you want to make");
        }

        return count;
    }

    static Horse SelectHorses(Race raceHorses)
    {
        Horse betHorse;

        Console.WriteLine("Enter horse name for bet");
        string? name = Console.ReadLine();

        bool isHorse = raceHorses.IsHorse(name!, out betHorse);

        while (isHorse != true)
        {
            Console.WriteLine("No horse with this name");
            Console.WriteLine("Enter horse name for bet");

            name = Console.ReadLine();
            isHorse = raceHorses.IsHorse(name!, out betHorse);
        }

        return betHorse;
    }

    static Bet BetsAndPosition(int count)
    {
        Bet newBet = new Bet();
        double bet;
        int position;

        Console.WriteLine($"Enter bet (Balanse - {Bet.balance:F2})");

        while ((!double.TryParse(Console.ReadLine(), out bet)) || bet < 0 || bet > Bet.balance)
        {
            Console.WriteLine($"Incoorect. Enter bet (Balanse - {Bet.balance:F2})");
        }

        Console.WriteLine("Enter the position");

        while ((!int.TryParse(Console.ReadLine(), out position)) || position > count || position < 0)
        {
            Console.WriteLine("Incoorect. Enter the position:");
        }

        newBet.UpdateBalance(bet);
        newBet = new Bet(bet, position);

        return newBet;
    }

    static void GetUser(string profit)
    {
        Console.WriteLine("Enter your name");
        string? name = Console.ReadLine();
        User username = new User(name, profit);
    }

    static void GetUserInfo()
    {
        User user = new User();
        user.ReaderFile();
        Menu();
    }
}
