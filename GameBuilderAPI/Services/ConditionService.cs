using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Transit;
using DB.Services;
using GameBuilder.Visitors;
using GameBuilderAPI.Visitors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;
using static System.Formats.Asn1.AsnWriter;

namespace GameBuilderAPI.Services
{
    internal class ConditionService : DBService
    {
        public ConditionService(ESContext context) : base(context)
        {
        }

        public Task LoadConditionDependenciesTask()
        {
            return context.MadeChoicesConditions
                .Include(s => s.Choices)
                .ToListAsync();
        }

        public async Task<Condition?> AddCondition(Condition c)
        {
            try
            {
                var conditionAddedVisitor = ConditionAddedVisitor.Instance;
                await c.AcceptDBVisitor(conditionAddedVisitor, context);
                context.Conditions.Add(c);

                await context.SaveChangesAsync();
                return c;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
