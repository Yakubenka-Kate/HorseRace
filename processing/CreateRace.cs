using dataReading;
using System.Linq;

namespace processing
{
    /// <summary>
    /// Create a horse race
    /// </summary>
    internal class CreateRace
    {
        enum HorsesName
        {
            Zoe, Eva, Ivy, Mya, Amy, Ana, Lia, Ada, Ida, Fay,
            Alba, Ferd, Abel, Eric, Alex, Roxy, Rich, Liam, Jack, Ryan, Ivan
        }

        /// <summary>
        /// The horse race
        /// </summary>
        public Race GenerateRace { get; set; }

        public CreateRace(int count)
        {
            GenerateRace = new Race(count);
        }

        public Horse GetHorseByName(string name)
        {
            for (int i = 0; i < GenerateRace.CountHorses; i++)
            {
                if (name == GenerateRace.HorsesInRace[i].HorseName)
                {
                    return GenerateRace.HorsesInRace[i];
                }
            }

            return null;
        }

        public string[] NewRace()
        {
            HorsesName[] name = HorseName();
            int[] res = RandomRes();
            double[] coef = RandomCoef();
            string[] race = new string[GenerateRace.CountHorses];

            for (int i = 0; i < GenerateRace.CountHorses; i++)
            {
                GenerateRace.HorsesInRace[i] = new Horse(name[i].ToString(), coef[i], res[i]);
                race[i] = GenerateRace.HorsesInRace[i].ToString();
            }

            return race;
        }

        private HorsesName[] HorseName()
        {
            var rnd = new Random();
            var x = new int[20];

            for (int i = 0; i < GenerateRace.CountHorses; i++)
            {
                bool contains;
                int next;

                do
                {
                    next = rnd.Next(0, 20);
                    contains = false;
                    for (int index = 0; index < i; index++)
                    {
                        int n = x[index];
                        if (n == next)
                        {
                            contains = true;
                            break;
                        }
                    }
                } while (contains);
                x[i] = next;
            }

            var name = new HorsesName[GenerateRace.CountHorses];

            for (int i = 0; i < GenerateRace.CountHorses; i++)
            {
                name[i] = (HorsesName)x[i];
            }

            return name;
        }

        private double[] RandomCoef()
        {
            var rnd = new Random();
            var coef = new double[GenerateRace.CountHorses];

            for (int i = 0; i < GenerateRace.CountHorses; i++)
            {
                coef[i] = Convert.ToDouble(rnd.Next(100, 500) / 100.0);
            }

            return coef;
        }

        private int[] RandomRes()
        {
            var rnd = new Random();
            var x = new int[GenerateRace.CountHorses];

            for (int i = 0; i < GenerateRace.CountHorses; i++)
            {
                bool contains;
                int next;

                do
                {
                    next = rnd.Next(1, GenerateRace.CountHorses + 1);
                    contains = false;
                    for (int index = 0; index < i; index++)
                    {
                        int n = x[index];
                        if (n == next)
                        {
                            contains = true;
                            break;
                        }
                    }
                } while (contains);
                x[i] = next;
            }

            return x;
        }
    }
}
