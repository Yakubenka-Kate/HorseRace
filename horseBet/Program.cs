using horseBet.classes;
class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        var game = new Game();

        Console.WriteLine(Communication.menu);

        int i;
        while (!int.TryParse(Console.ReadLine(), out i))
        {
            Console.WriteLine(Communication.menu);
        }

        switch (i)
        {
            case 1:
                game.MakeBets();
                Menu();
                break;
            case 2:
                game.GetUserInfo();
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
