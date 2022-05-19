using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class ProjectMember
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public bool IsCreator { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Stage> Stages { get; set; } = new List<Stage>();
        public string ProjectRole { get; set; }
    }
}
