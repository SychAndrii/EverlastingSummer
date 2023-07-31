using DB.Models.Characters;
using DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.Factories
{
    public class CharacterFactory
    {
        private static CharacterFactory _Instance;
        public static CharacterFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CharacterFactory();
                return _Instance;
            }
        }
        private CharacterFactory() { }

        public DialogueCharacter CreateDialogueCharacter(string name)
        {
            return new DialogueCharacter { Name = name };
        }
    }
}
