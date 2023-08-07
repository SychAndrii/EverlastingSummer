using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Scenes;
using GameBuilder.Visitors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Visitors;

namespace GameBuilderAPI.Visitors
{
    internal class ConditionAddedVisitor : IConditionVisitorDB
    {
        private static ConditionAddedVisitor _Instance;

        public static ConditionAddedVisitor Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ConditionAddedVisitor();
                return _Instance;
            }
        }
        private ConditionAddedVisitor()
        {
        }

        public Task Visit(MadeChoicesCondition condition, ESContext context)
        {
            AvoidChoicesAdditions(condition, context);
            return Task.CompletedTask;
        }

        public Task Visit(StatePointsCondition condition, ESContext context)
        {
            throw new NotImplementedException();
        }

        private void AvoidChoicesAdditions(MadeChoicesCondition condition, ESContext context) 
        {
            context.Choices.AttachRange(condition.Choices);
        }

    }
}
