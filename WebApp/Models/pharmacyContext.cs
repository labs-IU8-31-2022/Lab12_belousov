﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class pharmacyContext : DbContext
    {
        public pharmacyContext()
        {
        }

        public pharmacyContext(DbContextOptions<pharmacyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Furniture> Furnitures { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.HasKey(e => e.Type);

                entity.ToTable("Furniture");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Medication");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}