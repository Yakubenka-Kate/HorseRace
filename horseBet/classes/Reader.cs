namespace horseBet.classes
{
    /// <summary>
    /// Reading and writing information  about the user's game results
    /// </summary>
    internal class Reader
    {
        private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static readonly string folder = Path.Combine(desktopPath, folderName);
        private static readonly string file = Path.Combine(folder, fileName);

        private const string folderName = "User";
        private const string fileName = "Information.dat";
        public IEnumerable<User> SortedUsers { get; set; } = new List<User>();       //?

        public static void CreateOrWrite(User user)
        {
            var dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using var writer = new StreamWriter(file, append: true);
                writer.AutoFlush = true;
                writer.WriteLine(user.Name + " - " + user.Text);
        }

        public void ReadFile()
        {
            var usersList  = new List<User>();
            using var reader = new StreamReader(file);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    usersList.Add(new User() { Name = words[0], Text = words[1] });
                }
            
            SortedUsers =  SortUsers(usersList);
        }

        private IEnumerable<User> SortUsers(List<User> usersList)
        {
            var sortedUsers = from user in usersList
                              orderby Convert.ToDouble(user.Text) descending
                              select user;

            return sortedUsers;
        }
    }
}
