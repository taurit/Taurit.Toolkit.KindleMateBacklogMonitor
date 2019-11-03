﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Taurit.Toolkit.KindleMateBacklogMonitor.Database
{
    /// <example>
    ///     This file and related models are autogenerated using:
    ///     dotnet tool install --global dotnet-ef
    ///     dotnet ef dbcontext scaffold "Filename=KM2.dat" Microsoft.EntityFrameworkCore.Sqlite
    ///     https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding
    /// </example>
    public class KindleMateDatabaseContext : DbContext
    {
        public KindleMateDatabaseContext()
        {
        }

        public KindleMateDatabaseContext(DbContextOptions<KindleMateDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clippings> Clippings { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<FoldersNew> FoldersNew { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }
        public virtual DbSet<OriginalClippingLines> OriginalClippingLines { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<Vocab> Vocab { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                throw new InvalidOperationException("you need to select which database to use.");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clippings>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("clippings");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.Authorname).HasColumnName("authorname");

                entity.Property(e => e.Bookname)
                    .HasColumnName("bookname")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Brieftype).HasColumnName("brieftype");

                entity.Property(e => e.ClippingImportdate).HasColumnName("clipping_importdate");

                entity.Property(e => e.Clippingdate).HasColumnName("clippingdate");

                entity.Property(e => e.Clippingtypelocation).HasColumnName("clippingtypelocation");

                entity.Property(e => e.ColorRgb)
                    .HasColumnName("colorRGB")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Newbookname).HasColumnName("newbookname");

                entity.Property(e => e.Pagenumber)
                    .HasColumnName("pagenumber")
                    .HasColumnType("INT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Read)
                    .HasColumnName("read")
                    .HasColumnType("INT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sync)
                    .HasColumnName("sync")
                    .HasColumnType("INT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tag).HasColumnName("tag");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("columns");

                entity.HasIndex(e => e.Order)
                    .IsUnique();

                entity.Property(e => e.ColumnFieldName).HasColumnName("column_field_name");

                entity.Property(e => e.ColumnTextshow).HasColumnName("column_textshow");

                entity.Property(e => e.ColumnWidth).HasColumnName("column_width");

                entity.Property(e => e.Lang).HasColumnName("lang");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("INT");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Visible)
                    .HasColumnName("visible")
                    .HasColumnType("INT");
            });

            modelBuilder.Entity<FoldersNew>(entity =>
            {
                entity.HasKey(e => e.FolderId);

                entity.ToTable("folders_new");

                entity.Property(e => e.FolderId).HasColumnName("folder_id");

                entity.Property(e => e.Foldername).HasColumnName("foldername");

                entity.Property(e => e.ItemsInFolder)
                    .IsRequired()
                    .HasColumnName("items_in_folder")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Lookups>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lookups");

                entity.HasIndex(e => e.Timestamp)
                    .IsUnique();

                entity.Property(e => e.Authors).HasColumnName("authors");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Usage).HasColumnName("usage");

                entity.Property(e => e.WordKey).HasColumnName("word_key");
            });

            modelBuilder.Entity<OriginalClippingLines>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.ToTable("original_clipping_lines");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.Line1)
                    .HasColumnName("line1")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Line2)
                    .HasColumnName("line2")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Line3)
                    .HasColumnName("line3")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Line4)
                    .HasColumnName("line4")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Line5)
                    .HasColumnName("line5")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("settings");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_new_settings");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("version");

                entity.Property(e => e.Dbversion).HasColumnName("dbversion");
            });

            modelBuilder.Entity<Vocab>(entity =>
            {
                entity.ToTable("vocab");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ColorRgb)
                    .HasColumnName("colorRGB")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Frequency)
                    .HasColumnName("frequency")
                    .HasColumnType("INT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Stem).HasColumnName("stem");

                entity.Property(e => e.Sync)
                    .HasColumnName("sync")
                    .HasColumnType("INT")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");

                entity.Property(e => e.Translation).HasColumnName("translation");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasColumnName("word");

                entity.Property(e => e.WordKey).HasColumnName("word_key");
            });
        }
    }
}