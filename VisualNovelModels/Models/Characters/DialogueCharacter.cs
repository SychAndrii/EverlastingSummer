using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models.Characters
{
    /// <summary>
    /// Represents an author, who is displayed with the dialogue text.
    /// </summary>
    public class DialogueCharacter
    {
        private readonly Guid _Id;
        public Guid Id { get => _Id; }

        public string Name { get; set; }


        /// <summary>
        /// Compares two dialogue characters for equality.
        /// </summary>
        /// <remarks>
        /// IN THE FUTURE ALLOW MANY CHARACTERS WITH THE SAME NAME! WILL HAVE TO CHECK FOR 
        /// BOTH COLOR AND NAME. Two dialogue characters are considered equal if they have 
        /// the same Name property.
        /// </remarks>
        /// <param name="obj">Object for comparison (should be of DialogueCharacter type)</param>
        /// <returns>
        /// False if Names are different or obj is not of type DialogueCharacter.
        /// True otherwise.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is DialogueCharacter other && other.Name == Name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_Id, Name);
        }
    }
}
