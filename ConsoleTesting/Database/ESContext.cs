using ConsoleTesting.Models.Animations;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.SceneParts;
using ConsoleTesting.Models.Scenes;
using ConsoleTesting.Models.Transit;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
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
        public DbSet<State> States { get; set; } = null!;
        public DbSet<Condition> Conditions { get; set; } = null!;
        public DbSet<MadeChoicesCondition> MadeChoicesConditions { get; set; } = null!;
        public DbSet<EndingPointsCondition> EndingPointsConditions { get; set; } = null!;
        public virtual DbSet<UserStateProgress> UserStates { get; set; } = null!;
        public DbSet<Scene> Scenes { get; set; } = null!;
        public DbSet<ChoiceScene> ChoiceScenes { get; set; } = null!;
        public DbSet<StandardScene> StandardScenes { get; set; } = null!;
        public DbSet<Transition> Transitions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<EndingModifier> EndingModifiers { get; set; } = null!;
        public DbSet<Sequence> Sequences { get; set; } = null!;
        public DbSet<SideEffect> SideEffects { get; set; } = null!;
        public DbSet<SceneColor> SceneColors { get; set; } = null!;
        public DbSet<DialogueCharacter> DialogueCharacters { get; set; } = null!;
        public DbSet<SpriteCharacter> SpriteCharacters { get; set; } = null!;
        public DbSet<Dialogue> Dialogues { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfiguringChoice(modelBuilder);
            ConfiguringEnding(modelBuilder);
            ConfiguringConditions(modelBuilder);
            ConfiguringUsers(modelBuilder);
            ConfiguringTransitions(modelBuilder);
            ConfiguringScenes(modelBuilder);
            ConfiguringSideEffects(modelBuilder);
            ConfiguringAnimation(modelBuilder);
            ConfiguringSceneParts(modelBuilder);
        }

        private void ConfiguringSceneParts(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Dialogue>()
                .Property("Id").HasField("_Id");

            modelBuilder
                .Entity<DialogueCharacter>()
                .Property("Id").HasField("_Id");

            modelBuilder
                .Entity<DialogueCharacter>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder
                .Entity<SpriteCharacter>()
                .Property("Id").HasField("_Id");

            modelBuilder
                .Entity<SpriteCharacter>()
                .HasIndex(s => s.SpritePath)
                .IsUnique();
        }

        private void ConfiguringAnimation(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Animation>()
                .UseTpcMappingStrategy()
                .Property("Id").HasField("_Id");

            modelBuilder
                .Entity<SceneColor>()
                .UseTpcMappingStrategy();
        }

        private void ConfiguringSideEffects(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SideEffect>()
                .UseTpcMappingStrategy()
                .Property("Id").HasField("_Id");

            modelBuilder
                .Entity<EndingModifier>()
                .UseTpcMappingStrategy();

            modelBuilder
                .Entity<Sequence>()
                .UseTpcMappingStrategy();
        }

        private void ConfiguringTransitions(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Transition>()
                .Property("Id").HasField("_Id");
        }

        private void ConfiguringUsers(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property("Id")
                .HasField("_Id");

            modelBuilder
                .Entity<UserStateProgress>()
                .HasKey(p => p.StateId);

            modelBuilder
                .Entity<UserStateProgress>()
                .HasOne(pep => pep.State)
                .WithOne()
                .HasForeignKey<UserStateProgress>(pep => pep.StateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfiguringScenes(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Scene>()
                .Property(c => c.Id)
                .HasField("_Id");

            modelBuilder
                .Entity<Scene>()
                .UseTpcMappingStrategy();

            modelBuilder
                .Entity<ChoiceScene>()
                .UseTpcMappingStrategy();

            modelBuilder
                .Entity<StandardScene>()
                .UseTpcMappingStrategy();
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
            modelBuilder
                .Entity<Choice>()
                .Property(c => c.Id)
                .HasField("_Id");
        }

        private void ConfiguringEnding(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<State>()
                .Property(c => c.Id)
                .HasField("_Id");

            modelBuilder
                .Entity<State>()
                .HasIndex(e => e.Name)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database/Game.db");
        }
    }
}
