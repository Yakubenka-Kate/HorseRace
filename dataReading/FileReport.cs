using System.Collections;

namespace dataReading
{
    internal class FileReport
    {
        private static readonly string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        private static readonly string folder = Path.Combine(desktopPath, folderName);
        private static readonly string file = Path.Combine(folder, fileName);

        private const string folderName = "User";
        private const string fileName = "Race.dat";

        public ArrayList ListInfo { get; set; } = new ArrayList();

        public static void AddNewRace(IEnumerable race, string name, IEnumerable bet)
        {
            var dirInfo = new DirectoryInfo(folder);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using var writer = new StreamWriter(file, append: true);
            writer.AutoFlush = true;
            writer.WriteLine(name);
            foreach(var r in race)
            {
                writer.Write(r.ToString());
                foreach(var b in bet)
                {
                    string[] words = b.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (r.ToString().Substring(0, 4) == b.ToString().Substring(0, 4))
                    {
                        writer.Write(" " + words[5]);
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

        public void ReadRacesForUser(string name)
        {
            using var reader = new StreamReader(file);
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                if (line != name)
                {
                    continue;
                }
                while ((line = reader.ReadLine()) != "/")
                {
                    string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (words.Length > 3)
                    {
                        ListInfo.Add(new FileInfo()
                        {
                            HorseNameFile = words[0],
                            HorseCoefFile = words[1],
                            HorsePositionFile = words[2],
                            UserResultFile = words[3]
                        });
                    }
                    else
                    {
                        ListInfo.Add(new FileInfo
                        {
                            HorseNameFile = words[0],
                            HorseCoefFile = words[1],
                            HorsePositionFile = words[2]
                        });
                    }
                }
                
            }
        }

        public void PrintResult()
        {
            foreach (FileInfo o in ListInfo)
            {
                Console.WriteLine(o.HorseNameFile + " " + o.HorseCoefFile + " " + o.HorsePositionFile +
                    " " + o.UserResultFile);
            }
        }

        public void ReadHorsesForUser(string name)
        {
            ReadRacesForUser(name);

            var horses = from FileInfo file in ListInfo
                         where file.UserResultFile == "Win" || 
                               file.UserResultFile == "Lose" 
                         select file;

            foreach (var o in horses)
            {
                Console.WriteLine(o.HorseNameFile);
            }
        }

    }
}


