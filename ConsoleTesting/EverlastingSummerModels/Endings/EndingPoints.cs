using ConsoleTesting.EverlastingSummerModels.Base;

namespace ConsoleTesting.EverlastingSummerModels
{
    public class EndingPoints
    {
        public Ending Ending { get; set; }
        public int Points { get; set; }

        public EndingPoints(Ending ending, int requiredPoints = 0)
        {
            Ending = ending;
            Points = requiredPoints;
        }
    }
}
