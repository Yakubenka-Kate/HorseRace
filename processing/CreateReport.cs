using dataReading;

namespace processing
{
    internal class CreateReport
    {
        public static void AddRaceInFile(string[] race, string name, string[] bet)
        {
            FileReport.AddNewRace(race, name, bet);
        }

        public static void CreateNewExcel(string name, string[] bet)
        {
            Excel.UserExcel(name, bet);
        }

        public static void ReadAllRaces()
        {
            FileReport.ReadRaces();
        }

        public static void ReadUsersInRace()
        {
            FileReport.ReadUserRaces();
        }
    }
}
