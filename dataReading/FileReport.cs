using System.Collections;
using System.Text.RegularExpressions;

namespace dataReading
{
    internal class FileReport
    {
        private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static readonly string folder = Path.Combine(desktopPath, folderName);
        private static readonly string file = Path.Combine(folder, fileName);

        private const string folderName = "User";
        private const string fileName = "Race.dat";

        public static void AddNewRace(string[] race, string name, string[] bet)
        {
            var dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using var writer = new StreamWriter(file, append: true);
            writer.AutoFlush = true;
            writer.WriteLine($"--Race{name}--");

            for (int i = 0; i < race.Length; i++)
            {
                writer.Write(race[i]);
                for (int j = 0; j < bet.Length; j++)
                {
                    string[] words = bet[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (race[i].Substring(0, 4) == bet[j].Substring(0, 4))
                    {
                        writer.Write(" " + name + " " + words[5]);
                        break;
                    }
                }
                writer.Write("\n");
            }
            writer.WriteLine("/");

        }

        public static void ReadRaces()
        {
            var dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                Console.WriteLine("Empty"); ;
            }
            else
            {
                using var reader = new StreamReader(file);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void ReadUserRaces()
        {
            var listFile = new ArrayList();

            using var reader = new StreamReader(file);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                
            }

            foreach (object o in listFile)
            {
                Console.WriteLine(o);
            }

        }

    }
}
