using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using GameBuilder.Visitors;
using GameBuilderAPI.Services;
using Microsoft.EntityFrameworkCore;
using VisualNovelModels.Models.Choices;

namespace GameBuilder.Services
{
    internal class UserService : DBService
    {
        public UserService(ESContext context) : base(context)
        {
        }

        public async Task<User> GetUser()
        {
            var user = await FindUser();

            if (user == null)
                return await CreateUser();

            return user;
        }

        private async Task<User?> CreateUser()
        {
            var user = new User();
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        private async Task<User?> FindUser()
        {
            var scene = await context
                    .Users
                    .Include(u => u.Choices)
                    .FirstOrDefaultAsync();

            return scene;
        }

        internal async Task<User?> AddMadeUserChoice(User user, Choice c)
        {
            try
            {
                context.Users.Attach(user);
                context.Choices.Attach(c);
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

        internal async Task<User?> UpdateUserStateProgresses(User user, IEnumerable<StateModifier> stateModifiers)
        {
            try
            {
                var states = (from sm in stateModifiers
                              select sm.State).ToList();
                context.States.AttachRange(states);
                context.Users.Attach(user);

                user.StateProgresses = user.StateProgresses ?? new List<UserStateProgress>();

                foreach (var sm in stateModifiers)
                {
                    UserStateProgress? userStateProgress = null;
                    if ((userStateProgress = user.StateProgresses.FirstOrDefault(sp => sp.State == sm.State))
                        != null)
                    {
                        userStateProgress.CurrentPoints += sm.Points;
                    }
                    else
                    {
                        user.StateProgresses.Add(
                            new UserStateProgress 
                            { 
                                CurrentPoints = sm.Points, 
                                State = sm.State 
                            }
                        );
                    }
                }

                context.Users.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}