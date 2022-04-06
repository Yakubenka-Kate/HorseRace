using dataReading;
using System.Collections;

namespace processing
{
    /// <summary>
    /// Sorted users from info file
    /// </summary>
    internal static class SortUsers
    {
        public static IEnumerable SortUsersFromReader()
        {
            var SortedUsers = ReaderUsers.ReadFile()
                 .Select(user => new User()
                 {
                     Name = user.Name,
                     Text = user.Text,
                 })
                 .OrderByDescending(user => user.Text)
                 .Select(user => user.ToString());

            return SortedUsers;
        }
    }
}
