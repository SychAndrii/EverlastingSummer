using ConsoleTesting;
using ConsoleTesting.Models;
using Microsoft.EntityFrameworkCore;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Database;
using ConsoleTesting.Models.Conditions;

namespace Program
{
    public class Testing
    {
        public static void Main(string[] args)
        {
            using (ESContext context = new ESContext()) 
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Ending end1 = new Ending("Ending 1");
                Ending end2 = new Ending("Ending 2");
                context.Endings.AddRange(end1, end2);

                EndingPointsCondition endingPointsCondition = new EndingPointsCondition();
                endingPointsCondition.Ending = end1;
                endingPointsCondition.PointsRequired = 4;
                context.EndingPointsConditions.Add(endingPointsCondition);

                context.SaveChanges();
            }

            using (ESContext context = new ESContext())
            {
                var endingPointsEnding = context.EndingPointsConditions.Include(c => c.Ending).FirstOrDefault();
                if(endingPointsEnding != null )
                {
                    Console.WriteLine(endingPointsEnding.Ending);
                    Console.WriteLine(endingPointsEnding.PointsRequired);
                }
            }
        }
    }
}