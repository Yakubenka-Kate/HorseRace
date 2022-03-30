using dataReading;

namespace processing
{
    /// <summary>
    /// Sorted users from info file
    /// </summary>
    internal static class SortUsers
    {
        public static string[] SortUsersFromReader()
        {
            var usersFromFile = ReaderUsers.ReadFile();
            IEnumerable<User> SortedUsers = new List<User>();

            if (usersFromFile != null)
            {
                SortedUsers = from user in usersFromFile
                              orderby Convert.ToDouble(user.Text) descending
                              select user;
            }
            else
            {
                Console.WriteLine("Empty");
            }

            return SortedUsers.Select(n => n.ToString()).ToArray();
        }
    }
}
