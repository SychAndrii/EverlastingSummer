using DB.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models.TextSwitcher
{
    public class Dialogue
    {
        public string Text { get; set; }
        public DialogueCharacter? Character { get; set; }

        private readonly Guid _Id;
        public Guid Id { get => _Id; }
        public override string ToString()
        {
            if(Character != null)
            {
                return $"{Character}:\n{Text}\n\n";
            }
            return $"{Text}\n\n";
        }
    }
}
