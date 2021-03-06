using Pavilyon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Domain
{
    public class Stage
    {
        public Guid Id { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public string StageName { get; set; }
        public Status StageStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
    }
}
