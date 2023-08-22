using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Services;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using GameBuilderAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services
{
    internal class CharacterService : DBService
    {
        public CharacterService(ESContext context) : base(context) { }

        /// <summary>
        /// Tries to add a character to the database. If not successful, returns null.
        /// </summary>
        /// <param name="character">A character to add to the database.</param>
        /// <returns>null if unsuccessful, character (passed as parameter) otherwise.</returns>
        public async Task<DialogueCharacter?> AddCharacter(DialogueCharacter character)
        {
            var sameExistingCharacter = await context.DialogueCharacters
                .Where(existingCharacter => existingCharacter.Name == character.Name)
                .FirstOrDefaultAsync();

            if (sameExistingCharacter == null)
            {
                await context.DialogueCharacters.AddAsync(character);
                var res = await context.SaveChangesAsync();
                return character;
            }
            return null;
        }
    }
}
