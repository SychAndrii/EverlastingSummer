using ConsoleTesting.Models.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Base
{
    public class Choice
    {
        public string Text { get; set; }

        private readonly Guid _Id = Guid.NewGuid();
        public Guid Id { get => _Id; }
        public IEnumerable<MadeChoicesCondition>? MadeChoicesConditions { get; set; }

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

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, Id);
        }
    }
}
