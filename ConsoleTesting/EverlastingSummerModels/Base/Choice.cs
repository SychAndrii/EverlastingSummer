using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Base
{
    public class Choice
    {
        public string Text { get; }
        public int Id { get; }

        public Choice(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object? obj)
        {
            return obj is Choice c && c.Id == Id;
        }
    }
}
