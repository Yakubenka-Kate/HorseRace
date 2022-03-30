using processing;

namespace horseBet
{
    /// <summary>
    /// The user info for console
    /// </summary>
    internal class UserConsole
    {
        /// <summary>
        /// The player
        /// </summary>
        public CreateNewUser User { get; set; }

        public void AddNewUser(string name, string profit)
        {
            User = new CreateNewUser();
            User.AddUser(name, profit);
        }

        public static void PrintUsers()
        {
            foreach (var users in SortUsers.SortUsersFromReader())
            {
                Printer.Print(users);
            }
        }
    }
}
