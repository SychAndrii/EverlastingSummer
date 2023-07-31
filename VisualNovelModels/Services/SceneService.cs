using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Services
{
    public class SceneService
    {
        private static SceneService _Instance;
        public static SceneService Instance 
        { 
            get
            {
                if(_Instance == null)
                    _Instance = new SceneService();
                return _Instance;
            }
        }
        private SceneService() { }

        public bool AddScene(Scene scene)
        {
            using ESContext context = new ESContext();
            try
            {
                context.Scenes.Add(scene);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
