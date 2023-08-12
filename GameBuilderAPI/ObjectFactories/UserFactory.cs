using ConsoleTesting.Models.Player;
using GameBuilder.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilderAPI.ObjectFactories
{
    internal class UserFactory
    {
        private static UserFactory _Instance;
        public static UserFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserFactory();
                return _Instance;
            }
        }
        private UserFactory() { }

        public User CreateUser()
        {
            return new User();
        }
    }
}
