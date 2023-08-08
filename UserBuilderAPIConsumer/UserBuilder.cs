using ConsoleTesting.Models.Player;
using VisualNovelModels.Models.Choices;

namespace GameBuilder
{
    public static class UserBuilder
    {
        public static async Task<User> GetUser()
        {
            return await GameBuilderAPI.GetUser();
        }

        public static async Task<User> AddMadeUserChoice(User user, Choice c)
        {
            return await GameBuilderAPI.AddMadeUserChoice(user, c);
        }
    }
}