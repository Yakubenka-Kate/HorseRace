using dataReading;

namespace processing
{
    /// <summary>
    /// Sorted users from info file
    /// </summary>
    internal static class SortUsers
    {
        public static IEnumerable<User> SortedUsers { get; set; } = new List<User>();

        public static void SortUsersFromReader()
        {
            List<User>? usersFromFile = Reader.ReadFile();

            SortedUsers = from user in usersFromFile
                          orderby Convert.ToDouble(user.Text) descending
                          select user;
        }
    }
}
