﻿using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer
{
    public class ProjectContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<DeviceEntity> Devices { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(
                entity => { entity.HasIndex(e => e.Login).IsUnique(); });
        }
    }
}