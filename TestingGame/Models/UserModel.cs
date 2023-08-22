using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Transit;
using GameBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameConsumer.Models
{
    internal class UserModel
    {
        private static User? _CurrentUser;
        private UserBuilder UserBuilder { get; }
        public User CurrentUser 
        { 
            get
            {
                if( _CurrentUser == null )
                {
                    _CurrentUser = UserBuilder.GetUser().Result;
                }
                return _CurrentUser;
            }
        }

        public UserModel(UserBuilder userBuilder)
        {
            UserBuilder = userBuilder;
        }

        public async Task<User?> AddMadeChoice(User user, Choice c)
        {
            return await UserBuilder.AddMadeUserChoice(user, c);
        }

        internal async Task<User?> UpdateStateProgresses(User currentUser, IEnumerable<StateModifier> stateModifiers)
        {
            return await UserBuilder.UpdateUserStateProgresses(currentUser, stateModifiers);
        }
    }
}
