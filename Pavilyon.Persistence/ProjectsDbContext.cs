using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;
using Pavilyon.Persistence.EntityTypeConfiguration;

namespace Pavilyon.Persistence
{
    public class ProjectsDbContext : DbContext, IProjectsDbContext
    {
        public DbSet<Project> Projects { get; set; }
        public ProjectsDbContext (DbContextOptions<ProjectsDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
