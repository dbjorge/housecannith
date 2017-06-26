using System;
using HouseCannith.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HouseCannith.Data
{
    public partial class ComprendiumDbContext : DbContext
    {
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Companion> Companion { get; set; }
        public virtual DbSet<Deity> Deity { get; set; }
        public virtual DbSet<Disease> Disease { get; set; }
        public virtual DbSet<EpicDestiny> EpicDestiny { get; set; }
        public virtual DbSet<Feat> Feat { get; set; }
        public virtual DbSet<Glossary> Glossary { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Monster> Monster { get; set; }
        public virtual DbSet<ParagonPath> ParagonPath { get; set; }
        public virtual DbSet<Poison> Poison { get; set; }
        public virtual DbSet<Power> Power { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Ritual> Ritual { get; set; }
        public virtual DbSet<Terrain> Terrain { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }
        public virtual DbSet<Trap> Trap { get; set; }

        public ComprendiumDbContext(DbContextOptions<ComprendiumDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Background>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Backgrou__C5B21430C1DB0B38");

                entity.Property(e => e.Url).HasColumnType("varchar(67)");

                entity.Property(e => e.Campaign)
                    .IsRequired()
                    .HasColumnType("varchar(28)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(43)");

                entity.Property(e => e.Skills)
                    .IsRequired()
                    .HasColumnType("varchar(75)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(18)");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Class__C5B21430CA4D0367");

                entity.Property(e => e.Url).HasColumnType("varchar(62)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.KeyAbilities)
                    .IsRequired()
                    .HasColumnType("varchar(48)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(29)");

                entity.Property(e => e.PowerSourceText)
                    .IsRequired()
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Companion>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Companio__C5B214309306079A");

                entity.Property(e => e.Url).HasColumnType("varchar(66)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(31)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(19)");
            });

            modelBuilder.Entity<Deity>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Deity__C5B214308ABAE195");

                entity.Property(e => e.Url).HasColumnType("varchar(62)");

                entity.Property(e => e.Alignment)
                    .IsRequired()
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(27)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(31)");
            });

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Disease__C5B214306C58222A");

                entity.Property(e => e.Url).HasColumnType("varchar(63)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(28)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(41)");
            });

            modelBuilder.Entity<EpicDestiny>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__EpicDest__C5B2143061F57EC3");

                entity.Property(e => e.Url).HasColumnType("varchar(68)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(26)");

                entity.Property(e => e.Prerequisite)
                    .IsRequired()
                    .HasColumnType("varchar(149)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(35)");
            });

            modelBuilder.Entity<Feat>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Feat__C5B2143001962559");

                entity.Property(e => e.Url).HasColumnType("varchar(62)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(39)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.TierName)
                    .IsRequired()
                    .HasColumnType("varchar(7)");
            });

            modelBuilder.Entity<Glossary>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Glossary__C5B2143078EE5EBE");

                entity.Property(e => e.Url).HasColumnType("varchar(65)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(16)");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Item__C5B21430A6FEC358");

                entity.Property(e => e.Url).HasColumnType("varchar(62)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(54)");

                entity.Property(e => e.Rarity)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Monster__C5B2143057947856");

                entity.Property(e => e.Url).HasColumnType("varchar(67)");

                entity.Property(e => e.CombatRole)
                    .IsRequired()
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.GroupRole)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(67)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");
            });

            modelBuilder.Entity<ParagonPath>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__ParagonP__C5B21430FF233F4E");

                entity.Property(e => e.Url).HasColumnType("varchar(69)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(31)");

                entity.Property(e => e.Prerequisite)
                    .IsRequired()
                    .HasColumnType("varchar(95)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(35)");
            });

            modelBuilder.Entity<Poison>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Poison__C5B2143008F9E018");

                entity.Property(e => e.Url).HasColumnType("varchar(62)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(28)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(22)");
            });

            modelBuilder.Entity<Power>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Power__C5B214302E36BF02");

                entity.Property(e => e.Url).HasColumnType("varchar(64)");

                entity.Property(e => e.ActionType)
                    .IsRequired()
                    .HasColumnType("varchar(19)");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnType("varchar(31)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(47)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Race__C5B21430FC0BD304");

                entity.Property(e => e.Url).HasColumnType("varchar(60)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DescriptionAttribute)
                    .IsRequired()
                    .HasColumnType("varchar(46)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");
            });

            modelBuilder.Entity<Ritual>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Ritual__C5B2143053DC44B4");

                entity.Property(e => e.Url).HasColumnType("varchar(63)");

                entity.Property(e => e.ComponentCost)
                    .IsRequired()
                    .HasColumnType("varchar(77)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.KeySkillDescription)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(27)");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(33)");
            });

            modelBuilder.Entity<Terrain>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Terrain__C5B214309BB72E41");

                entity.Property(e => e.Url).HasColumnType("varchar(64)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(23)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(31)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(17)");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Theme__C5B214306E2FE1DA");

                entity.Property(e => e.Url).HasColumnType("varchar(63)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(47)");
            });

            modelBuilder.Entity<Trap>(entity =>
            {
                entity.HasKey(e => e.Url)
                    .HasName("PK__Trap__C5B21430E775DFC2");

                entity.Property(e => e.Url).HasColumnType("varchar(62)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.GroupRole)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(38)");

                entity.Property(e => e.SourceBook)
                    .IsRequired()
                    .HasColumnType("varchar(33)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(18)");
            });
        }
    }
}