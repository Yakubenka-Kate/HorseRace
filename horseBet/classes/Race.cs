namespace horseBet.classes
{
    /// <summary>
    /// Forms a horse race
    /// </summary>
    internal class Race
    {
        /// <summary>
        /// Number of horses in the race
        /// </summary>
        public int CountHorses { get; set; }

        /// <summary>
        /// Horses in the race
        /// </summary>
        public Horse[] HorsesInRace { get; set; } = new Horse[15];

        public Race(int count) => CountHorses = count;

        public void NewRace()
        {
            int[] res = RandomRes();
            double[] coef = RandomCoef();

            for (int index = 0; index < CountHorses; index++)
            {
                HorsesInRace[index] = new Horse("Horse" + (index + 1), coef[index], res[index]);
            }
        }

        private double[] RandomCoef()
        {
            var rnd = new Random();
            var coef = new double[CountHorses];

            for (int i = 0; i < CountHorses; i++)
            {
                coef[i] = Convert.ToDouble(rnd.Next(100, 500) / 100.0);
            }

            return coef;
        }

        private int[] RandomRes()
        {
            var rnd = new Random();
            var x = new int[CountHorses];

            for (int i = 0; i < CountHorses; i++)
            {
                bool contains;
                int next;

                do
                {
                    next = rnd.Next(1, CountHorses + 1);
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
