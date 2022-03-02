namespace horserace.classes
{
    internal class User
    {
        private string name;
        private string text;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public User()
        {
            name = "";
            text = "";
        }

        public User(string name, string text)
        {
            this.name = name;
            this.text = text;
            CreateFile();
        }
        private void CreateFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("C:\\Users\\Kate\\Desktop");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory("User");

            using (StreamWriter writer = new StreamWriter($"C:\\Users\\Kate\\Desktop\\User\\{name}.dat", append: true))
            {
                writer.AutoFlush = true;
                writer.WriteLine(text);
            }
        }

        public string[] GetFileName(out int count)
        {
            string dirName = "C:\\Users\\Kate\\Desktop\\User";
            string[] files;

            if (Directory.Exists(dirName))
            {
                files = Directory.GetFiles(dirName);
            }
            else
            {
                files = null;
            }

            count = files.Count();

            return files;
        }

        public void ReaderFile()
        {
            string[] files = GetFileName(out int count);

            if (count > 0)
            {
                double[] userResult = new double[count];

                for (int i = 0; i < count; i++)
                {
                    using (StreamReader reader = new StreamReader(files[i]))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            userResult[i] += Convert.ToDouble(line);
                        }
                    }
                }
                List<User> list = GetNameAndResult(files, count, userResult);
                SortUsers(list);
            }
            else
            {
                Console.WriteLine("No files");
            }
        }

        public List<User> GetNameAndResult(string[] files, int count, double[] userResult)
        {
            List<User> list = new List<User>();

            for (int i = 0; i < count; i++)
            {
                int index = files[i].LastIndexOf('\\') + 1;
                files[i] = files[i].Substring(index);
                int dot = files[i].LastIndexOf('.');
                files[i] = files[i].Substring(0, dot);
                list.Add(new User() { Name = files[i], Text = Convert.ToString(userResult[i]) });
            }
            return list;
        }

        public void SortUsers(List<User> list)
        {
            var sortedUsers = from user in list orderby Convert.ToDouble(user.text) descending select user;
            foreach (var user in sortedUsers)
            {
                Console.WriteLine($"{user.Name} - {user.Text}");
            }
        }

    }
}
