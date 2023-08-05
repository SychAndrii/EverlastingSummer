﻿using ConsoleTesting.Database;
using ConsoleTesting.Models.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Visitors
{
    /// <summary>
    /// A visitor for adding certain database behavior to different scenes.
    /// </summary>
    /// <remarks>
    /// See <see cref="https://refactoring.guru/design-patterns/visitor"/> (Visitor pattern).
    /// </remarks>
    public interface ISceneVisitorDB
    {
        Task Visit(StandardScene scene, ESContext context);
        Task Visit(ChoiceScene scene, ESContext context);

        // Add new types of Visit functions if there are any new types of scenes.
    }
}
