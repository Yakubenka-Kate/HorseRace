namespace horseBet.classes
{
    internal class Horse
    {
        private string horseName;
        private double horseCoef;
        private int horseResult;

        public string HorseName
        {
            get { return horseName; }
            set { horseName = value; }
        }

        public double HorseCoef
        {
            get { return horseCoef; }
            set { horseCoef = value; }
        }

        public int HorseResult
        {
            get { return horseResult; }
            set { horseResult = value; }
        }

        public Horse()
        {
            horseName = "";
            horseCoef = 0;
            horseResult = 0;
        }

        public Horse(string name, double coef, int result)
        {
            horseName = name;
            horseCoef = coef;
            horseResult = result;
        }

        public void PrintWithResult()
        {
            Console.WriteLine($"{HorseName,7} {HorseCoef,6:F2}  {HorseResult}");
        }

        public void PrintHorses()
        {
            Console.WriteLine($"{HorseName,7} {HorseCoef,6:F2}"); // + {HorseResult}
        }


    }
}
