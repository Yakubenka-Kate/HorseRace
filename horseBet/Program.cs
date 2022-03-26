using horseBet;

/// <summary>
/// Starting the gameplay
/// </summary>
class Program
{

    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine(Communication.menu);

        int i;
        while (!int.TryParse(Console.ReadLine(), out i))
        {
            Console.WriteLine(Communication.menu);
        }

        switch (i)
        {
            case 1:
                Game.StartGame();
                Menu();
                break;
            case 2:
                Game.GetUsersInfo();
                Menu();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine(Communication.incorrect);
                break;
        }
    }
}