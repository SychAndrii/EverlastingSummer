using ConsoleTesting.Database;
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
            foreach (var choice in condition.Choices)
            {
                foreach (var modifier in choice.StateModifiers)
                {
                    context.StateModifiers.Attach(modifier);
                }

                context.Choices.Attach(choice);
                context.ChoiceScenes.Attach(choice.ChoiceScene);

                foreach (var c in choice.ChoiceScene.Choices)
                {
                    foreach (var modifier in c.StateModifiers)
                    {
                        context.StateModifiers.Attach(modifier);
                        context.States.Attach(modifier.State);
                    }
                    context.Choices.Attach(c);
                }
            }
        }

    }
}
