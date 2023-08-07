using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using GameBuilder.Visitors;
using GameBuilderAPI.Services;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User?> GetUser()
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
                    .FromSqlRaw("SELECT * FROM Users WHERE Id = 1")
                    .Include(u => u.StateProgresses)
                    .FirstOrDefaultAsync();

            return scene;
        }
    }
}