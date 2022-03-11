namespace horseBet.classes
{
    /// <summary>
    /// Sends information about the player to the output
    /// </summary>
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
