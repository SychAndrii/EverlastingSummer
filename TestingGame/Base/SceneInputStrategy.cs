using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Base
{
    interface SceneInputStrategy<in T>
        where T : Scene
    {

        string AskForInput(T scene);
    }
}
