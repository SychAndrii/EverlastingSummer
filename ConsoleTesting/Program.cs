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
                Choice choice = new Choice("Choice 1");
                Choice choice2 = new Choice("Choice 3");
                context.Choices.AddRange(choice, choice2);
                MadeChoicesCondition madeChoicesCondition = new MadeChoicesCondition();
                madeChoicesCondition.Choices = new List<Choice>()
                {
                    choice, choice2
                };
                context.MadeChoicesConditions.AddRange(madeChoicesCondition);
                context.SaveChanges();
            }

            using (ESContext context = new ESContext())
            {
                var madeChoicesCondition = context.MadeChoicesConditions.Include(c => c.Choices).FirstOrDefault();
                if(madeChoicesCondition != null)
                {
                    foreach(Choice choice in madeChoicesCondition.Choices)
                    {
                        Console.WriteLine(choice.Text);
                    }
                }
            }
        }
    }
}