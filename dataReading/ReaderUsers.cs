namespace dataReading
{
    /// <summary>
    /// Reading and writing information about the user's game results
    /// </summary>
    internal static class ReaderUsers
    {
        private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static readonly string folder = Path.Combine(desktopPath, folderName);
        private static readonly string file = Path.Combine(folder, fileName);

        private const string folderName = "User";
        private const string fileName = "Information.dat";

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

        public static List<User> ReadFile()
        {
            var usersList = new List<User>();

            var dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                return null;
            }
            else
            {
                using var reader = new StreamReader(file);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    usersList.Add(new User() { Name = words[0], Text = words[1] });
                }

                return usersList;
            }

            
        }
    }
}
