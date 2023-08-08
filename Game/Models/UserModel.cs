using ConsoleTesting.Models.Player;
using GameBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameConsumer.Models
{
    internal static class UserModel
    {
        private static User? _CurrentUser;
        public static User CurrentUser 
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

        public static async Task<User?> AddMadeChoice(User user, Choice c)
        {
            return await UserBuilder.AddMadeUserChoice(user, c);
        }
    }
}
