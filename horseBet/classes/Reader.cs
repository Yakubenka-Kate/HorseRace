using System.Collections.Generic;

namespace horseBet.classes
{
    internal class Reader
    {
        private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static readonly string folder = Path.Combine(desktopPath, "User");
        private static readonly string file = Path.Combine(folder, "Information.dat");

        public List<User> list { get; set; } = new List<User>();

        public void CreateOrWrite(User user)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using StreamWriter writer = new StreamWriter(file, append: true);         
                writer.AutoFlush = true;
                writer.WriteLine(user.Name + " - " + user.Text);           
        }

        public void ReaderFile()
        {
            using StreamReader reader = new StreamReader(file);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    list.Add(new User() { Name = words[0], Text = words[1] });
                }
            
            SortUsers();      
        }

        private void SortUsers()
        {
            var sortedUsers = from user in list
                              orderby Convert.ToDouble(user.Text) descending
                              select user;

            foreach (var users in sortedUsers)
            {
                Console.WriteLine($"{users.Name} - {users.Text}");

            }
        }
    }
}
