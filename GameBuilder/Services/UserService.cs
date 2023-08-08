using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using GameBuilder.Visitors;
using GameBuilderAPI.Services;
using Microsoft.EntityFrameworkCore;
using VisualNovelModels.Models.Choices;

namespace GameBuilder.Services
{
    internal class UserService
    {
        private static UserService _Instance;
        public static UserService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserService();
                return _Instance;
            }
        }
        private UserService() { }

        public async Task<User> GetUser()
        {
            using ESContext context = new ESContext();
            var user = await FindUser(context);

            if (user == null)
                return await CreateUser(context);

            return user;
        }

        private async Task<User?> CreateUser(ESContext context)
        {
            var user = new User();
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        private async Task<User?> FindUser(ESContext context)
        {
            var scene = await context
                    .Users
                    .FirstOrDefaultAsync();

            return scene;
        }

        internal async Task<User?> AddMadeUserChoice(User user, Choice c)
        {
            using ESContext context = new ESContext();
            try
            {
                context.Users.Attach(user);
                user.Choices = user.Choices ?? new List<Choice>();
                user.Choices.Add(c);
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}