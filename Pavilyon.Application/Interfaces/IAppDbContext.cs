using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Domain;

namespace Pavilyon.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Attachment> Attachments { get; set; }
        DbSet<ProjectMember> ProjectMembers { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Stage> Stages { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
