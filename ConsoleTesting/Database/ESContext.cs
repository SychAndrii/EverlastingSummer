using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Scenes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Database
{
    public class ESContext : DbContext
    {
        public DbSet<Choice> Choices { get; set; } = null!;
        public DbSet<Ending> Endings { get; set; } = null!;
        public DbSet<Condition> Conditions { get; set; } = null!;
        public DbSet<MadeChoicesCondition> MadeChoicesConditions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfiguringChoice(modelBuilder);
            ConfiguringEnding(modelBuilder);
            ConfiguringConditions(modelBuilder);
            //ConfiguringScene(modelBuilder);
        }

        private void ConfiguringScene(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scene>().Property(c => c.Id).HasField("_Id");
            modelBuilder.Entity<Scene>().UseTpcMappingStrategy();
        }

        private void ConfiguringConditions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Condition>().Property(c => c.Id).HasField("_Id");
            modelBuilder.Entity<Condition>().UseTpcMappingStrategy();
            modelBuilder.Entity<MadeChoicesCondition>().UseTpcMappingStrategy();
        }

        private void ConfiguringChoice(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>().Property(c => c.Id).HasField("_Id");
        }

        private void ConfiguringEnding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ending>().Property(c => c.Id).HasField("_Id");
            modelBuilder.Entity<Ending>().HasIndex(e => e.Name).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database/Game.db");
        }
    }
}
