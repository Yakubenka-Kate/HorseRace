using horseBet;
using processing;
using System.Collections;

/// <summary>
/// Starting the gameplay
/// </summary>
class Program
{

    static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
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
            case 3:
                ReportMenu();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine(Communication.incorrect);
                break;
        }
    }

    public static void SubMenu(string name, IEnumerable bet)
    {
        Console.WriteLine(Communication.subMenu);

        int i;
        while (!int.TryParse(Console.ReadLine(), out i))
        {
            Console.WriteLine(Communication.subMenu);
        }

        switch (i)
        {
            case 1:
                CreateReport.CreateNewExcel(name!, bet);
                Program.Menu();
                break;
            case 0:
                Program.Menu();
                break;
            default:
                Console.WriteLine(Communication.incorrect);
                break;
        }
    }

    public static void ReportMenu()
    {
        string name;

        Console.WriteLine(Communication.reportMenu);

        int i;
        while (!int.TryParse(Console.ReadLine(), out i))
        {
            Console.WriteLine(Communication.reportMenu);
        }

        switch (i)
        {
            case 1:
                CreateReport.ReadAllRaces();
                Menu();
                break;
            case 2:
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                CreateReport.ReadUsersInRace(name!);
                Menu();
                break;
            case 3:
                Console.WriteLine("Enter name");
                name = Console.ReadLine();
                CreateReport.ReadHorsesInRace(name!);
                Menu();
                break;
            case 0:
                Program.Menu();
                break;
            default:
                Console.WriteLine(Communication.incorrect);
                break;
        }
    }

}