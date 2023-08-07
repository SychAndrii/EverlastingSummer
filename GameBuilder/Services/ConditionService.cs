using ConsoleTesting.Database;
using ConsoleTesting.Models.Base;
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

        public async Task<Condition?> AddCondition(Condition c)
        {
            using ESContext context = new ESContext();
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
