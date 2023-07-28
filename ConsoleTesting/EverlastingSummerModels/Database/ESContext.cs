using ConsoleTesting.EverlastingSummerModels.Scenes;
using ConsoleTesting.Models;
using ConsoleTesting.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.EverlastingSummerModels.Database
{
    public class ESContext : DbContext
    {
        DbSet<StandardScene> Scenes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=EverlastingSummerModels/Database/Game.db");
        }
    }
}
