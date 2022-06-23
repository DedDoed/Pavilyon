using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;
using Pavilyon.Persistence.EntityTypeConfiguration;

namespace Pavilyon.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new AttachmentConfiguration());
            builder.ApplyConfiguration(new ProjectMemberConfiguration());
            builder.ApplyConfiguration(new ReportConfiguration());
            builder.ApplyConfiguration(new StageConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
