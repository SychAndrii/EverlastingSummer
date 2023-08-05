using ConsoleTesting.Models.Animations;
using ConsoleTesting.Models.Base;
using ConsoleTesting.Models.Conditions;
using ConsoleTesting.Models.Player;
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
using VisualNovelModels.Models.Base;
using VisualNovelModels.Models.Choices;
using VisualNovelModels.Models.Scenes;

namespace ConsoleTesting.Database
{
    public class ESContext : DbContext
    {
        public DbSet<FirstScene> FirstScene { get; set; }
        public DbSet<Choice> Choices { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<Condition> Conditions { get; set; } = null!;
        public DbSet<MadeChoicesCondition> MadeChoicesConditions { get; set; } = null!;
        public DbSet<StatePointsCondition> EndingPointsConditions { get; set; } = null!;
        public virtual DbSet<UserStateProgress> UserStates { get; set; } = null!;
        public DbSet<Scene> Scenes { get; set; } = null!;
        public DbSet<SpriteCharactersScene> SpriteCharactersScenes { get; set; } = null!;
        public DbSet<ChoiceScene> ChoiceScenes { get; set; } = null!;
        public DbSet<StandardScene> StandardScenes { get; set; } = null!;
        public DbSet<Transition> Transitions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<StateModifier> EndingModifiers { get; set; } = null!;
        public DbSet<SceneColor> SceneColors { get; set; } = null!;
        public DbSet<DialogueCharacter> DialogueCharacters { get; set; } = null!;
        public DbSet<SpriteCharacter> SpriteCharacters { get; set; } = null!;
        public DbSet<Dialogue> Dialogues { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfiguringChoice(modelBuilder);
            ConfiguringState(modelBuilder);
            ConfiguringConditions(modelBuilder);
            ConfiguringUsers(modelBuilder);
            ConfiguringTransitions(modelBuilder);
            ConfiguringScenes(modelBuilder);
            ConfiguringSideEffects(modelBuilder);
            ConfiguringAnimation(modelBuilder);
            ConfiguringSceneParts(modelBuilder);
            ConfiguringFirstScene(modelBuilder);
        }

        private void ConfiguringFirstScene(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FirstScene>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasDefaultValue(true)
                    .ValueGeneratedNever();
            });
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
                .Entity<StateModifier>()
                .UseTpcMappingStrategy();
        }

        private void ConfiguringTransitions(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Transition>()
                .Property("Id").HasField("_Id");

            modelBuilder.Entity<Transition>()
                .HasOne(t => t.SourceScene)
                .WithMany(s => s.Transitions)
                .HasForeignKey(t => t.SourceSceneId)
                .OnDelete(DeleteBehavior.Restrict); // Необходимо для предотвращения циклических зависимостей при удалении

            modelBuilder.Entity<Transition>()
                .HasOne(t => t.TargetScene)
                .WithOne() // Указываем, что у целевой сцены нет обратной связи
                .HasForeignKey<Transition>(t => t.TargetSceneId)
                .OnDelete(DeleteBehavior.Restrict); // Необходимо для предотвращения циклических зависимостей при удалении
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

            modelBuilder
                .Entity<SpriteCharactersScene>()
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
                .Entity<StatePointsCondition>()
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

        private void ConfiguringState(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<State>()
                .Property(c => c.Id)
                .HasField("_Id");

            modelBuilder
                .Entity<State>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder
                .Entity<StateModifier>()
                .Property(c => c.Id)
                .HasField("_Id");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database/Game.db");
        }
    }
}
