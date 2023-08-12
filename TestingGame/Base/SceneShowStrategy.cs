﻿using ConsoleTesting.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsumer.Base
{
    interface SceneShowStrategy<in T>
        where T : Scene
    {
        public abstract void Show(T scene);
    }
}