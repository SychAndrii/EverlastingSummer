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
    internal class ConditionService
    {
        private static ConditionService _Instance;
        public static ConditionService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ConditionService();
                return _Instance;
            }
        }
        private ConditionService() { }

        public Task LoadConditionsTask(ESContext context)
        {
            return context.MadeChoicesConditions
                .Include(s => s.Choices)
                .ToListAsync();
        }

        public async Task<Condition?> AddCondition(Condition c)
        {
            using ESContext context = new ESContext();
            try
            {
                if(c is StatePointsCondition)
                    await Console.Out.WriteLineAsync();
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
