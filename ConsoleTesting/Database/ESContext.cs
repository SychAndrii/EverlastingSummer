using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Scenes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public DbSet<EndingPointsCondition> EndingPointsConditions { get; set; } = null!;

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
            modelBuilder
                .Entity<Condition>()
                .UseTpcMappingStrategy()
                .Property(c => c.Id).HasField("_Id");

            modelBuilder
                .Entity<MadeChoicesCondition>()
                .UseTpcMappingStrategy();

            modelBuilder
                .Entity<EndingPointsCondition>()
                .UseTpcMappingStrategy()
                .ToTable(b => b.HasCheckConstraint("Points_bigger_than_0", "PointsRequired > 0"));
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
