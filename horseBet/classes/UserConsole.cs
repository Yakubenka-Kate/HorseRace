namespace horseBet.classes
{
    internal class UserConsole : Reader
    {
        public void PrintUsers()
        {
            foreach (var users in SortedUsers)
            {
                Printer.Print(users.ToString());
            }
        }
    }
}
