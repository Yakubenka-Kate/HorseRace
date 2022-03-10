namespace horseBet.classes
{
    internal class Horse
    {
        public string HorseName { get; set; }
        public double HorseCoef { get; set; }
        public int HorseResult { get; set; }

        public Horse(string name, double coef, int result)
        {
            HorseName = name;
            HorseCoef = coef;
            HorseResult = result;
        }

        //public void PrintWithResult() // в другой класс
        //{
        //    Console.WriteLine($"{HorseName,7} {HorseCoef,6:F2}  {HorseResult}");
        //}

        //public void PrintHorses()
        //{
        //    Console.WriteLine($"{HorseName,7} {HorseCoef,6:F2}");
        //}

        public override string ToString() => $"{HorseName,7} {HorseCoef,6}  { HorseResult}";

    }
}
