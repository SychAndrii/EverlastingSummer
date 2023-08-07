using ConsoleTesting.Database;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualNovelModels.Visitors
{
    public interface IConditionVisitorDB
    {
        public Task Visit(MadeChoicesCondition condition, ESContext context);
        public Task Visit(StatePointsCondition condition, ESContext context);
    }
}
