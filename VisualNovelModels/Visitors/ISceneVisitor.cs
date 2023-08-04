﻿using ConsoleTesting.Database;
using ConsoleTesting.Models.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Visitors
{
    public interface ISceneVisitor
    {
        Task Visit(StandardScene scene);
        Task Visit(ChoiceScene scene);

        // Add new types of Visit functions if there are any new types of scenes.
    }
}
