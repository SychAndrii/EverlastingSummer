﻿// <auto-generated />
using System;
using ConsoleTesting.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleTesting.Migrations
{
    [DbContext(typeof(ESContext))]
    [Migration("20230803011449_AddedFirstSceneTable")]
    partial class AddedFirstSceneTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ChoiceMadeChoicesCondition", b =>
                {
                    b.Property<Guid>("ChoicesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MadeChoicesConditionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("ChoicesId", "MadeChoicesConditionsId");

                    b.HasIndex("MadeChoicesConditionsId");

                    b.ToTable("ChoiceMadeChoicesCondition");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Animation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SequenceId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SequenceId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Choice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChoiceSceneId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceSceneId");

                    b.HasIndex("UserId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Condition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TransitionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TransitionId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Scene", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Player.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Player.UserStateProgress", b =>
                {
                    b.Property<Guid>("StateId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentPoints")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStates");
                });

            modelBuilder.Entity("ConsoleTesting.Models.SceneParts.SideEffect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TransitionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TransitionId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.Transition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SourceSceneId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TargetSceneId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SourceSceneId");

                    b.HasIndex("TargetSceneId")
                        .IsUnique();

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("DB.Models.Characters.DialogueCharacter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DialogueCharacters");
                });

            modelBuilder.Entity("DB.Models.Characters.SpriteCharacter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SceneId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpritePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SceneId");

                    b.HasIndex("SpritePath")
                        .IsUnique();

                    b.ToTable("SpriteCharacters");
                });

            modelBuilder.Entity("DB.Models.TextSwitcher.Dialogue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Dialogues");
                });

            modelBuilder.Entity("VisualNovelModels.Models.Scenes.FirstScene", b =>
                {
                    b.Property<bool>("Id")
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<Guid?>("SceneId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SceneId");

                    b.ToTable("FirstScene");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Animations.SceneColor", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Animation");

                    b.ToTable("SceneColors");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Conditions.EndingPointsCondition", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Condition");

                    b.Property<Guid>("EndingId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PointsRequired")
                        .HasColumnType("INTEGER");

                    b.HasIndex("EndingId");

                    b.ToTable("EndingPointsConditions", t =>
                        {
                            t.HasCheckConstraint("Points_bigger_than_0", "PointsRequired > 0");
                        });
                });

            modelBuilder.Entity("ConsoleTesting.Models.Conditions.MadeChoicesCondition", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Condition");

                    b.ToTable("MadeChoicesConditions");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.ChoiceScene", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Scene");

                    b.Property<Guid?>("SpriteCharacterId")
                        .HasColumnType("TEXT");

                    b.HasIndex("SpriteCharacterId");

                    b.ToTable("ChoiceScenes");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.StandardScene", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Scene");

                    b.Property<Guid>("DialogueId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SpriteCharacterId")
                        .HasColumnType("TEXT");

                    b.HasIndex("DialogueId");

                    b.HasIndex("SpriteCharacterId");

                    b.ToTable("StandardScenes");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.EndingModifier", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.SceneParts.SideEffect");

                    b.Property<Guid>("EndingId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasIndex("EndingId");

                    b.HasIndex("UserId");

                    b.ToTable("EndingModifiers");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.Sequence", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.SceneParts.SideEffect");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("ChoiceMadeChoicesCondition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Choice", null)
                        .WithMany()
                        .HasForeignKey("ChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleTesting.Models.Conditions.MadeChoicesCondition", null)
                        .WithMany()
                        .HasForeignKey("MadeChoicesConditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Animation", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Transit.Sequence", null)
                        .WithMany("Animations")
                        .HasForeignKey("SequenceId");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Choice", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Scenes.ChoiceScene", "ChoiceScene")
                        .WithMany("Choices")
                        .HasForeignKey("ChoiceSceneId");

                    b.HasOne("ConsoleTesting.Models.Player.User", null)
                        .WithMany("Choices")
                        .HasForeignKey("UserId");

                    b.Navigation("ChoiceScene");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Condition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Transit.Transition", null)
                        .WithMany("Conditions")
                        .HasForeignKey("TransitionId");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Player.UserStateProgress", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.State", "State")
                        .WithOne()
                        .HasForeignKey("ConsoleTesting.Models.Player.UserStateProgress", "StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleTesting.Models.Player.User", null)
                        .WithMany("StateProgresses")
                        .HasForeignKey("UserId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("ConsoleTesting.Models.SceneParts.SideEffect", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Transit.Transition", null)
                        .WithMany("SideEffects")
                        .HasForeignKey("TransitionId");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.Transition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Scene", "SourceScene")
                        .WithMany("Transitions")
                        .HasForeignKey("SourceSceneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConsoleTesting.Models.Base.Scene", "TargetScene")
                        .WithOne()
                        .HasForeignKey("ConsoleTesting.Models.Transit.Transition", "TargetSceneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SourceScene");

                    b.Navigation("TargetScene");
                });

            modelBuilder.Entity("DB.Models.Characters.SpriteCharacter", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Scene", null)
                        .WithMany("Characters")
                        .HasForeignKey("SceneId");
                });

            modelBuilder.Entity("DB.Models.TextSwitcher.Dialogue", b =>
                {
                    b.HasOne("DB.Models.Characters.DialogueCharacter", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("VisualNovelModels.Models.Scenes.FirstScene", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Scene", "Scene")
                        .WithMany()
                        .HasForeignKey("SceneId");

                    b.Navigation("Scene");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Conditions.EndingPointsCondition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.State", "Ending")
                        .WithMany()
                        .HasForeignKey("EndingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ending");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.ChoiceScene", b =>
                {
                    b.HasOne("DB.Models.Characters.SpriteCharacter", null)
                        .WithMany("ChoiceScenes")
                        .HasForeignKey("SpriteCharacterId");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.StandardScene", b =>
                {
                    b.HasOne("DB.Models.TextSwitcher.Dialogue", "Dialogue")
                        .WithMany()
                        .HasForeignKey("DialogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Characters.SpriteCharacter", null)
                        .WithMany("StandardScenes")
                        .HasForeignKey("SpriteCharacterId");

                    b.Navigation("Dialogue");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.EndingModifier", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.State", "Ending")
                        .WithMany()
                        .HasForeignKey("EndingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleTesting.Models.Player.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ending");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Scene", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Transitions");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Player.User", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("StateProgresses");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.Transition", b =>
                {
                    b.Navigation("Conditions");

                    b.Navigation("SideEffects");
                });

            modelBuilder.Entity("DB.Models.Characters.SpriteCharacter", b =>
                {
                    b.Navigation("ChoiceScenes");

                    b.Navigation("StandardScenes");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.ChoiceScene", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Transit.Sequence", b =>
                {
                    b.Navigation("Animations");
                });
#pragma warning restore 612, 618
        }
    }
}
