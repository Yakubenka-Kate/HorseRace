namespace horseBet.classes
{
    internal class Race
    {
        private int countHorses { get; set; }
        private Horse[] horsesInRace { get; set; } = new Horse[15];

        public Race(int count)
        {
            countHorses = count;
        }

        public void NewRace()
        {
            int[] res = RandomRes();
            double[] coef = RandomCoef();

            for (int index = 0; index < countHorses; index++)
            {
                horsesInRace[index] = new Horse("Horse" + (index + 1), coef[index], res[index]);
            }
        }

        private double[] RandomCoef()
        {
            var rnd = new Random();
            var coef = new double[countHorses];

            for (int i = 0; i < countHorses; i++)
            {
                coef[i] = Convert.ToDouble(rnd.Next(100, 500) / 100.0);
            }

            return coef;
        }

        private int[] RandomRes()
        {
            var rnd = new Random();
            var x = new int[countHorses];

            for (int i = 0; i < countHorses; i++)
            {
                bool contains;
                int next;

                do
                {
                    next = rnd.Next(1, countHorses + 1);
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

        public void PrintWithResult()
        {
            var print = new Printer();
            for (int i = 0; i < countHorses; i++)
            {
                print.Print(horsesInRace[i].ToString());
            }
        }

        public bool IsHorse(string name, out Horse horse)
        {
            for (int i = 0; i < countHorses; i++)
            {
                if (name == horsesInRace[i].HorseName)
                {
                    horse = horsesInRace[i];
                    return true;
                }
                else
                    continue;
            }
            horse = null;
            return false;
        }

    }
}
