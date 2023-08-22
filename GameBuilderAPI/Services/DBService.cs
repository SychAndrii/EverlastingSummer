using ConsoleTesting.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilderAPI.Services
{
    internal class DBService
    {
        protected internal readonly ESContext context;

        public DBService(ESContext context)
        {
            this.context = context;
        }
    }
}
